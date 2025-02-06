using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timothy_02_interfce_abstract
{
    public class Program
    {
        static void Main(string[] args)
        {
            Vehical v = new RaceCar();
            v.Run();
            v.Stop();
            v.Fill();
        }
    }

    interface IVehical
    {
        void Run();
        void Stop();
        void Fill();
    }
    abstract public class Vehical:IVehical 
    {
        public void Stop() { Console.WriteLine("Stopped!"); }
        public void Fill()
        {
            Console.WriteLine("Pay and Fill...");
        }
        public abstract void Run();
    }
    public class Car : Vehical
    {
        public override void Run()
        {
            Console.WriteLine("Car is running");
        }
    }
    public class Truck : Vehical
    {
        public override void Run()
        {
            Console.WriteLine("Truck is running");
        }
    }
    public class RaceCar : Vehical
    {
        public override void Run()
        {
            Console.WriteLine("RaceCar is running");
        }
    }
}
