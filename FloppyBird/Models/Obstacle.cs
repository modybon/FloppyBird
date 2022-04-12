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
        List<LayoutOptions> _layouts;
        public Shape _obstacle1 { get; private set; }
        public Shape _obstacle2 { get; private set; }
        Random random;

        public Obstacle(double screenHeight,Shape obstacle1,Shape obstacle2)
        {
            random = new Random();
            _width = 100;
            _layouts = new List<LayoutOptions>() { LayoutOptions.End, LayoutOptions.Start, LayoutOptions.Center };
            _screenHeight = screenHeight;
            _obstacle1Color = Brush.Black;
            _obstacle2Color = Brush.White;
            _obstacle1 = obstacle1;
            _obstacle2 = obstacle2;
        }

        public void CreateNewObstacel()
        {
            //var choosenLayout = _layouts[random.Next(_layouts.Count)];
            int gap = 150;
            _obstacle1.VerticalOptions = LayoutOptions.Start;
            _obstacle2.VerticalOptions = LayoutOptions.End;
            var gridHeight = (int) (_screenHeight / 3) - 150 ;
            var _obstacle1Height = random.Next(100,gridHeight);
            var _obstacle2Height = gridHeight - _obstacle1Height;

            //int limit = (int)(_screenHeight / 2) / 2;


            _obstacle1.Fill = _obstacle1Color;
            _obstacle2.Fill = _obstacle2Color;
            _obstacle1.HeightRequest = _obstacle1Height;
            _obstacle2.HeightRequest = _obstacle2Height;
            //_obstacle2.VerticalOptions = _layouts[random.Next(0, _layouts.Count)];
            _obstacle1.TranslationX = 40;
            _obstacle2.TranslationX = 40;
        }
    }
}
