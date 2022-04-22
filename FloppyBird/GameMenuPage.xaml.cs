using System;
using System.Collections.Generic;
using FloppyBird.Models;
using Xamarin.Forms;

namespace FloppyBird
{
    public partial class GameMenuPage : ContentPage
    {
        private int skinIndex = 0;
        private int backgroundsIndex = 0;
        //for keeping track of the currently selected background and skin
        private ShopItem currentItem;

        public GameMenuPage(double coins)
        {
            InitializeComponent();
            var availbleSkins = SkinsRepository.SkinsList;
            settingsImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Icons.settings.png");
            shopImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Icons.shop.png");
            ranksImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Icons.competition.png");
            playerChosenSkin.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Skins.pokeball.png");
            backgroundImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Backgrounds.bg001.png");
            coinsImage.Source = "https://www.pngall.com/wp-content/uploads/4/Empty-Gold-Coin-Transparent.png";
            //_coins = coins;
            coinsLabel.Text = $"{coins}";
        }


        //button for the right side arrow of the skin-chooser
        //author: Ryan
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

        //button for the left side arrow of the skin-chooser
        //author: Ryan
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


        //button for the right side arrow of the background-chooser
        //author: Ryan
        void PreviousBackgroundBtnClicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                backgroundsIndex--;
                backgroundImage.Source = BackgroundsRepository.BackgroundsList[backgroundsIndex].Image;
            }
            catch
            {
                backgroundsIndex = BackgroundsRepository.BackgroundsList.Count - 1;
                backgroundImage.Source = BackgroundsRepository.BackgroundsList[backgroundsIndex].Image;
            }
        }


        //button for the left side arrow of the background-chooser
        //author: Ryan
        void NextBackgroundBtnClicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                backgroundsIndex++;
                backgroundImage.Source = BackgroundsRepository.BackgroundsList[backgroundsIndex].Image;
            }
            catch
            {
                backgroundsIndex = 0;
                backgroundImage.Source = BackgroundsRepository.BackgroundsList[backgroundsIndex].Image;
            }
        }

        //button to go to the shop page
        //author: Ryan
        void ShopImageClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ShopPage(Player.PLayerCoins));
        }


        //button to go to the ranks page
        //author: Ryan
        void RanksImageClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RanksPage());
        }

        //button to go to the backgrounds page
        //author: Ryan
        void PlayBtnClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new GamePage(playerChosenSkin.Source, backgroundImage.Source));
        }

    }
}
