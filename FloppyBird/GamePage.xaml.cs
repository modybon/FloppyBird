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
    public partial class GamePage : ContentPage
    {
        private double _density = DeviceDisplay.MainDisplayInfo.Density;
        private double _screenHeight = DeviceDisplay.MainDisplayInfo.Height;
        private double _screenWidth = DeviceDisplay.MainDisplayInfo.Width;
        private Game game;
        private bool _started;
        private TapGestureRecognizer gridTap = new TapGestureRecognizer();

        public GamePage(ImageSource playerSkin)
        {
            InitializeComponent();
            _screenHeight = _screenHeight / _density;
            playerImage.Source = playerSkin;
            backgroundImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.Backgrounds.bg.png");
            game = new Game(playerImage, _screenHeight, _screenWidth, obstacle1, obstacle2);
            GridTapped();
            Thread t1 = new Thread(() => GameOverMessage());
            Thread t2 = new Thread(() => UpdateScore());
            t1.Start();
            t2.Start();
            //Dead();
            //game.StartGame(playerImage,_screenHeight,_screenWidth);

            StartTimer();
        }

        static void StartTimer()
        {
            var timer = new Timer(TimerMethod, null, 0, 2000);

            //Dispose the timer
            timer.Dispose();
        }
        static void TimerMethod(object state)
        {
            UserCoins.Coins += 1;
        }


        private void GridTapped()
        {
            gridTap.Tapped += (s, e) =>
            {
                if (_started)
                {
                    game.JumpAsync(playerImage);
                }
                else
                {
                    _started = true;
                    game.StartGame();
                }
            };
            grid.GestureRecognizers.Add(gridTap);
        }

        private void UpdateScore()
        {
            while (!game.IsDead())
            {
                MainThread.BeginInvokeOnMainThread(()=> scoreLabel.Text = $"{game.Score}") ;
            }
        }

        private void GameOverMessage()
        {
            while (!game.IsDead())
            {

            }
            MainThread.BeginInvokeOnMainThread(() => DisplayAlert("Game Over", "Died", "OK"));
        }

        //void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        //{
        //    if (_started)
        //    {
        //        double y = playerImage.TranslationY;
        //        scoreLabel.Text = $"{y}";
        //        game.JumpAsync(playerImage);
        //    }
        //    else
        //    {
        //        _started = true;
        //        game.StartGame();
        //    }    
        //}
        
        
       
        //void Button_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    playButton.IsVisible = false;
        //    game.StartGame();
        //}
    }
}














//if (!_isAnimating)
//{
//    _isAnimating = true;

//    new Animation {
//  { 0, 0.25, new Animation (v => objectImage.TranslationY = v, 0, -40) },
//  { 0.25, .5, new Animation (v => objectImage.TranslationY = v, -40, 0, easing: Easing.BounceOut) }
//}
//.Commit(this, "AppleIconBounceChildAnimations", length: 1000, repeat: () => true);
//}






//if (!_isAnimating)
//{
//    _isAnimating = true;
//    //await objectImage.TranslateTo(0, objectImage.TranslationY - 100,350);
//    //await objectImage.RelRotateTo(60);
//    //await objectImage.TranslateTo(0, objectImage.TranslationY + 100, 300);
//    //_isAnimating = false;
//    //await objectImage.RelRotateTo(120);
//    //new Animation
//    //{
//    //      {0, 0.25, new Animation (v => objectImage.TranslationY = v, 0, -80) },
//    //      {0, 0.25, new Animation (v => objectImage.Rotation = v, 90, +60) },
//    //      {0.25, .5, new Animation (v => objectImage.TranslationY = v, -80, 0, easing: Easing.Linear) },
//    //      {0, 0.25, new Animation (v => objectImage.Rotation = v, 90, 0) }
//    //    }
//    //    .Commit(this, "AppleIconBounceChildAnimations", length: 1000, repeat: () => false);

//    //new Animation(v => objectImage.TranslationY = v,0,-100,Easing.Linear).Commit(this, "AppleIconBounceChildAnimations",16,100,Easing.Linear);
//    var x = jumpButton.X;
//    var y = jumpButton.Y;
//    var rand = new Random();
//    //var randomnum = rand.Next(0, 360);
//    rotation += 5;
//    Jump();

//    _isAnimating = false;
//}












//private async void Start()
//{
//    //obstacleImage.TranslationX != - _screenWidth
//    //|| playerImage.TranslationY <= - (_screenHeight/2)
//    // playerImage.TranslationY <= (_screenHeight / 2)
//    Gravity();
//    while (_Alive)
//    {
//        double y = playerImage.TranslationY;
//        bool cond1 = playerImage.TranslationY >= 0;
//        bool cond2 = playerImage.TranslationY <= (_screenHeight / 2);
//        if (cond1 == true && cond2 == true)
//        {
//            double _screenHeight = DeviceDisplay.MainDisplayInfo.Height;
//            double _screenWidth = DeviceDisplay.MainDisplayInfo.Width ;

//            //double x = obstacleImage.TranslationX;
//            //double y = playerImage.TranslationY;
//            var a1 = obstacleImage.TranslateTo(obstacleImage.TranslationX - 40, 0);
//            var a2 = obstacleImage2.TranslateTo(obstacleImage.TranslationX - 40, 0);
//            await Task.WhenAll(a1, a2);
//        }
//        else
//        {
//            //var a1 = obstacleImage.TranslateTo(obstacleImage.TranslationX + 40, 0);
//            //var a2 = obstacleImage2.TranslateTo(obstacleImage.TranslationX + 40, 0);
//            //await Task.WhenAll(a1, a2);
//            //double y = playerImage.TranslationY;
//            _Alive = false;
//            playerImage.TranslationY = 0;
//            await DisplayAlert("GameOver","Died","OK");

//        }

//    }

//}

//private void Gravity()
//{
//    _player.FallAsync(playerImage);
//}