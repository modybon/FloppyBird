using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FloppyBird.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace FloppyBird
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ShopPage : TabbedPage
    {
        

        //private void UserCoinCountStart()
        //{
        //    UserCoins.Coins = 0;
        //}

        public ShopPage(double playerCoins)
        {
            InitializeComponent();
            //UserCoinCountStart();
        }

        void ShopList_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
        }
    }
}
