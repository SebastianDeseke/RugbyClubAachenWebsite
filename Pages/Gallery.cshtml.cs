using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RugbyClubAachenWeb.Database;
using System.IO;
using System.Threading.Tasks;

namespace RugbyClubAachenWeb.Pages;

public class GalleryModel : PageModel
{

    private readonly ILogger<GalleryModel> _logger;
    private readonly IWebHostEnvironment _env;
    private readonly DbConnections _db;
    public GalleryModel(IWebHostEnvironment env, DbConnections db)
    {
        _env = env;
        _db = db;
    }


    //     public GalleryModel(ILogger<GalleryModel> logger)
    // {
    //     _logger = logger;
    // }

    public string FileNameGenerator()
    {
        string fullpath;
        string filename;
        do
        {
            filename = Guid.NewGuid().ToString();
            fullpath = Path.Combine(_env.ContentRootPath, "uploads", filename);
        } while (System.IO.File.Exists(fullpath));
        return filename;
    }

    [BindProperty]
    public IFormFile Upload { get; set; }
    public async Task OnPostUploadAsync()
    {
        var file = Path.Combine(_env.ContentRootPath, "uploads", FileNameGenerator());
        using (var fileStream = new FileStream(file, FileMode.Create))
        {
            await Upload.CopyToAsync(fileStream);
        }
    }

    public void OnGet()
    {
    }
}
