using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using FloppyBird.Models;
using Xamarin.Forms;

namespace FloppyBird
{
    public partial class GamePage : ContentPage
    {
        private bool _isJumping;
        private Player _player;
        private double x;
        private double y;
        private double _screenHeight;
        private double _screenWidth;
        public GamePage()
        {
            InitializeComponent();
            _player = new Player();
            objectImage.Source = ImageSource.FromResource("FloppyBird.Assets.Images.pokeball.png");
            _screenHeight = layout.Height;
            _screenWidth = layout.Width;
            Start();
        }

        private void Start()
        {
            Gravity();
        }

        void jumpButton_Clicked(System.Object sender, System.EventArgs e)
        {
            _player.JumpAsync(objectImage);
        }

        private void Gravity()
        {
            _player.FallAsync(objectImage);
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            _player.JumpAsync(objectImage);
        }
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