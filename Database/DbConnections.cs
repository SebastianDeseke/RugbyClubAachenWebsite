using MySql.Data.MySqlClient;

namespace RugbyClubAachenWeb.Database;

public class DbConnections
{

    MySqlConnection connection { get; set; }
    private readonly IConfiguration _config;

    public DbConnections(IConfiguration config)
    {
        _config = config;
    }



    public void Connect()
    {
        connection = new MySqlConnection(_config["ConnectionStrings:DatabaseConnection"]);
        // Open the connection
        connection.Open();
    }

    public void Disconnect()
    {
        // Close the connection
        connection.Close();
    }

    //User methods (have to redo because of database structure change)
    public void CreateUser(string username, string firstName, string lastName, string email, string create_time, string password)
    {
        string sqlQuery = @"INSERT INTO 
        users ( username, firstname, lastName, email, permission, roleId signupDate, password)
        VALUES (@Value0, @Value1, @Value2, @Value3, @Value4, @Value5, @Value6)";

        // Set up a command object with your SQL query and connection
        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        // Set the parameter values for your query
        command.Parameters.AddWithValue("@Value0", username);
        command.Parameters.AddWithValue("@Value1", firstName);
        command.Parameters.AddWithValue("@Value2", lastName);
        command.Parameters.AddWithValue("@Value3", email);
        command.Parameters.Add("4");// by default user is on player permission, so 4
        command.Parameters.Add("1");// by default user is on player role, so 1
        command.Parameters.AddWithValue("@Value4", create_time);
        command.Parameters.AddWithValue("@Value5", password);// have to read up on how to hash it before reading it in

        // Execute the query
        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();
    }

    public void EditUser(string UID, string UpdateInput, string UpdateValue)
    {
        string sqlQuery = @$"UPDATE users
        SET {UpdateInput} = @UpdateValue
        WHERE UID = @UID";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.Parameters.AddWithValue("UpdateValue", UpdateValue);
        command.Parameters.AddWithValue("UID", UID);

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();

    }

    public void DeleteUser(string UID)
    {
        string sqlQuery = @"DELETE FROM users
        WHERE UID = @UID";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.Parameters.AddWithValue("@UID", UID);

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();

    }

    public string[] GetSingleUser(string UID)
    {
        string sqlQuery = @"SELECT * FROM users
        WHERE UID = @UID";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.Parameters.AddWithValue("@UID", UID);

        string[] userinfo = new string[7];
        try
        {
            using (var reader = command.ExecuteReader())
            {
                int index = 0;
                while (reader.Read() && index < userinfo.Length)
                {
                    //save user information in array
                    userinfo[index] = reader.GetString(index);
                    index++;
                }
            }
        }
        finally
        {
            command.Dispose();
            Disconnect();
        }
        return userinfo;
    }

    //Form methods (not implemented yet)
    public void CreateForm()
    {
        //Insert Into the database the information of the form

    }

    //Picture methods (works)

    public void CreatePicture(string PictureID, string PicturePath, string AltText, string Author, string UploadTime)
    {
        string sqlQuery = @"INSERT INTO
            pictures (pictureID, picturepath, altText, author, upload_time)
            VALUES (@Value0, @Value1, @Value2, @Value3, @Value4)";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.Parameters.AddWithValue("@Value0", PictureID);
        command.Parameters.AddWithValue("@Value1", PicturePath);
        command.Parameters.AddWithValue("@Value2", AltText);
        command.Parameters.AddWithValue("@Value3", Author);
        command.Parameters.AddWithValue("@Value4", UploadTime);

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();
    }

    public void EditPicture(string PictureID, string UpdateInput, string UpdateValue)
    {
        //edit the information of the picture, like for example the alt text or author
        string sqlQuery = @$"UPDATE pictures
        SET {UpdateInput} = @UpdateValue
        WHERE pictureID = {PictureID}";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.Parameters.AddWithValue("@UpdateValue", UpdateValue);

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();
    }

    public void DeletePicture(string PictureID)
    {
        string sqlQuery = @$"DELETE FROM pictures
        WHERE pictureID = {PictureID}";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();
    }

    public void GetSinglePicture(string PictureID)
    {
        string sqlQuery = @$"SELECT * FROM pictures
        WHERE pictureID = {PictureID}";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        string[] pictureinfo = new string[5];
        try
        {
            using (var reader = command.ExecuteReader())
            {
                int index = 0;
                while (reader.Read() && index < pictureinfo.Length)
                {
                    pictureinfo[index] = reader.GetString(index);
                    index++;
                }
            }
        }
        finally
        {
            command.Dispose();
            Disconnect();
        }
    }

    public void GetAllPictures(int amount)
    {
        //get all the pictures from the database
        string sqlQuery = @$"SELECT * FROM pictures LIMIT {amount}";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        string[] pictures = new string[amount];
        try
        {
            using (var reader = command.ExecuteReader())
            {
                int index = 0;
                while (reader.Read() && index < amount)
                {
                    pictures[index] = reader.GetString(index);
                    index++;
                }
            }
        }
        finally
        {
            command.Dispose();
            Disconnect();
        }

    }

    public string[] FetchPicturesCarousel()
    {
        string sqlQuery = @"SELECT image_path FROM pictures
                        WHERE carousel = 1
                        ORDER BY RAND()
                        LIMIT 5";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        //take the image paths and put them in an array
        string[] paths = new string[5];
        try
        {
            using (var reader = command.ExecuteReader())
            {
                int index = 0;
                while (reader.Read() && index < 5)
                {
                    //paths[index] = reader["image_path"].ToString(); where image_path is the name of the column in the database
                    paths[index] = reader.GetString(0);
                    index++;
                }
            }
        }
        finally
        {
            command.Dispose();
            Disconnect();
        }

        return paths;
    }
}