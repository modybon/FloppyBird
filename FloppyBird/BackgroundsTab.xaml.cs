using System;
using System.Collections.Generic;
using FloppyBird.Models;
using Xamarin.Forms;

namespace FloppyBird
{
    public partial class BackgroundsTab : ContentPage
    {
        private Boolean purchaseConfirm;


        public BackgroundsTab()
        {
            InitializeComponent();
            PopulateBackgrounds();
            SetUserCoinsLabels();
        }

        async void BackgroundsList_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            purchaseConfirm = await DisplayAlert("Confirm your purchase?", "There are no refunds!", "Confirm", "Cancel");



            var item = BackgroundsList.SelectedItem as ShopItem;


            if (purchaseConfirm)
            {

                Player.PLayerCoins = Player.PLayerCoins - item.Cost;
                userCoinsLabel.Text = Player.PLayerCoins.ToString();
                BackgroundsRepository.AddBackgrounds(item);

                Player.PLayerCoins = Player.PLayerCoins - item.Cost;
                userCoinsLabel.Text = Player.PLayerCoins.ToString();

            }
        }

        private void SetUserCoinsLabels()
        {
            userCoinsLabel.Text = Player.PLayerCoins.ToString();
        }

        private void PopulateBackgrounds()
        {
            BackgroundsList.ItemsSource = new List<ShopItem>
            {
                new ShopItem
                {
                    Title = "Desert",
                    Cost = 200,
                    Image = "https://i.pinimg.com/originals/36/92/92/369292d8316289544f15c363243a9363.jpg"

                },

                new ShopItem
                {
                    Title = "Forrest",
                    Cost = 300,
                    Image = "https://i.pinimg.com/474x/a6/ba/b7/a6bab7b44a3ddfa113c6be9e6df04e1c.jpg"
                },

                new ShopItem
                {
                    Title = "Mountains",
                    Cost = 400,
                    Image = "https://wallpapercave.com/wp/wp10282617.jpg"
                },

                new ShopItem
                {
                    Title = "Space",
                    Cost = 500,
                    Image = "https://img.freepik.com/free-vector/space-background-with-planet-landscape_107791-6146.jpg?w=2000"
                }
            };
        }

        
    }
}
