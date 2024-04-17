using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RugbyClubAachenWeb.Pages;

    public class NewsModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        public NewsModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        
        public void OnGet()
        {
        }
    }
