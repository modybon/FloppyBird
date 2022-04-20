using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FloppyBird
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        void PlayBtnClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new GamePage()) ;
        }

        void LogInBtnClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ShopPage());
        }
    }
}
