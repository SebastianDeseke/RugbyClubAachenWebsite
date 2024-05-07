using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using RugbyClubAachenWeb.Database;

namespace RugbyClubAachenWeb.Fetchers;

public class UserFetcher
{
    public string User { get; set; }
    public string[] Users { get; set; }
    private readonly DbConnections _db;
    private readonly IConfiguration _config;

    public UserFetcher(DbConnections db, IConfiguration config)
    {
        _db = db;
        _config = config;
    }

    public void GetAllUsers()
    {
        Console.WriteLine("Users are loaded");
    }

    public void GetSingleUser(string UID)
    {
        _db.GetSingleUser(UID);
        Console.WriteLine("User is loaded");
    }

    public void EditUser(string UID, string UpdateInput, string UpdateValue) {
        _db.EditUser(UID, UpdateInput, UpdateValue);
        Console.WriteLine("User is edited");
    }
}