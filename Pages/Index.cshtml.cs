using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RugbyClubAachenWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public object getLanguage () {
        string acceptLanguage = Request.Headers["Accept-Language"];
        string[] languages = acceptLanguage.Split(',');

        for (int i = 0; i < languages.Length; i++)
        {
            if (languages[0].Contains("*")){
                ViewData["Language"] = "en";
                continue;
            } else if (languages[i].Contains("de")) {
                ViewData["Language"] = "de";
                break;
            } else if (languages[i].Contains("en")) {
                ViewData["Language"] = "en";
                break;
            }
        }

        return ViewData["Language"];
    }

    public void OnGet()
    {
        getLanguage();
    }
}
