using System;
using System.Collections.Generic;
using FloppyBird.Models;
using Xamarin.Forms;

namespace FloppyBird
{
    public partial class GameMenuPage : ContentPage
    {
        private Player _player;
        public GameMenuPage()
        {
            InitializeComponent();
            _player = new Player();
            settingsImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Icons.settings.png");
            shopImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Icons.shop.png");
            ranksImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Icons.competition.png");
            playerChoosenSkin.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Skins.pokeball.png");
            backgroundImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Backgrounds.bg001.png");
        }

        void NextSkinBtnClicked(System.Object sender, System.EventArgs e)
        {

        }

        void PreviousSkinBtnClicked(System.Object sender, System.EventArgs e)
        {

        }

        void PreviousBackgroundBtnClicked(System.Object sender, System.EventArgs e)
        {
        }

        void NextBackgroundBtnClicked(System.Object sender, System.EventArgs e)
        {
        }

        void ShopImageClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ShopPage());
        }

        void RanksImageClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RanksPage());
        }
    }
}
