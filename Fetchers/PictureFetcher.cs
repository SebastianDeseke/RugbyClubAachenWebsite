using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using RugbyClubAachenWeb.Database;

namespace RugbyClubAachenWeb.Fetchers;

    public class PictureFetcher
    {
<<<<<<< HEAD
        private string[] AllPictures;
        public string[] CarouselPictures = new string[5];
        public void getCarouselPictures()
        {
            /*
            DbConnections method to fetch the pictures path from the database
            the method will return a string array with the path of the pictures
            of size 5 as well. Then all I have to do is put position 0 in CarouselPictures[0]
            */

            for (int i = 0; i < CarouselPictures.Length; i++)
            {
                //enter the path form the database to the array
            }

            //Method should return the array with the pictures path
            Console.WriteLine("Pictures are loaded");
        }

        public void getAllPictures()
        {
            /*
            DbConnections method to fetch the pictures path from the database
            the method will return a string array with the path of the pictures
            of size 5 as well. Then all I have to do is put position 0 in AllPictures[0]
            */

            for (int i = 0; i < AllPictures.Length; i++)
            {
                //enter the path form the database to the array
            }

            Console.WriteLine("Pictures are loaded");
=======
        public string Picture { get; set; }
        public string[] Pictures { get; set; }
        DbConnections db = new DbConnections();

        public void GetAllPictures()
        {
            db.GetAllPictures();
            Console.WriteLine("All pictures are loaded");
>>>>>>> f743f7fafa505abaed422ebe2318514e5d0446a7
        }

        public void GetSinglePicture (string PictureID)
        {
            db.GetSinglePicture(PictureID);
            Console.WriteLine("Picture is loaded");
        }

    }