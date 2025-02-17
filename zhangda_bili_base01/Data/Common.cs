using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace zhangda_bili_base01.Data
{
    public enum Sex
    {
        Man,
        Women,
    }
    public class Common
    {

    }
    //对泛型加限制--泛型约束，where class/struct
    public class GenericClass<T> where T : class, new()
    {
        public void ShowTypename(T t)
        {
            T tt = new T();
            Console.WriteLine(typeof(T).FullName);
        }
    }

    public class Person
    {
        public Person(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Teacher : Person
    {

        public Teacher(int id, string name, Sex sex) : base(id, name) //通过base() 调用父类构造函数
        {
            this.Sex = sex;
        }

        public Teacher(int id, string name, Sex sex, string address) : this(id, name, sex)//通过this() 调用其他本类构造函数
        {
            this.Address = address;
        }

        public Sex Sex { get; set; }
        public string Address { get; set; }

    }

    ////////////////////////////////////////////////////////
    //继承
    public abstract class Animal
    {
        //new 关键字对方法进行隐藏，具体调用哪个方法看等号左边的类型（看点 =）
        public new void Run()
        {
            Console.WriteLine("Animal Run!");
        }
        //virtual 关键字对方法覆盖，用于多态，父类类型指向子类对象，子类方法使用override进行修饰
        //public virtual void Call()
        //{
        //    Console.WriteLine("Animal Call!");
        //}
        public abstract void Call();
    }
    public class Cat : Animal
    {
        public new void Run()
        {
            Console.WriteLine("Cat Run!");
        }

        public override void Call()
        {
            //base调用父类重写前的方法
            //base.Call();//不可以调用抽象方法
            Console.WriteLine("Cat Call!");
        }
    }
    //密封类 sealed
    public sealed class SealedClass { }
    //public class SonSealedClass : SealedClass { }//无法从密封类型"SealedClass"派生

    ////////////////////////////////////////////////////////////
    ///interface
    interface IA { void A(); void Work(); }

    interface IB { void B(); void Work(); }
    public class Demo : IA, IB
    {
        public void A() { Console.WriteLine("IA:A"); }
        public void B() { Console.WriteLine("IB:B"); }

        void IA.Work() { Console.WriteLine("IA.Work"); }//显示实现接口
        void IB.Work() { Console.WriteLine("IB:Work"); }

    }

    //赋予不同的身份
    interface IStudent { void Study(); }
    interface IWorker { void Work(); }
    interface ICustomer { void Eat(); }

    public class Student11 : IStudent, ICustomer
    {
        public void Study() { Console.WriteLine("Study()"); }
        public void Eat() { Console.WriteLine("Eat()"); }
    }
    public class Worker : IWorker
    {
        public void Work() { Console.WriteLine("Work()"); }
    }
}
