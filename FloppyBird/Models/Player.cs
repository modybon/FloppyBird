using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FloppyBird.Models
{
    public class Player 
    {
        private bool _isJumping;
        private bool _isAlive;
        
        public Player()
        {
        }

        static public double PLayerCoins
        {
            get; set;
        }

        public static Image PlayerSkin
        {
            get; set;
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
    }
}