
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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

    public string CreateBody()
    {
        /*This is the body of the email that will be sent to the user by combining all 
        the anwsers and making a cohesive email that can be sent to the respective parties, 
        vor example the insurance and the Dutch rugby union*/
        return "This is the body of the email, test";
    }

    /* I will have to make a que or a buffer, to prevent more than 10 emails to be sent at once.
    This will ensure that we negate the oppertunity to hack the smtp service*/
    public void SendEmail(string email, string fullName)
    {
        // Pdf files that are needed to register for the club
        string file = $"~/files/{fullName}Anmeldung.pdf";
        string file2 = $"~/files/{fullName}Einwilligung.pdf";
        Attachment attachment = new (file, MediaTypeNames.Application.Octet);
        Attachment attachment2 = new (file2, MediaTypeNames.Application.Octet);
        MailMessage mail = new (_config["Smtp:Sender"], email);
        SmtpClient client = new (_config["Smtp:Host"], int.Parse(_config["Smtp:Port"]))
        {
            Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"]),
            EnableSsl = true
        };
    }
}