using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace FloppyBird.Models
{
    public class Game 
    {
        private Player _player;
        private Image _playerImage;
        private Shape _obst1;
        private Shape _openage;
        private double _screenHeight;
        private double _screenWidth;
        

        public Game(Image player, double screenHeight, double screenWidth, Shape obstacale1, Shape openage)
        {
            _player = new Player();
            _player.IsAlive = true;
            _playerImage = player;
            _obst1 = obstacale1;
            _openage = openage;
            _screenHeight = screenHeight;
            _screenWidth = screenWidth;
        }

        public void StartGame()
        {
            CreateNewObstacel();
            Gravity(_playerImage);
            MoveObstacles();
        }

        private async void MoveObstacles()
        {
            while (_player.IsAlive)
            {
                //Gravity(_playerImage);
                double y = _playerImage.TranslationY;
                bool playerDidNotHitTopOrBot = _playerImage.TranslationY >= 0 && _playerImage.TranslationY <= (_screenHeight / 2);
                bool obstacleReachedEnd = _obst1.TranslationX <= -(_screenWidth / 2);

                //CreateNewObstacel();
                if (obstacleReachedEnd)
                {
                    CreateNewObstacel();
                }

                if (playerDidNotHitTopOrBot)
                {
                    var obsX = _obst1.TranslationX;
                    var a1 = _obst1.TranslateTo(_obst1.TranslationX - 40, 0);
                    var a2 = _openage.TranslateTo(_openage.TranslationX - 40, 0);
                    await Task.WhenAll(a1, a2);
                }
                else
                {
                    _player.IsAlive = false;
                }
            }
        }

        private void CreateNewObstacel()
        {
            List<LayoutOptions> layouts = new List<LayoutOptions>() { LayoutOptions.End, LayoutOptions.Start, LayoutOptions.Center };
            Random random = new Random();
            int limit = (int)(_screenHeight / 2) / 2;
            _obst1.HeightRequest = _screenHeight;
            //(int)(_screenHeight / 6)
            _openage.HeightRequest = random.Next(80, 200);
            _openage.VerticalOptions = layouts[random.Next(0,layouts.Count)];
            _obst1.TranslationX = 0;
            _openage.TranslationX = 0;
        }

        public async void JumpAsync(Image player)
        {
            if (_player.IsAlive)
            {
                _player.IsJumping = true;
                var a1 = player.TranslateTo(10, player.TranslationY - 90);
                var a2 = player.RotateTo(-90);
                await Task.WhenAll(a1, a2);
                _player.IsJumping = false;
                Gravity(_playerImage);
                //StartGame();
            }
            
        }
        private async void Gravity(Image player)
        {
            while (!_player.IsJumping)
            {
                var a1 = player.TranslateTo(10, player.TranslationY + 70);
                var a2 = player.RotateTo(60);
                await Task.WhenAll(a1, a2);
            }
        }

        public bool IsDead()
        {
            if (!_player.IsAlive)
                return true;
            else
                return false;
        }
    }
}
