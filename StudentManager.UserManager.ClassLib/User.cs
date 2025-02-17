using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.UserManager.ClassLib
{
    public class User
    {
        public int Age { get; set; }
        public string Name { get; set; }
        private void Game()
        {
            Console.WriteLine($"{Name} is gamming");
        }
        public  void SayHi()
        {
            Console.WriteLine($"hello,I'm {Name},{Age} years old!");
            Game();
        }
    }
}
