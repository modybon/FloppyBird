using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FloppyBird
{
    public partial class GameMenuPage : ContentPage
    {
        public GameMenuPage()
        {
            InitializeComponent();
            settingsImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Icons.settings.png");
            shopImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Icons.shop.png");
            ranksImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Icons.competition.png");
            playerChoosenSkin.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Skins.pokeball.png");
            contentPage.BackgroundImageSource = ImageSource.FromResource("FloppyBird.Assets.Images.Backgrounds.bg.png");
        }

        void NextSkinBtnClicked(System.Object sender, System.EventArgs e)
        {

        }

        void BackSkinBtnClicked(System.Object sender, System.EventArgs e)
        {

        }

        void BackBackgroundBtnClicked(System.Object sender, System.EventArgs e)
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
