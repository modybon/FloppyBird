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
        private int _score;
        private int _coins;

        public int Score
        {
            get
            {
                return _score;
            }
        }
        public int Coins
        {
            get
            {
                return _coins;
            }
        }

        public Game(Image player, double screenHeight, double screenWidth, Shape obstacle1, Shape obstacle2)
        {
            _player = new Player();
            _obstacle = new Obstacle(screenHeight,obstacle1,obstacle2);
            _player.IsAlive = true;
            _playerImage = player;
            _screenHeight = screenHeight;
            _screenWidth = screenWidth;
             
        }

        public void StartGame()
        {
            _obstacle.RespawnObstacle();
            Gravity(_playerImage);
            Update();
        }

        private async void Update()
        {
            while (_player.IsAlive)
            {
                bool playerHitTopOrBot = _playerImage.TranslationY < 0 || _playerImage.TranslationY >= _screenHeight;
                bool playerHitObstacle1 = _playerImage.TranslationY <= _obstacle.TopPart.Height && _obstacle.TopPart.TranslationX == -280 ? true : false;
                bool playerHitObstacle2 = _playerImage.TranslationY >= _obstacle.BottomPart.Bounds.Y && _obstacle.BottomPart.TranslationX == -280 ? true : false;

                bool playerPassed = _playerImage.TranslationY > _obstacle.TopPart.Height && _playerImage.TranslationY < _obstacle.BottomPart.Bounds.Y && _obstacle.TopPart.TranslationX == -280 ? true : false;

                bool obstacleReachedEnd = _obstacle.TopPart.TranslationX <= -(_screenWidth / 2);
                if (obstacleReachedEnd)
                {
                    _obstacle.RespawnObstacle();
                }
                if (playerPassed)
                {
                    _score += 1;
                    _coins += 10;
                }

                if (!playerHitTopOrBot && !playerHitObstacle1 && !playerHitObstacle2)
                {
                    await _obstacle.MoveObstacle();
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

        public void PlayAgain()
        {
            _score = 0;
            _coins = 0;
            _playerImage.TranslationY = 0;
            _player.IsAlive = true;
            StartGame();
        }
    }
}