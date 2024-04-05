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

    public void CarouselPicturePath (){
        
    }

    public void AllPicturesPath (){

    }

    /*
    public void CreateCustomer(string KundenId, string Title, string Vorname, string Nachname, string Firmenname, string Adresse, string Postleizahl, string Telefonnummer, string Email, string Umsatzsteuernummer, int preisKategorie){
    string sqlQuery = @"INSERT INTO 
    kundendaten (KundenID, AnsprechTitle, AnsprechVorname, AnsprechNachname, Firmenname, Adresse, Postleizahl, Telefonnummer, Email, Umsatzsteuernummer, PreisKategorie)
    VALUES (@Value0, @Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7, @Value8, @Value9, @Value10)";

    // Set up a command object with your SQL query and connection
    Connect();
    MySqlCommand command = new MySqlCommand(sqlQuery, connection);

    // Set the parameter values for your query
    command.Parameters.AddWithValue("@Value0", KundenId);
    command.Parameters.AddWithValue("@Value1", Title);
    command.Parameters.AddWithValue("@Value2", Vorname);
    command.Parameters.AddWithValue("@Value3", Nachname);
    command.Parameters.AddWithValue("@Value4", Firmenname);
    command.Parameters.AddWithValue("@Value5", Adresse);
    command.Parameters.AddWithValue("@Value6", Postleizahl);
    command.Parameters.AddWithValue("@Value7", Telefonnummer);
    command.Parameters.AddWithValue("@Value8", Email);
    command.Parameters.AddWithValue("@Value9", Umsatzsteuernummer);
    command.Parameters.AddWithValue("@Value10", preisKategorie);

    // Execute the query
    command.ExecuteNonQuery();
    command.Dispose();
    Disconnect();
}*/

}

