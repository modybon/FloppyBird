using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FloppyBird
{
    public partial class GamePage : ContentPage
    {
        private bool _isAnimating;
        public GamePage()
        {
            InitializeComponent();
            objectImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.pokeball.png");
        }

        void jumpButton_Clicked(System.Object sender, System.EventArgs e)
        {
            // increases size
            //objectImage.RelScaleTo(2, 500);
            //objectImage.RelRotateTo(360, 100);
            //objectImage.FadeTo(0, 1000000);
            Jump();
        }

        async Task Jump()
        {

            //await objectImage.TranslateTo(0, objectImage.TranslationY - 50, 1000);
            if (!_isAnimating)
            {
                //_isAnimating = true;
                //await objectImage.TranslateTo(0, objectImage.TranslationY - 100,350);
                //await objectImage.RelRotateTo(60);
                //await objectImage.TranslateTo(0, objectImage.TranslationY + 100, 300);
                //_isAnimating = false;
                //await objectImage.RelRotateTo(120);
                new Animation
                {
                      { 0, 0.25, new Animation (v => objectImage.TranslationY = v, 0, -40) },
                      { 0.25, .5, new Animation (v => objectImage.TranslationY = v, -40, 0, easing: Easing.BounceOut) }
                    }
                    .Commit(this, "AppleIconBounceChildAnimations", length: 1000, repeat: () => false);
            }
        }
    }
}

//if (!_isAnimating)
//{
//    _isAnimating = true;

//    new Animation {
//  { 0, 0.25, new Animation (v => objectImage.TranslationY = v, 0, -40) },
//  { 0.25, .5, new Animation (v => objectImage.TranslationY = v, -40, 0, easing: Easing.BounceOut) }
//}
//.Commit(this, "AppleIconBounceChildAnimations", length: 1000, repeat: () => true);
//}