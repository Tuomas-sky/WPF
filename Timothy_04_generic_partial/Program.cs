using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timothy_04_generic_partial
{
    public class Program
    {
        static void Main(string[] args)
        {
            //泛型类
            Apple apple = new Apple() { Color = "Red" };
            Book book = new Book() { Name = "New Book" };
            Box<Apple> box1 = new Box<Apple>() { Cargo=apple};
            Box<Book> box2 = new Box<Book>() {Cargo=book};
            Console.WriteLine(box1.Cargo.Color);
            Console.WriteLine(box2.Cargo.Name);
            Console.WriteLine("======================================");

            //泛型接口
            Stu1<int> stu1 = new Stu1<int>();
            stu1.Id = 1;stu1.Name = "Tim";
            Stu2 stu2 = new Stu2();
            stu2.Id = 2; stu2.Name = "Tom";
            Console.WriteLine(stu1.Name);
            Console.WriteLine(stu2.Name);
            Console.WriteLine("======================================");

            //泛型集合
            IDictionary<int,string> dict = new Dictionary<int,string>();
            dict[1] = "cpp";
            dict[2] = "csharp";
            Console.WriteLine($"#1 is {dict[1]}");
            Console.WriteLine($"#2 is {dict[2]}");
            Console.WriteLine("======================================");

            //泛型方法
            int[] ints = { 1, 2, 3, 4 };
            int[] ints2 = { 1,2,3,4 };
            double[] doubles = { 1.1, 2.2, 3.3 };
            double[] doubles2 = { 1.1, 2.2, 3.3 };
            var zip = Zipped(ints, ints2);
            Console.WriteLine(string.Join(",",zip));
            var zip2 = Zipped(doubles, doubles2);
            Console.WriteLine(string.Join(",", zip2));
            Console.WriteLine("======================================");

            //泛型委托 Action & Func
            Action<string> say = new Action<string>(Say);
            say.Invoke("Tim");
            Func<int,int,int> add = new Func<int, int, int>(Add);
            var res = add(1,2);
            Console.WriteLine(res);
            Func<double, double, double> sub =(x, y) => { return x - y; };
            Console.WriteLine(sub(20,10));
            //自定义
            MyDele<int> mydele = new MyDele<int>(Add);
            var res2 = mydele(10,20);
            Console.WriteLine(res2);

            DoDele((int a,int b) 
                => { return a + b; },
                100,200);
            Console.WriteLine("======================================");
            //L




            //enum
            Person p = new Person();
            p.Name = "Test";
            p.Level = Level.Medium;
            p.Skill = (Skill.Teach | Skill.Cook | Skill.Program | Skill.Drive);
            Console.WriteLine((int)p.Skill);
            Console.WriteLine((p.Skill & Skill.Program) == Skill.Program);
            Console.WriteLine("======================================");
            //struct,值类型copy的是一个完整的对象，和引用类型不同引用类型copy的是对同一个对象的引用
            S s1 = new S() { Id = 1001,Name="Dan" };
            //装箱
            object obj = s1;
            //拆箱
            S s2 = (S)obj;
            S s3 = s1;//copy的是完整对象，不是对同一个对象的引用---值类型
            s3.Id = 2002;
            s3.Name = "Jenny";
            Console.WriteLine($"Id=#{s1.Id} , name={s1.Name}");
            Console.WriteLine($"Id=#{s3.Id} , name={s3.Name}");
            s1.Speak();
            Console.WriteLine("======================================");





        }

        //泛型委托
        static void Say(string str)
        {
            Console.WriteLine($"hello , {str}");
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static void DoDele<T>(Func<T,T,T> func,T x,T y)
        {
           var ret = func(x, y);
            Console.WriteLine(ret);
        }

        //泛型方法
        static T[] Zipped<T> (T[] arr1, T[] arr2)
        {
            T[] zipped = new T[arr1.Length+arr2.Length];
            int ai = 0, bi = 0, zi = 0;
            do
            {
                if(ai<arr1.Length) zipped[zi++] = arr1[ai++];
                if(bi<arr2.Length) zipped[zi++]= arr2[bi++];

            } while (ai < arr1.Length || bi < arr2.Length);

            return zipped;
        }
    }

    //枚举和结构
    //enum
    enum Level
    {
        Small,
        Medium,
        Big,
    }
    enum Skill//eunm的比特位用法
    {
        Teach=1,
        Program=2,
        Cook=4,
        Drive=8,
    }

    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Level Level { get; set; }

        public Skill Skill { get; set; }

    }

    //struct ，可以实现接口
    interface ISpeak
    {
        void Speak();
    }
    struct S:ISpeak
    {
        //public S() { }//struct不能有显示的无参构造器，但是有参的可以
        public S(int id,string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public void Speak()
        {
            Console.WriteLine($"I'm #{Id},name={Name}");
        }
    }

    /// ///////////////////////////////////////////////////////////////////////////

    //泛型类
    public class Box<TCargo>
    {
        public TCargo Cargo { get; set; }
    }
    public class Apple
    {   
        public string Color { get; set; }
    }
    public class Book
    {
        public string  Name { get; set; }   
    }

    /// ///////////////////////////////////////////////////////////////////////////
    //泛型接口
    interface IUnique<TId>
    {
        TId Id { get; set; }
    }
    //实现泛型接口
    public class Stu1<TId> : IUnique<TId>
    {
        public TId Id { get ; set ; }
        public string Name { get; set; }
    }
    //特化泛型接口
    public class Stu2 : IUnique<ulong>
    {
        public ulong Id { get; set; }
        public string Name { get; set; }    
    }

    /// ///////////////////////////////////////////////////////////////////////////
    //泛型委托
    delegate T MyDele<T>(T x,T y);


}
