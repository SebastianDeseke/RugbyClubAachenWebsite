using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using RugbyClubAachenWeb.Database;

namespace RugbyClubAachenWeb.Fetchers;

public class UserFetcher
{
    private readonly PasswordHasher<UserFetcher> _passwordHasher;
    public string User { get; set; }
    public string[] Users { get; set; }
    private readonly DbConnections _db;
    private readonly IConfiguration _config;

    public UserFetcher(DbConnections db, IConfiguration config, PasswordHasher<UserFetcher> passwordHasher)
    {
        _db = db;
        _config = config;
        _passwordHasher = passwordHasher;
    }
    
    public void GetAllUsers()
    {
        Console.WriteLine("Users are loaded");
    }

    public void GetSingleUserInfo(string username)
    {
        int UID =_db.GetUserID(username);
        _db.GetUserInfo(UID);
        Console.WriteLine("User is loaded");
    }

    public void EditUser(string username, string UpdateInput, string UpdateValue)
    {
        _db.EditUser(username, UpdateInput, UpdateValue);
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
        string checkedPassword = _passwordHasher.HashPassword(this, password);
    }

    public void CreateUser(string usernmae, string firstname, string lastname, string? email, string password)
    {
        PasswordCheck(password);
        var hashedPass = _passwordHasher.HashPassword(this, password);
        var create_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _db.CreateUser(usernmae, firstname, lastname, email, create_time, hashedPass);
        Console.WriteLine("User is created");
    }
}