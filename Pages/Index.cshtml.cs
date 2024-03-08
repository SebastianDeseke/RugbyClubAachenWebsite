using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RugbyClubAachenWeb.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace RugbyClubAachenWeb;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    LanguageController lg = new LanguageController();

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
        lg.getLanguage(Request);
        lg.SetLanguage((string)ViewData["Language"]);
    }
}
