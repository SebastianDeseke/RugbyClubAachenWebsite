using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RugbyClubAachenWeb.Database;
using RugbyClubAachenWeb.Fetchers;

namespace RugbyClubAachenWeb.Pages;

public class SignUpModel : PageModel
{
    private readonly ILogger<SignUpModel> _logger;
    private readonly IWebHostEnvironment _env;
    private readonly DbConnections _db;
    //form field variables
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string email { get; set; }
    public string username { get; set; }
    public string phonenumber { get; set; }
    public string address { get; set; }
    public string zipcode { get; set; }
    public string city { get; set; }
    public string country { get; set; }
    public string password { get; set; }

    UserFetcher userFetcher;


    public SignUpModel(IWebHostEnvironment env, DbConnections db, ILogger<SignUpModel> logger)
    {
        _logger = logger;
        _env = env;
        _db = db;
    }

    public void senEmail(string email)
    {

    }

    public string FileNameGenerator()
    {
        return firstname + lastname + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
    }

    [BindProperty]
    public IFormFile UploadFile { get; set; }
    public async Task OnPostUploadAsync()
    {
        // to send the data to the database and use the User Fetcher to create a new user for the form
        var file = Path.Combine("~/files", FileNameGenerator());
        using (var fileStream = new FileStream(file, FileMode.Create))
        {
            await UploadFile.CopyToAsync(fileStream);
        }

    }

    public void OnGet()
    {
        ViewData["ShowCarousel"] = false;
    }
}