using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using FloppyBird.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FloppyBird
{
    // Author: Mohamed Ahmed
    // Controls the UI of the game 
    public partial class GamePage : ContentPage
    {
        private double _density = DeviceDisplay.MainDisplayInfo.Density;
        private double _screenHeight = DeviceDisplay.MainDisplayInfo.Height;
        private double _screenWidth = DeviceDisplay.MainDisplayInfo.Width;
        private Game game;
        private bool _alreadyStarted;
        private bool _message;
        private TapGestureRecognizer gridTap = new TapGestureRecognizer();

        public GamePage(ImageSource playerSkin, ImageSource background)
        {
            InitializeComponent();
            _screenHeight = _screenHeight / _density;
            playerImage.Source = playerSkin;
            backgroundImage.Source = background;
            coinImage.Source = "https://www.pngall.com/wp-content/uploads/4/Empty-Gold-Coin-Transparent.png";
            game = new Game(playerImage, _screenHeight, _screenWidth, obstacle1, obstacle2);
            GridTapped();
            Updates();
            //StartTimer();
        }

        private void GridTapped()
        {
            gridTap.Tapped += (s, e) =>
            {
                if (_alreadyStarted)
                {
                    game.JumpAsync(playerImage);
                }
                else
                {
                    _alreadyStarted = true;
                    game.StartGame();
                }
            };
            grid.GestureRecognizers.Add(gridTap);
        }

        private void Updates()
        {
            Thread t1 = new Thread(() => GameOverMessage());
            Thread t2 = new Thread(() => UpdateScore());
            t1.Start();
            t2.Start();
        }


        private void UpdateScore()
        {
            while (!game.IsDead())
            {
                MainThread.BeginInvokeOnMainThread(()=> scoreLabel.Text = $"{game.Score}") ;
                MainThread.BeginInvokeOnMainThread(() => coinsLabel.Text = $"{game.Coins}");
            }
        }

        private void GameOverMessage()
        {
            while (!game.IsDead())
            {

            }
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                _message = await DisplayAlert("Game Over", $"Score: {game.Score}\n Coins:{game.Coins} ", "Play Again", "Menu");
                if (_message)
                {
                    Player.PLayerCoins += game.Coins;
                    game.StartGame();
                    Updates();
                }
                else
                {
                    Player.PLayerCoins += game.Coins;
                    await Navigation.PushAsync(new GameMenuPage(Player.PLayerCoins));
                }
            }
            ) ;
        }
    }
}
