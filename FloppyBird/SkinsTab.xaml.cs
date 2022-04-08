using System;
using System.Collections.Generic;

using Xamarin.Forms;


[assembly: ExportFont("CartoonFun-rg0zO.ttf", Alias = "CartoonFun")]
[assembly: ExportFont("Thickdeco-V8Gz.ttf", Alias = "ThickDeco")]


namespace FloppyBird
{
    public partial class SkinsTab : ContentPage
    {
        public SkinsTab()
        {
            InitializeComponent();
            PopulateSkins();
        }

        void SkinsList_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            
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
