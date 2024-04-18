using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;

namespace RugbyClubAachenWeb.Pages;

public class GalleryModel : PageModel
{

    private readonly ILogger<IndexModel> _logger;
    private readonly IWebHostEnvironment _env;
    public GalleryModel (IWebHostEnvironment env)
    {
        _env = env;
    }

    [BindProperty]
    public IFormFile Upload { get; set; }
    public async Task OnPostasync()
    {
        var file = Path.Combine(_env.ContentRootPath, "uploads", Upload.FileName);
        using (var fileStream = new FileStream(file, FileMode.Create))
        {
            await Upload.CopyToAsync(fileStream);
        }
    }
    public GalleryModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }



    public void OnGet()
    {
    }
}
