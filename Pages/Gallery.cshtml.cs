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
    //PictureFetcher pictureFetcher = new PictureFetcher();


    public GalleryModel(IWebHostEnvironment env, DbConnections db, ILogger<GalleryModel> logger)
    {
        _logger = logger;
        _env = env;
        _db = db;
    }

    public string FileNameGenerator()
    {
        string fullpath;
        string filename;
        do
        {
            filename = Guid.NewGuid().ToString();
            fullpath = Path.Combine(_env.ContentRootPath, "images", filename);
        } while (System.IO.File.Exists(fullpath));
        return filename;
    }

    [BindProperty]
    public IFormFile Upload { get; set; }
    public async Task OnPostUploadAsync()
    {
        var file = Path.Combine(_env.ContentRootPath, "images", FileNameGenerator());
        using (var fileStream = new FileStream(file, FileMode.Create))
        {
            await Upload.CopyToAsync(fileStream);
        }
    }

   /* public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> Upload)
    {
        foreach (var formFile in Upload)
        {
            if (formFile.ContentType.ToLower() != "image/jpeg" && formFile.ContentType.ToLower() != "image/png")
            {
                ModelState.AddModelError("Upload", "Only JPEG and PNG files are allowed.");
                return Page();
            }

            // Rest of the file processing code...
        }

        return RedirectToPage("./Index");
    } */

    public void OnGet()
    {
    }
}
