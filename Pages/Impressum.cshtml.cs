using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RugbyClubAachenWeb.Database;
using System.IO;
using System.Threading.Tasks;

namespace RugbyClubAachenWeb.Pages;
    public class ImpressumModel : PageModel
    {

        private readonly ILogger<ImpressumModel> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly DbConnections _db;

        public ImpressumModel(IWebHostEnvironment env, DbConnections db, ILogger<ImpressumModel> logger)
        {
            _logger = logger;
            _env = env;
            _db = db;
        }

    }