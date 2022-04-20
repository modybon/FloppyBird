using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FloppyBird.Models
{
    public class SkinsRepository
    {
        public ImageSource DefaultSkin = ImageSource.FromResource("FloppyBird.Assets.Images.Skins.pokeball.png");
        private List<ImageSource> _skinsList = new List<ImageSource>();
        public List<ImageSource> SkinsList
        {
            get
            {
                return _skinsList;
            }
        }
        public SkinsRepository()
        {
        }

        //public void PopulateSkins()
        //{

        //}

        public void AddSkin()
        {

        }
    }
}
