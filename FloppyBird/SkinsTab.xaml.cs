using System;
using System.Collections.Generic;
using System.Diagnostics;
using FloppyBird.Models;
using Xamarin.Forms;



namespace FloppyBird
{
    public partial class SkinsTab : ContentPage
    {
        private Boolean purchaseConfirm;

        public SkinsTab()
        {
            InitializeComponent();
            PopulateSkins();
            SetUserCoinsLabels();
        }

        async void SkinsList_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            purchaseConfirm = await DisplayAlert("Confirm your purchase?", "There are no refunds!", "Confirm", "Cancel");

            var item = SkinsList.SelectedItem as ShopItem;


            if (purchaseConfirm)
            {
                UserCoins.Coins = UserCoins.Coins - item.Cost;
                userCoinsLabel.Text = UserCoins.Coins.ToString();
            }
        }

        private void SetUserCoinsLabels()
        {
            userCoinsLabel.Text = UserCoins.Coins.ToString();
        }

        private void PopulateSkins()
        {

            SkinsList.ItemsSource = new List<ShopItem>
            
            {
                new ShopItem
                {
                    Title = "Soccerball",
                    Cost = 200,
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d3/Soccerball.svg/1024px-Soccerball.svg.png"

                },

                new ShopItem
                {
                    Title = "Baseball",
                    Cost = 300,
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/92/Baseball.svg/2048px-Baseball.svg.png"
                },

                new ShopItem
                {
                    Title = "Football",
                    Cost = 400,
                    Image = "https://purepng.com/public/uploads/large/purepng.com-american-footballamerican-footballamericanfootballgridiron-footballgridironsportoval-1701528085915z1rba.png"
                },

                new ShopItem
                {
                    Title = "Basketball",
                    Cost = 500,
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/72/Basketball_Clipart.svg/768px-Basketball_Clipart.svg.png"
                }
            };
        }

    }
}
