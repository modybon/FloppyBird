using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

// Authors: Mohamed Ahmed
// creates and moves the obstacles that are shown on the screen. 
namespace FloppyBird.Models
{
    public class Obstacle
    {
        private int _width;
        private double _screenHeight;
        private Shape _obstacle1;
        private Shape _obstacle2;
        Random random;

        public Shape TopPart
        {
            get
            {
                return _obstacle1;
            }
        }
        public Shape BottomPart
        {
            get
            {
                return _obstacle2;
            }
        }

        public Obstacle(double screenHeight,Shape obstacle1,Shape obstacle2)
        {
            random = new Random();
            _width = 100;
            _screenHeight = screenHeight;
            _obstacle1 = obstacle1;
            _obstacle2 = obstacle2;
            _obstacle1.Fill = Brush.Black;
            _obstacle2.Fill = Brush.Black;
            _obstacle1.VerticalOptions = LayoutOptions.Start;
            _obstacle2.VerticalOptions = LayoutOptions.End;
        }

        public void RespawnObstacle()
        {
            int gap = 200;

            var _obstacle1Height = random.Next(100,(int)_screenHeight - 200);
            var _obstacle2Height = (_screenHeight - _obstacle1Height) - gap;

            _obstacle1.HeightRequest = _obstacle1Height;
            _obstacle2.HeightRequest = _obstacle2Height;
            _obstacle1.TranslationX = 40;
            _obstacle2.TranslationX = 40;
        }
       
        public async Task MoveObstacle()
        {
            var a1 = _obstacle1.TranslateTo(_obstacle1.TranslationX - 40, 0);
            var a2 = _obstacle2.TranslateTo(_obstacle2.TranslationX - 40, 0);
            await Task.WhenAll(a1, a2);
        }
    }
}
