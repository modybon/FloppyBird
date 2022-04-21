using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FloppyBird
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
            testImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Skins.pokeball.png");
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            testImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Skins.baseball.png");
        }
    }
}
