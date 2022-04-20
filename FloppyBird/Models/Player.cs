using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FloppyBird.Models
{
    public class Player : INotifyPropertyChanged
    {
        private bool _isJumping;
        private bool _isAlive;
        private int _playerCoins;
        private Image _playerSkin;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public Player()
        {
        }

        public int PLayerCoins
        {
            get
            {
                return _playerCoins;
            }
            set
            {
                _playerCoins = value;
            }
        }

        public Image PlayerSkin
        {
            get
            {
                return _playerSkin;
            }
            set
            {
                _playerSkin = value;
            }
        }

        
        public bool IsAlive
        {
            get
            {
                return _isAlive;
            }
            set
            {
                _isAlive = value;
            }
        }

        public bool IsJumping
        {
            get
            {
                return _isJumping;
            }
            set
            {
                _isJumping = value;
            }
        }

        //private void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}

        
    }
}






//public async void JumpAsync(Image player)
//{
//    var a1 = player.TranslateTo(10, player.TranslationY - 90);
//    var a2 = player.RotateTo(-90);
//    await Task.WhenAll(a1, a2); 
//    //FallAsync(player);
//}

//public async void FallAsync(Image player)
//{
//    while (_isAlive)
//    {
//        var a1 = player.TranslateTo(10, player.TranslationY + 70);
//        var a2 = player.RotateTo(60);
//        await Task.WhenAll(a1, a2);
//    }
//    //await DisplayAlert("Game Over", "You Died", "OK");
//}












////{0, 0.75, new Animation (v => player.TranslationY = v, 0, 1,Easing.Linear) }
////{0, 0.25, new Animation (v => player.Rotation = v, 0,-90) },
////{0.25, .5, new Animation (v => player.TranslationY = v, 80, 0, easing: Easing.Linear) },
////{0.25, 0.5, new Animation (v => player.Rotation = v, -90, 0) }
//var animation = new Animation
//                {
//                {0,0.25,new Animation(v=> player.TranslationY = v,0,-80,Easing.Linear) }
//                    };
////.Commit(this, "player", length: 1000, repeat: () => false);
////player.TranslateTo(0,-80,1000,Easing.BounceIn);
////player.TranslationY = 0;
//_isJumping = false;

//return animation;





//var animation = new Animation
//                {
//                      {0, 0.25, new Animation (v => player.TranslationY = v, 0, 80) },
//                      {0, 0.25, new Animation (v => player.Rotation = v, 0,-90) },
//                      {0.25, .5, new Animation (v => player.TranslationY = v, 80, 300, easing: Easing.Linear) },
//                      {0.25, 0.5, new Animation (v => player.Rotation = v, -90, 0) }
//                    };
//// .Commit(this, "player", length: 1000, repeat: () => false);
//return animation;