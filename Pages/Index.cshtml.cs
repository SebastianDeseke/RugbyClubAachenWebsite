using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace RugbyClubAachenWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

        private object getLanguage(HttpRequest request)
    {
        string acceptLanguage = request.Headers["Accept-Language"];
        string[] languages = acceptLanguage.Split(',');

        for (int i = 0; i < languages.Length; i++)
        {
            if (languages[0].Contains("*"))
            {
                return "en";
            }
            else if (languages[i].Contains("de"))
            {
                return "de";
            }
            else if (languages[i].Contains("en"))
            {
                return "en";
            }
        }

        return "en";
    }

    public IActionResult getLocalLanguage (string language) {

        Console.WriteLine(HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.Name);
        string acceptLanguage = Request.Headers["Accept-Language"];
        string[] languages = acceptLanguage.Split(',');

        for (int i = 0; i < languages.Length; i++)
        {
            if (languages[0].Contains("*")){
                ViewData["Language"] = "en";
                break;
            } else if (languages[0].Contains("de")) {
                ViewData["Language"] = "de";
                break;
            } else if (languages[0].Contains("en")) {
                ViewData["Language"] = "en";
                break;
            }
        }

        return new OkObjectResult("The Language is " + ViewData["Language"]);
    }
    
    public void OnGet () {
        
    }

}
