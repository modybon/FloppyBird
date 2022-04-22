using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FloppyBird.Models
{
    public static class BackgroundsRepository
    {
        //public ImageSource CurrentBackground = ImageSource.FromResource("FloppyBird.Assets.Images.Backgrounds.bg.png");
        //private List<ImageSource> _backgroundsList = new List<ImageSource>();

        public static List<ShopItem> BackgroundsList
        {
            get
            {
                return _backgroundsList;
            }
        }

        private static List<ShopItem> _backgroundsList = new List<ShopItem>
        {
            new ShopItem
                {
                    Title = "DefaultBackground",
                    Cost = 0,
                    Image = "https://static.vecteezy.com/system/resources/previews/004/810/979/original/cloud-landscape-green-mountain-outdoor-with-blue-sky-background-vector.jpg"
                },
        };

        static BackgroundsRepository()
        {
        }

        //public void PopulateBackgrounds()
        //{

        //}

       
        

        public static void AddBackgrounds(ShopItem background)
        {
            BackgroundsList.Add(background);
        }


    }
}
