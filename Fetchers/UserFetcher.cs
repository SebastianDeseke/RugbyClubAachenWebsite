using System.Text.RegularExpressions;
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

    public void EditUser(string UID, string UpdateInput, string UpdateValue)
    {
        _db.EditUser(UID, UpdateInput, UpdateValue);
        Console.WriteLine("User is edited");
    }

    public void PasswordCheck(string password)
    {
        //https://uibakery.io/regex-library/password-regex-csharp
        Regex rgx = new Regex ("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,15}$");
        if (rgx.IsMatch(password)){
            Console.WriteLine("Password is valid");

        } else {
            Console.WriteLine("Password is invalid");
        }
    }

    public void CreateUser()
    {
        var create_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Console.WriteLine("User is created");
    }
}