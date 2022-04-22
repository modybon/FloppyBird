using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FloppyBird.Models;
using Xamarin.Forms;

namespace FloppyBird
{
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        void RegisterClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage(), true);
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {

        }

        async void SignInAsync(System.Object sender, System.EventArgs e)
        {
            bool SignedIn = await Firestore.SignInUser(emailEntry.Text, passwordEntry.Text);
            if (SignedIn)
            {
                await DisplayAlert("Log In", $"Signed In: {SignedIn}", "Ok");
            }
            else
            {
                await DisplayAlert("Log In", $"{Firestore.Message}", "Ok");
            }
        }

        async void LogInButton(System.Object sender, System.EventArgs e)
        {
            // Checks if the user has Signed In 
            bool SignedIn = await Firestore.SignInUser(emailEntry.Text, passwordEntry.Text);
            if (SignedIn)
            {
                await Navigation.PushAsync(new GameMenuPage(Player.PLayerCoins));
            }
            else
            {
                await DisplayAlert("Log In", $"{Firestore.Message}", "Ok");
            }
        }
    }
}
