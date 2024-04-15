using MySql.Data.MySqlClient;

namespace RugbyClubAachenWeb.Database;

public class DbConnections
{

    MySqlConnection connection { get; set; }

    public DbConnections()
    {

    }

    public void Connect()
    {
        connection = new MySqlConnection("server=localhost;user id=root;password=;database=rca_db,port=3306");
        // Open the connection
        connection.Open();
    }

    public void Disconnect()
    {
        // Close the connection
        connection.Close();
    }


    public void CreateUser(string UID, string username, string name, string surname, string Email, string create_time, string password)
    {
        string sqlQuery = @"INSERT INTO 
        users (UID, username, name, surname, Email, create_time, password)
        VALUES (@Value0, @Value1, @Value2, @Value3, @Value4, @Value5, @Value6)";

        // Set up a command object with your SQL query and connection
        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        // Set the parameter values for your query
        command.Parameters.AddWithValue("@Value0", UID);
        command.Parameters.AddWithValue("@Value1", username);
        command.Parameters.AddWithValue("@Value2", name);
        command.Parameters.AddWithValue("@Value3", surname);
        command.Parameters.AddWithValue("@Value4", Email);
        command.Parameters.AddWithValue("@Value5", create_time);
        command.Parameters.AddWithValue("@Value6", password);

        // Execute the query
        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();
    }

    public void EditUser(string UID, string username, string UpdateInput, string UpdateValue)
    {
        string sqlQuery = @$"UPDATE users
        SET {UpdateInput} = {UpdateValue}
        WHERE UID = @UID";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

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

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();

    }

    public void GetUser(string UID)
    {
        string sqlQuery = @"SELECT * FROM users
        WHERE UID = @UID";

        Connect();
        MySqlCommand command = new MySqlCommand(sqlQuery, connection);

        command.ExecuteNonQuery();
        command.Dispose();
        Disconnect();

    }

    public void UploadForm(){

    }

        public void CreatePicture() {

    }

    public void EditPicture() {
        //edit the information of the picture, like for example the alt text or author

    }

    public void DeletePicture() {

    }

    public void GetAllPictures() {
        //get all the pictures from the database

    }

    public void FetchPicturesCarousel() {

    }
}