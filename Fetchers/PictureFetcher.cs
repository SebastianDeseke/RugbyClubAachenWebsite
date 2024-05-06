using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using RugbyClubAachenWeb.Database;

namespace RugbyClubAachenWeb.Fetchers;

    public class PictureFetcher
    {
        public string Picture { get; set; }
        public string[] Pictures { get; set; }
        private readonly DbConnections _db;
        private readonly IConfiguration _config;

        public PictureFetcher(DbConnections db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public void GetAllPictures(int amount)
        {
            if (amount >= 500 || amount <= 0)
            {
                Console.WriteLine("Invalid amount of pictures requested");
                return;
            }
            _db.GetAllPictures(amount);
            Console.WriteLine("All pictures are loaded");
        }

        public void GetSinglePicture (string PictureID)
        {
            _db.GetSinglePicture(PictureID);
            Console.WriteLine("Picture is loaded");
        }

        public void showPictureCarousel(int i)
        {
            string[] tmp = _db.FetchPicturesCarousel();
            return tmp[i];
            Console.WriteLine("Carousel pictures are loaded");
        }

    }