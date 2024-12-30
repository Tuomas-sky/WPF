using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharp_01
{
    //枚举
    enum Enum
    {
        Red,
        Green,
        Blue,
    }
    class Colors
    {
        public Enum color { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Colors colors = new Colors();
            colors.color=Enum.Red|Enum.Green|Enum.Blue;
            Console.WriteLine((colors.color&Enum.Red)==Enum.Red);


            // Console.WriteLine(CalSum(1,2,3,4,5));
            //double a = 3.14159;
            //Console.WriteLine(Math.Round(a,4));
            //Console.WriteLine(a.Round(2));
            //WrapProduct wrapProduct = new WrapProduct();
            //ProductFactor productFactor = new ProductFactor();
            //Logger log = new Logger();
            //Box milkBox = wrapProduct.wrapProduct(productFactor.MilkProduct, log.Log);
            //Box fruitBox = wrapProduct.wrapProduct(productFactor.FruitProduct, log.Log);
            //Console.WriteLine(milkBox.product.Name);
            //Console.WriteLine(fruitBox.product.Name);

            //MotoPhone phone = new MotoPhone();
            //PhoneUser phoneUser=new PhoneUser(phone);
            //phoneUser.User();
            //泛型类
            Apple apple = new Apple() { Size = "Big" };
            Book book = new Book() { Name = "Tom" };
            Box<Apple> box = new Box<Apple> { t = apple };
            Box<Book> box1 = new Box<Book> { t = book };
            Console.WriteLine(box.t.Size);
            Console.WriteLine(box1.t.Name);
            //泛型接口
            Stu1<int> stu = new Stu1<int>() { name = "泛型接口1", uid = 1 };
            Stu2 stu2 = new Stu2() { name = "泛型接口2", uid = 2 };
            Console.WriteLine(stu.name);
            //泛型方法
            int[] ints1 = { 1, 3, 5, 7 };
            int[] ints2 = { 10, 20, 30 };
            var res1=Zip(ints1 ,ints2);
            Console.WriteLine(string.Join(",",res1));
            //泛型委托
            Action<string> action = new Action<string>(Say);
            action.Invoke("Tom");
            Func<int,int,int> func =new Func<int, int, int>(Add);
            var res = func(1, 2);
            Console.WriteLine($"Result={res}");

        }

        //泛型委托Action Func
        static void Say(string name) { Console.WriteLine("hello, "+name); }
        static int Add(int a,int b) { return  a + b; }
        //泛型方法
        static T[] Zip<T>(T[] a, T[] b)
        {
            T[] zipped= new T[a.Length+b.Length];
            int ai = 0, bi = 0, zi = 0;
            do
            {
                if (ai < a.Length)
                {
                    zipped[zi++] = a[ai++];
                }
                if (bi < b.Length)
                {
                    zipped[zi++]=b[bi++];
                }
            }while (ai < a.Length || bi < b.Length);
            return zipped;
        }

        //数组形参
        static int CalSum(params int[] nums) {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++) { 
                sum+= nums[i];
            }
            return sum;
        }

    }
 
    //泛型类
    class Apple
    {
        public string Size { get; set; }
    }
    class Book
    {
        public string Name { get; set; }
    }
    class Box<T>
    {
        public T t { get; set; }
    }
    //泛型接口
    interface IUnique<UId>
    {
        UId uid { get; set; }
    }
    class Stu1<UId> : IUnique<UId> { 
       public UId uid { get; set; }
        public string name { get; set; }
    }
    class Stu2 : IUnique<ulong>
    {
        public ulong uid { get; set; }
        public string name { get; set; }
    }



    //interface
    interface IPhone
    {
        void Diag();
        void Ring();
    }
     class MotoPhone : IPhone
    {
        public void Diag()
        {
            Console.WriteLine("MotoPhone Diag...");
        }

        public void Ring()
        {
            Console.WriteLine("MotoPhone Ring...");
        }
    }
     class NokaiPhone : IPhone
    {
        public void Diag()
        {
            Console.WriteLine("NokiaPhone Diag...");
        }

        public void Ring()
        {
            Console.WriteLine("NokiaPhone Ring...");
        }
    }
    class PhoneUser
    {
        private IPhone iphone { get; set; }
        public PhoneUser(IPhone phone)
        {
            this.iphone = phone;
        }
        public void User()
        {
            iphone.Ring();
            iphone.Diag();
        }
    }

    //扩展方法
    public static class DoubleExtension {
        public static double Round(this double x, int y)
        { 
            return Math.Round(x, y);
        }
    }

}
