using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FloppyBird.Models
{
    public class Game 
    {
        private Player _player;
        private Image _playerImage;
        private Image _obst1;
        private Image _obst2;
        private double _screenHeight;
        private double _screenWidth;
        

        public Game(Image player, double screenHeight, double screenWidth, Image obstacale1, Image obstacale2)
        {
            _player = new Player();
            _player.IsAlive = true;
            _playerImage = player;
            _obst1 = obstacale1;
            _obst2 = obstacale2;
            _screenHeight = screenHeight;
            _screenWidth = screenWidth;
        }

        public void StartGame()
        {
            Gravity(_playerImage);
            MoveObstacles();
        }

        private async void MoveObstacles()
        {
            while (_player.IsAlive)
            {
                //Gravity(_playerImage);
                double y = _playerImage.TranslationY;
                bool didNotHitTopOrBot = _playerImage.TranslationY >= 0 && _playerImage.TranslationY <= (_screenHeight / 2);
                if (didNotHitTopOrBot)
                {
                    var a1 = _obst1.TranslateTo(_obst1.TranslationX - 5, 0);
                    var a2 = _obst2.TranslateTo(_obst2.TranslationX - 5, 0);
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
