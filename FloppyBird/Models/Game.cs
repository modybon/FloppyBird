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
        private Obstacle _obstacle;
        private Image _playerImage;
        private double _screenHeight;
        private double _screenWidth;
        

        public Game(Image player, double screenHeight, double screenWidth, Shape obstacale, Shape openage)
        {
            _player = new Player();
            _obstacle = new Obstacle(screenHeight,obstacale,openage);
            _player.IsAlive = true;
            _playerImage = player;
            _screenHeight = screenHeight;
            _screenWidth = screenWidth;
        }

        public void StartGame()
        {
            _obstacle.CreateNewObstacel();
            Gravity(_playerImage);
            MoveObstacles();
        }

        private async void MoveObstacles()
        {
            while (_player.IsAlive)
            {
                //Gravity(_playerImage);
                //double y = _playerImage.TranslationY;
                bool playerDidNotHitTopOrBot = _playerImage.TranslationY >= 0 && _playerImage.TranslationY <= (_screenHeight / 2);
                bool obstacleReachedEnd = _obstacle._obstacle.TranslationX <= -(_screenWidth / 2);

                if (obstacleReachedEnd)
                {
                    _obstacle.CreateNewObstacel();
                }

                if (playerDidNotHitTopOrBot)
                {
                    var a1 = _obstacle._obstacle.TranslateTo(_obstacle._obstacle.TranslationX - 40, 0);
                    var a2 = _obstacle._openage.TranslateTo(_obstacle._openage.TranslationX - 40, 0);
                    await Task.WhenAll(a1, a2);
                }
                else
                {
                    _player.IsAlive = false;
                }
            }
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