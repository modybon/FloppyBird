using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FloppyBird.Models
{
    public static class SkinsRepository
    {
        //public static ImageSource DefaultSkin = ImageSource.FromResource("FloppyBird.Assets.Images.Skins.pokeball.png");
        //private static List<ImageSource> _skinsList = new List<ImageSource>();
        //public static List<ImageSource> SkinsList
        //{
        //    get
        //    {
        //        return _skinsList;
        //    }
        //}

        //author: Ryan

        private static List<ShopItem> _skinsList = new List<ShopItem>
        {
            new ShopItem
                {
                    Title = "Pokeball",
                    Cost = 0,
                    Image = "https://pngimg.com/uploads/pokeball/pokeball_PNG30.png"
                },
        };


        public static List<ShopItem> SkinsList
        {
            get
            {
                return _skinsList;
            }
        }

        static SkinsRepository()
        {
        }

        //public void PopulateSkins()
        //{

        //}

        public static void AddSkin(ShopItem skin)
        {
            _skinsList.Add(skin);
        }
    }
}
