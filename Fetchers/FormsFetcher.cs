
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using RugbyClubAachenWeb.Database;

namespace RugbyClubAachenWeb.Fetchers;

public class FormsFetcher
{
    private readonly DbConnections _db;
    private readonly IConfiguration _config;

    public FormsFetcher(DbConnections db, IConfiguration config)
    {
        _db = db;
        _config = config;
    }

    public void GetAllForms()
    {
        Console.WriteLine("Forms are loaded");
    }

    /* I will have to make a que or a buffer, to prevent more than 10 emails to be sent at once.
This will ensure that we negate the oppertunity to hack the smtp service*/
    public void SendEmail(string email, string fullName)
    {
        // Pdf files that are needed to register for the club

        string file = $"~/files/{fullName}Anmeldung.pdf";
    }
}