using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FloppyBird.Models
{
    public class BackgroundsRepository
    {
        public ImageSource DefaultBackground = ImageSource.FromResource("FloppyBird.Assets.Images.Skins.pokeball.png");
        private List<ImageSource> _backgroundsList = new List<ImageSource>();
        public List<ImageSource> BackgroundsList
        {
            get
            {
                return _backgroundsList;
            }
        }

        public BackgroundsRepository()
        {
        }

        //public void PopulateBackgrounds()
        //{

        //}

        public void AddBackgrounds()
        {

        }


    }
}
