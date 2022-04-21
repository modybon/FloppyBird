using System;
using System.Collections.Generic;
using FloppyBird.Models;
using Xamarin.Forms;

namespace FloppyBird
{
    public partial class GameMenuPage : ContentPage
    {
        private Player _player;
        private int skinIndex=0;
        private ShopItem currentItem;

        public GameMenuPage(double coins)
        {
            InitializeComponent();
            _player = new Player();
            var availbleSkins = SkinsRepository.SkinsList;
            settingsImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Icons.settings.png");
            shopImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Icons.shop.png");
            ranksImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Icons.competition.png");
            playerChosenSkin.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Skins.pokeball.png");
            backgroundImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Backgrounds.bg001.png");
            coinsImage.Source = "https://www.pngall.com/wp-content/uploads/4/Empty-Gold-Coin-Transparent.png";
            coinsLabel.Text = $"{coins}";
        }

        void NextSkinBtnClicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                skinIndex++;
                playerChosenSkin.Source = SkinsRepository.SkinsList[skinIndex].Image;
            }
            catch
            {
                skinIndex = 0;
                playerChosenSkin.Source = SkinsRepository.SkinsList[skinIndex].Image;
            }
        }

        void PreviousSkinBtnClicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                skinIndex--;
                playerChosenSkin.Source = SkinsRepository.SkinsList[skinIndex].Image;
            }
            catch
            {
                skinIndex = SkinsRepository.SkinsList.Count - 1;
                playerChosenSkin.Source = SkinsRepository.SkinsList[skinIndex].Image;
            }
        }

        void PreviousBackgroundBtnClicked(System.Object sender, System.EventArgs e)
        {
        }

        void NextBackgroundBtnClicked(System.Object sender, System.EventArgs e)
        {
        }

        void ShopImageClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ShopPage(Player.PLayerCoins));
        }

        void RanksImageClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RanksPage());
        }

        void PlayBtnClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new GamePage(playerChosenSkin.Source));
        }



    }
}
