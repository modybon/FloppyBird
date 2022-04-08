using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FloppyBird
{
    public partial class BackgroundsTab : ContentPage
    {
        public BackgroundsTab()
        {
            InitializeComponent();
            PopulateBackgrounds();
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

        void BackgroundsList_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
        }
    }
}
