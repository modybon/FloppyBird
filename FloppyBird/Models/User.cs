using System;
using System.Collections.Generic;

namespace FloppyBird.Models
{
    // Author : Mohamed Ahmed
    public class User
    {
        public string UserName { get; set; }
        public List<string> Purchases { get; set; }
        public int HighScore { get; set; }
        public string Uid { get; set; }
        public User()
        {
        }
    }
}
