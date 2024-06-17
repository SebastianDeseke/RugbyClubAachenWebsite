using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RugbyClubAachenWeb.Database;

namespace RugbyClubAachenWeb.Pages;

public class DownloadsModel : PageModel
{
    private readonly ILogger<DownloadsModel> _logger;
    private readonly IWebHostEnvironment _env;
    private readonly DbConnections _db;

    public DownloadsModel(IWebHostEnvironment env, DbConnections db, ILogger<DownloadsModel> logger)
    {
        _logger = logger;
        _env = env;
        _db = db;
    }

    public void OnPost (){
        
    }

    public void OnGet()
    {
        
    }
}