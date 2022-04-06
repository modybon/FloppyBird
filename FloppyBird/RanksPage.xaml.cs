using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FloppyBird.Models;
using Xamarin.Forms;

namespace FloppyBird
{
    public partial class RanksPage : ContentPage
    {
        public RanksPage()
        {
            InitializeComponent();
            PopulateUsersRanksAsync();
        }

        void refresh_Refreshing(System.Object sender, System.EventArgs e)
        {
            PopulateUsersRanksAsync();
            refresh.IsRefreshing = false;
        }
        private async Task PopulateUsersRanksAsync()
        {
            var listview = ranksListView.ItemsSource = new List<User>();
            var users = await Firestore.getUserList();
            ranksListView.ItemsSource = users;
        }
    }
}
