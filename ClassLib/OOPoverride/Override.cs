using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.OOPoverride
{
    public class Vehical1
    {
        private int _speed;
        public virtual int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public virtual void Run()
        {
            Console.WriteLine("Vehical is running");
            _speed = 100;
        }
    }
    public class Car1 : Vehical1
    {
        private int _rpm;
        public override int Speed
        {
            get { return _rpm / 100; }

            set { _rpm = value * 100; }
        }
        public override void Run()
        {
            Console.WriteLine("Car is running");
            _rpm = 5000;
        }
    }
    public class RaceCar : Car1
    {
        public override void Run()
        {
            Console.WriteLine("Racecar is runing");
        }
    }
}
