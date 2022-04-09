using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace FloppyBird.Models
{
    public class Obstacle
    {
        private double _height;
        private int _width;
        private Brush _obstacleColor;
        private Brush _openageColor;
        private double _screenHeight;
        List<LayoutOptions> _layouts;
        public Shape _obstacle { get; private set; }
        public Shape _openage { get; private set; }
        Random random;
        public Obstacle(double screenHeight,Shape obstacle,Shape openage)
        {
            random = new Random();
            _width = 100;
            _layouts = new List<LayoutOptions>() { LayoutOptions.End, LayoutOptions.Start, LayoutOptions.Center };
            _screenHeight = screenHeight;
            _obstacleColor = Brush.Black;
            _openageColor = Brush.White;
            _obstacle = obstacle;
            _openage = openage;
        }

        public void CreateNewObstacel()
        {
            _height = random.Next(80, 200);
            int limit = (int)(_screenHeight / 2) / 2;
            _obstacle.Fill = _obstacleColor;
            _obstacle.HeightRequest = _screenHeight;
            _openage.Fill = _openageColor;
            _openage.HeightRequest = _height;
            _openage.VerticalOptions = _layouts[random.Next(0, _layouts.Count)];
            _obstacle.TranslationX = 40;
            _openage.TranslationX = 40;
        }
    }
}
