using System.Xml;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;

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
        connection.Open();
    }

    public void Disconnect()
    {
        connection.Close();
    }

    //User methods
    public void CreateUser(string username, string firstName, string lastName, string email, string create_time, string password)
    {
        string sqlQuery = @"INSERT INTO 
        users (username, firstname, lastName, email, permission, roleId, signupDate, password)
        VALUES (@username, @firstname, @lastname, @email, @permission, @create_time, @roleId, @password)";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@firstname", firstName);
        command.Parameters.AddWithValue("@lastname", lastName);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.Add("4");// by default user is on player permission, so 4
        command.Parameters.Add("1");// by default user is on player role, so 1
        command.Parameters.AddWithValue("@create_time", create_time);
        command.Parameters.AddWithValue("@password", password);

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();
    }

    public void EditUser(string username, string UpdateInput, string UpdateValue)
    {
        int UID = GetUserID(username);
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

    public int GetUserID(string username)
    {
        string sqlQuery = @"SELECT UID 
                            FROM users
                            WHERE username = @username";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.Parameters.AddWithValue("@username", username);

        int UID = -1;
        try
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    UID = reader.GetInt32(0);
                }
            }
        }
        finally
        {
            command.Dispose();
            Disconnect();
        }
        return UID;
    }

    public string[] GetUserInfo(int UID)
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
    public void CreateForm(string username, string[] FormFilled)
    {
        int UID = GetUserID(username);
        string sqlQuery = @"INSERT INTO 
                            forms (UID, statusId, firstName, middelName, lastName, email, telephone, birthDate, sex, nationality, datenschutz, SEPA, u18, street, housenr, zip, city, land)
                            VALUES (@UID, @statusId, @firstName, @middelName, @lastName, @email, @telephone, @birthDate, @sex, @nationality, @datenschutz, @SEPA, @u18, @street, @housnr, @zip, @city, @land)";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.Parameters.AddWithValue("UID", UID);
        command.Parameters.AddWithValue("@statusId", 1);//by default the status is 1, which means that the form is not yet processed
        command.Parameters.AddWithValue("@firstName", FormFilled[0]);
        command.Parameters.AddWithValue("@middelName", FormFilled[1]);
        command.Parameters.AddWithValue("@lastName", FormFilled[2]);
        command.Parameters.AddWithValue("@email", FormFilled[3]);
        command.Parameters.AddWithValue("@telephone", FormFilled[4]);
        command.Parameters.AddWithValue("@birthDate", FormFilled[5]);
        command.Parameters.AddWithValue("@sex", FormFilled[6]);
        command.Parameters.AddWithValue("@nationality", FormFilled[7]);
        command.Parameters.AddWithValue("@datenschutz", FormFilled[8]);
        command.Parameters.AddWithValue("@SEPA", FormFilled[9]);
        command.Parameters.AddWithValue("@u18", FormFilled[10]);
        command.Parameters.AddWithValue("@street", FormFilled[11]);
        command.Parameters.AddWithValue("@housnr", FormFilled[12]);
        command.Parameters.AddWithValue("@zip", FormFilled[13]);
        command.Parameters.AddWithValue("@city", FormFilled[14]);
        command.Parameters.AddWithValue("@land", FormFilled[15]);

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();
    }

    //Picture methods (works)
    public void CreatePicture(string PictureID, string PicturePath, string AltText, string Author, string UploadTime)
    {
        string sqlQuery = @"INSERT INTO
            pictures (pictureID, picturepath, altText, author, upload_time)
            VALUES (@pictureID, @picturepath, @altText, @author, @upload_time)";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.Parameters.AddWithValue("@pictureID", PictureID);
        command.Parameters.AddWithValue("@picturepath", PicturePath);
        command.Parameters.AddWithValue("@altText", AltText);
        command.Parameters.AddWithValue("@author", Author);
        command.Parameters.AddWithValue("@upload_time", UploadTime);

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

    //Tutuorial methods (not implemented yet)
    public void CreateTutorial(int uniqueId, int positionWiki, string positionName, string docrefs, string videoLink, string imagePath)
    {
        //positionWiki = position that the wiki is about, 1 - 15, with 16 being general for all positions
        string sqlQuery = @"INSERT INTO
            tutorial (uniqueId, positionWiki, positionName, docrefs, videoLink, imagePath)
            VALUES (@uniqueId, @positionWiki, @positionName, @docrefs, @videoLink, @imagePath)";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.Parameters.AddWithValue("@uniqueId", uniqueId);
        command.Parameters.AddWithValue("@positionWiki", positionWiki);
        command.Parameters.AddWithValue("@positionName", positionName);
        command.Parameters.AddWithValue("@docrefs", docrefs);
        command.Parameters.AddWithValue("@videoLink", videoLink);
        command.Parameters.AddWithValue("@imagePath", imagePath);

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();
    }

    public void EditTutorial(int uniqueId, string UpdateInput, string UpdateValue)
    {
        string sqlQuery = @$"UPDATE tutorial
        SET {UpdateInput} = @UpdateValue
        WHERE uniqueId = {uniqueId}";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.Parameters.AddWithValue("@UpdateValue", UpdateValue);

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();
    }

    public void DeleteTutorial(int uniqueId)
    {
        string sqlQuery = @$"DELETE FROM tutorial
        WHERE uniqueId = {uniqueId}";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();
    }

    public string[] GetTutorial(int uniqueId)
    {
        string sqlQuery = @$"SELECT * FROM tutorial
        WHERE uniqueId = {uniqueId}";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        string[] tutorialinfo = new string[6];
        try
        {
            using (var reader = command.ExecuteReader())
            {
                int index = 0;
                while (reader.Read() && index < tutorialinfo.Length)
                {
                    tutorialinfo[index] = reader.GetString(index);
                }
            }
        }
        finally
        {
            command.Dispose();
            Disconnect();
        }
        return tutorialinfo;
    }

    //permissions methods (not implemented yet)
    public string[] GetPermissions(int permissionId)
    {
        string sqlQuery = @$"SELECT * FROM permissions
        WHERE permissionId = {permissionId}";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        string[] permissions = new string[8];
        try
        {
            using (var reader = command.ExecuteReader())
            {
                int index = 0;
                while (reader.Read() && index < permissions.Length)
                {
                    permissions[index] = reader.GetString(index);
                    index++;
                }
            }
        }
        finally
        {
            command.Dispose();
            Disconnect();
        }
        return permissions;
    }

    public void ChangeUserPermission (int userId, int newPermission) {
        string sqlQuery = @$"UPDATE users
                        SET permission = @newPermission
                        WHERE UID = {userId}";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

       command.Parameters.AddWithValue("@newPermission", newPermission);

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();
    }

    //roles methods (not implemented yet)
    public string[] GetRole (int roleId) {
        string sqlQuery = @$"SELECT * FROM roles
                        WHERE roleId = {roleId}";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        string[] roleinfo = new string[8];
        try
        {
            using (var reader = command.ExecuteReader())
            {
                int index = 0;
                while (reader.Read() && index < roleinfo.Length)
                {
                    roleinfo[index] = reader.GetString(index);
                    index++;
                }
            }
        }
        finally
        {
            command.Dispose();
            Disconnect();
        }
        return roleinfo;
    }

    public void CreateRole (int roleId,string roleName, string roleDescription) {
        string sqlQuery = @"INSERT INTO
                        roles (roleId, roleName, roleDescription)
                        VALUES (@roleId, @roleName, @roleDescription)";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.Parameters.AddWithValue("@roleId", roleId);
        command.Parameters.AddWithValue("@roleName", roleName);
        command.Parameters.AddWithValue("@roleDescription", roleDescription);

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();
    }

    public void ChangeUserRole (int userId, int newRole) {
        string sqlQuery = @$"UPDATE users
                        SET roleId = @newRole
                        WHERE UID = {userId}";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

       command.Parameters.AddWithValue("@newRole", newRole);

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();
    }
}