using System;
using System.Collections.Generic;
using FloppyBird.Models;
using Xamarin.Forms;

namespace FloppyBird
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();
            backgroundImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Backgrounds.bg.png");
        }

        void PlayBtnClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new GameMenuPage(Player.PLayerCoins)) ;
        }

        void LogInBtnClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LogInPage());
        }
    }
}
