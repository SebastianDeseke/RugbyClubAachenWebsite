using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using RugbyClubAachenWeb.Database;

namespace RugbyClubAachenWeb.Fetchers;

public class UserFetcher
{
    public string User { get; set; }
    public string[] Users { get; set; }
    DbConnections db = new DbConnections();

    public void GetAllUsers()
    {
        Console.WriteLine("Users are loaded");
    }

    public void GetSingleUser(string UID)
    {
        db.GetSingleUser(UID);
        Console.WriteLine("User is loaded");
    }

    public void EditUser() {
        db.EditUser();
        Console.WriteLine("User is edited");
    }
}