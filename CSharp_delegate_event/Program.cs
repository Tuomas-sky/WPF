using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_delegate_event
{
    
    public delegate void GreetDelegate(string name);
    public class DelegateManager
    {
        //event可以看作类似于对委托的封装（=>属性是对字段的封装）
        //public GreetDelegate dele; //定义了一个委托，但是其访问权限public or private不好把控，于是有了event对其处理包装
        public event GreetDelegate MakeGreet;
        public void Greet(string name)
        {
            if (MakeGreet != null) { MakeGreet(name); }
        }
    } 

    //Observer 模式 demo1
    public class Heater
    {
        private int temperature;
        public delegate void BoilHandler(int para);
        public event BoilHandler BoilEvent;
        public void BoilWater()
        {
            for (int i = 0; i < 100; i++) {
                temperature = i;
                if (temperature > 95)
                {
                    BoilEvent(temperature);
                }
            }
        }
    }
    public class Alerm
    {
        public void MakeAlerm(int para) {
            Console.WriteLine($"Alerm: temperature={para}");
        }
    }
    public class Display
    {
        public static void ShowMsg(int msg) { Console.WriteLine($"display={msg}"); }
    }

    //demo2
    public class EventDemo
    {
        public event Action PropertyChanged;
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value;  PropertyChanged?.Invoke(); Console.WriteLine(value); }
        }

    }

    //demo3 发布器publisher 订阅器subscriber
    public delegate void NotifyEventHandler(object sender ,EventArgs e);
    public class Publisher
    {
        public event NotifyEventHandler ProcessComplated;
        public virtual void OnProcessCompalted(EventArgs e)//触发事件的方法
        {
            if (ProcessComplated != null) ProcessComplated(this, e);
        }
        public void StartProcess()//业务逻辑
        {
            Console.WriteLine("Begin Process...");
            OnProcessCompalted(EventArgs.Empty);
        }
    }
    public class Subscriber
    {
        //绑定事件
        public void Subscribe(Publisher publisher) {
            publisher.ProcessComplated += Publisher_ProcessComplated;
        }

        private void Publisher_ProcessComplated(object sender, EventArgs e)
        {
            Console.WriteLine("Process Complated!");
        }
    }

    internal class Program
    {
        static void EnglishGreet(string name) {
            Console.WriteLine($"hello , {name}");
        }
        static void ChineseGreet(string name) {
            Console.WriteLine($"你好 ， {name}");
        }
        static void Main(string[] args)
        {
            //使用委托可以将多个方法绑定到同一个委托变量，调用此变量时可依次调用所有的绑定的方法
            //GreetDelegate greet =new GreetDelegate(EnglishGreet);
            //greet += ChineseGreet;
            //greet("Tom");
            //Console.WriteLine();
            //greet -= EnglishGreet;
            //greet("委托变量");
            ///
            //DelegateManager greet = new DelegateManager();
            //greet.MakeGreet += EnglishGreet;
            //greet.MakeGreet += ChineseGreet;
            //greet.Greet("Dan");

            //Heater heater = new Heater();
            //Alerm alerm = new Alerm();
            //heater.BoilEvent += alerm.MakeAlerm;
            //heater.BoilEvent += (new Alerm()).MakeAlerm;
            //heater.BoilEvent += Display.ShowMsg;
            //heater.BoilWater();

            ////事件最常用的方法就是某个类中某个成员发生变化，类外面希望对变换的类型进行监测
            //var ed=new EventDemo();
            //ed.PropertyChanged += () => { Console.WriteLine("value changed"); };
            //ed.Age = 10;
            //ed.Age = 20;

            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber();
            subscriber.Subscribe( publisher );//订阅事件
            publisher.StartProcess();
            

        }
    }
}
