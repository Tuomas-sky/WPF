
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
namespace Reflection
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ITank tank = new Tank();
            ////=======动态描述=========
            //var t=tank.GetType();
            //Object o =Activator.CreateInstance(t);
            //MethodInfo runInfo = t.GetMethod("Run");
            //MethodInfo boomInfo = t.GetMethod("Boom");
            //runInfo.Invoke(o, null);
            //boomInfo.Invoke(o,null);

            ////依赖注入,最重要的是container
            //var sc = new ServiceCollection();//sc就是容器
            //sc.AddScoped(typeof(ITank), typeof(Tank));
            //var sp = sc.BuildServiceProvider(); 
            ////===============================
            //ITank tank = sp.GetService<ITank>();
            //tank.Boom();
            //tank.Run();

            Console.WriteLine(Environment.CurrentDirectory);


        }
    }

    //1、接口隔离原则sample1
    class Driver
    {
        private IVehical _vehical;
        public Driver(IVehical vehical)
        {
            _vehical = vehical;
        }
        public void Drive()
        {
            _vehical.Run();
        }

    }
    //接口隔离原则-服务调用者不会多调用

    interface IVehical
    {
        void Run();
    }
    interface IWeapen
    {
        void Boom();
    }
    interface ITank : IVehical, IWeapen
    { }
    class Car : IVehical
    {

        public void Run()
        {
            Console.WriteLine("Car is running ...");
        }

    }
    class Truck : IVehical
    {
        public void Run()
        {
            Console.WriteLine("Truck is running ...");
        }
    }

    class Tank : ITank
    {
        public void Boom()
        {
            Console.WriteLine("ka ka ...");
        }
        public void Run()
        {
            Console.WriteLine("Tank is running ...");
        }
    }
    class HeavyTank : ITank
    {
        public void Boom()
        {
            Console.WriteLine("ka!! ka!! ...");
        }
        public void Run()
        {
            Console.WriteLine("HeavyTank is running ...");
        }
    }
}
