using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FloppyBird.Models;
using Xamarin.Forms;

namespace FloppyBird
{
    public partial class SignUpPage : ContentPage
    {
        private Firestore _firestore;
        public SignUpPage()
        {
            InitializeComponent();
        }

        
        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LogInPage(), true);
        }

        void SignUpButton(System.Object sender, System.EventArgs e)
        {
            TrySignUp();
        }

        async private void TrySignUp()
        {
            // Checks if the Inputs are Valid Before Signing Up 
            if (await ValidInputs())
            {
                bool userCreated = await Firestore.CreateUserAsync(userNameEntry.Text, emailEntry.Text, passwordEntry.Text);
                if (userCreated)
                {
                    await Navigation.PushAsync(new GameMenuPage(Player.PLayerCoins));
                }
                else
                {
                    await DisplayAlert("Sign Up", $"{Firestore.Message}", "OK");
                }
            }
        }

        private async Task<bool> ValidInputs()
        {
            // Regular Expression which decides the requirments for each Entry.
            string userNamePattern = "[a-zA-Z0-9]";
            string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            string passwordPattern = @".{8,}";
            Regex userNamerg = new Regex(userNamePattern);
            Regex emailrg = new Regex(emailPattern);
            Regex passwordrg = new Regex(passwordPattern);

            // Check if the user entry is matching the requirments. 
            bool isUserNameValid = userNamerg.Match(userNameEntry.Text ?? "").Success;
            bool isEmailValid = emailrg.Match(emailEntry.Text ?? "").Success;
            bool isPasswordValid = passwordrg.Match(passwordEntry.Text ?? "").Success;

            // Check that the inputs are not null
            if (userNameEntry.Text != "" && emailEntry.Text != "" && passwordEntry.Text != "")
            {
                if (isUserNameValid && isEmailValid && isPasswordValid)
                {
                    // Checks if the UserName is already taken.and gives feedback accordingly.
                    var userNameExist = await Firestore.CheckUserNameExist(userNameEntry.Text);
                    //var userNameExist = await _firestore.CheckUserNameExist(userNameEntry.Text);
                    if (userNameExist)
                    {
                        await DisplayAlert("SignUp", "UserName is Already Taken", "Ok");
                        return false;
                    }
                    else
                    {
                        // Hides all invalid messages if all the entries have met the requirments
                        invalidEmailMessage.IsVisible = false;
                        invalidUserNameMessage.IsVisible = false;
                        invalidPasswordMessage.IsVisible = false;
                        return true;
                    }

                }
                else
                {
                    // Shows Invalid messages in case any of the entries didn't meet the requirments
                    ShowInvalidMessages(isEmailValid, isUserNameValid, isPasswordValid);
                    return false;
                }
            }
            else
            {
                /// Shows Invalid messages in case any of the entries are left empty
                ShowInvalidMessages(isEmailValid, isUserNameValid, isPasswordValid);
                return false;
            }
        }

        private void ShowInvalidMessages(bool emailValid, bool userNameValid, bool passwordValid)
        {
            // Checks ach Entry Validation and Shows the User The Invalid Messages Accordingly. 
            if (!emailValid)
            {
                invalidEmailMessage.IsVisible = true;
            }
            else
            {
                invalidEmailMessage.IsVisible = false;
            }
            if (!userNameValid)
            {
                invalidUserNameMessage.IsVisible = true;
            }
            else
            {
                invalidUserNameMessage.IsVisible = false;
            }
            if (!passwordValid)
            {
                invalidPasswordMessage.IsVisible = true;
            }
            else
            {
                invalidPasswordMessage.IsVisible = false;
            }
        }

    }
}
