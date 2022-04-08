﻿using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FloppyBird.Models
{
    public class Player : INotifyPropertyChanged
    {
        private bool _isJumping;
        private double _currentX;
        private double _currentY;
        public Player()
        {
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
                OnPropertyChanged("IsJumping");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



        public Animation Jump(Image player,double x, double y)
        {
            //{0, 0.75, new Animation (v => player.TranslationY = v, 0, 1,Easing.Linear) }
            //{0, 0.25, new Animation (v => player.Rotation = v, 0,-90) },
            //{0.25, .5, new Animation (v => player.TranslationY = v, 80, 0, easing: Easing.Linear) },
            //{0.25, 0.5, new Animation (v => player.Rotation = v, -90, 0) }
            var animation = new Animation
                {
                {0,0.25,new Animation(v=> player.TranslationY = v,0,-80,Easing.Linear) }
                    };
            //.Commit(this, "player", length: 1000, repeat: () => false);
            //player.TranslateTo(0,-80,1000,Easing.BounceIn);
            //player.TranslationY = 0;
            _isJumping = false;
            
            return animation;
        }
        public Animation Fall(Image player)
        {
            var animation = new Animation
                {
                      {0, 0.25, new Animation (v => player.TranslationY = v, 0, 80) },
                      {0, 0.25, new Animation (v => player.Rotation = v, 0,-90) },
                      {0.25, .5, new Animation (v => player.TranslationY = v, 80, 300, easing: Easing.Linear) },
                      {0.25, 0.5, new Animation (v => player.Rotation = v, -90, 0) }
                    };
            // .Commit(this, "player", length: 1000, repeat: () => false);
            return animation;
        }
    }
}
