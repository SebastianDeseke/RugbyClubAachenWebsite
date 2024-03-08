using Microsoft.AspNetCore.Mvc;

namespace RugbyClubAachenWeb.Controllers;
public class LanguageController : Controller
{
    public object getLanguage(HttpRequest request)
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

    [HttpPost]
    public IActionResult SetLanguage(string language)
    {
        if (language == "de")
        {
            Console.Write("Language has been set to German");
        }
        else if (language == "en")
        {
            Console.Write("Language has been set to English");
        }

        var response = new { message = "The language will be set" };
        return new JsonResult(response);
    }
}