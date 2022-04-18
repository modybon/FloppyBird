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
        private Brush _obstacle1Color;
        private Brush _obstacle2Color;
        private double _screenHeight;
        public Shape _obstacle1 { get; private set; }
        public Shape _obstacle2 { get; private set; }
        Random random;

        public Obstacle(double screenHeight,Shape obstacle1,Shape obstacle2)
        {
            random = new Random();
            _width = 100;
            _screenHeight = screenHeight;
            _obstacle1Color = Brush.Black;
            _obstacle2Color = Brush.White;
            _obstacle1 = obstacle1;
            _obstacle2 = obstacle2;
        }

        public void RespawnObstacle()
        {
            int gap = 200;
            _obstacle1.VerticalOptions = LayoutOptions.Start;
            _obstacle2.VerticalOptions = LayoutOptions.End;
            var _obstacle1Height = random.Next(100,(int)_screenHeight - 200);
            var _obstacle2Height = (_screenHeight - _obstacle1Height) - gap;

            _obstacle1.Fill = _obstacle1Color;
            _obstacle2.Fill = _obstacle2Color;
            _obstacle1.HeightRequest = _obstacle1Height;
            _obstacle2.HeightRequest = _obstacle2Height;
            _obstacle1.TranslationX = 40;
            _obstacle2.TranslationX = 40;
        }
    }
}
