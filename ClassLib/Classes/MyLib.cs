using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Classes
{
    public class Vehicle
    {
        protected int _rpm;//protected跨程序集
        private int _fuel;
        public void Refuel() { _fuel = 100; }
    
        public int Speed { get { return _rpm / 100; } }
        protected void Burn(int fuel) { _fuel -= fuel; }
        public void Accelerate() {
            Burn(1);
            _rpm += 1000; 
        }

    }
    public class Car : Vehicle { 
        public void TurboAccelerate()
        {
            Burn(2);
            _rpm += 3000;
        }
    }
}
