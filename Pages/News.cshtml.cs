using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RugbyClubAachenWeb.Pages;

    public class NewsModel : PageModel
    {

        private readonly ILogger<NewsModel> _logger;
        private String Title {set; get;}
        private String Content {set; get;}
        private String ImagePath {set; get;}
        private String Date {set; get;}
        private String Author; //UserFetcher?

        public NewsModel(ILogger<NewsModel> logger)
        {
            _logger = logger;
        }

        public void RetrieveNews(){
            //TODO: Retrieve news from database, but only the first 5
        }
        
        public void OnGet()
        {
        }
    }
