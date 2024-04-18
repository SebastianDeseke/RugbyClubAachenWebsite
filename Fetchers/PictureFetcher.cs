using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using RugbyClubAachenWeb.Database;

namespace RugbyClubAachenWeb.Fetchers;

    public class PictureFetcher
    {
        public string Picture { get; set; }
        public string[] Pictures { get; set; }
        DbConnections db = new DbConnections();

        public void GetAllPictures()
        {
            db.GetAllPictures();
            Console.WriteLine("All pictures are loaded");
        }

        public void GetSinglePicture (string PictureID)
        {
            db.GetSinglePicture(PictureID);
            Console.WriteLine("Picture is loaded");
        }

    }