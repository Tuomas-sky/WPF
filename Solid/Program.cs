using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var driver = new Driver(new Car());
            //driver.Drive();
            //var tank = new Driver(new Tank());
            //tank.Drive();

            int[] nums1 = { 1, 2, 3 };
            ArrayList nums2 = new ArrayList() { 1, 2, 3, 4, 5 };
            var nums3 = new ReadOnlyCollection(nums1);
            Console.WriteLine(Sum(nums1));
            Console.WriteLine(Sum(nums2));
            // Console.WriteLine(Sum(nums3));//传进去的接口太胖了，nums3为IEnumrable, Sum需要的是ICollection,可将ICollection改为IEnumerate
            //var roc = new ReadOnlyCollection(nums1);
            //foreach (var v in roc)
            //{
            //    Console.WriteLine(v);
            //}

            ////3.接口隔离原则sample3,接口的隐藏
            //WarmKiller wk = new WarmKiller();
            //wk.Love();//看不到Killer()
            //IKiller killer=wk as WarmKiller;
            //killer.Kill();//显示调用才可以看到

            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            //reflection反射与依赖注入

        }
        static int Sum(ICollection nums)
        {
            int sum = 0;
            foreach (int i in nums) { 
                sum += (int)i;
            }
            return sum;
        }//调用者不多调
    }

    //3、接口隔离原则sample3,接口的隐藏
      interface IGantleman
    {
        void Love();
    }
    interface IKiller
    {
        void Kill();
    }
    class WarmKiller : IGantleman,IKiller 
    {
        public void Love()
        {
            Console.WriteLine("love ...");
        }

        void IKiller.Kill()
        {
            Console.WriteLine("kill ...");
        }
    }

    //2、接口隔离原则sample2
    class ReadOnlyCollection : IEnumerable//只读类
    {
        private int[] _array;
        public ReadOnlyCollection(int[] array)
        {
            _array = array;
        }
        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
        public class Enumerator : IEnumerator
        {
            private ReadOnlyCollection _collection;
            private int _head;
            public Enumerator(ReadOnlyCollection collection)
            {
                _collection = collection;
                _head = -1;
            }
            public object Current {
                get { 
                    object o =_collection._array[_head];
                    return o;
                }
            }

            public bool MoveNext()
            {
                if (++_head< _collection._array.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                _head = -1;
            }
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
    class Car : IVehical {

        public void Run() {
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
