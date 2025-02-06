
using ClassLib.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLib.OOPoverride;
namespace Timthy_01
{
    class Student
    {
        public int Id { get; set; }
        public ConsoleColor PenColor { get; set; }
        public void DoWork()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.ForegroundColor = this.PenColor;
                Console.WriteLine($"Student {Id} do work {i} hours");
                Thread.Sleep(1000);
            }
        }
    }
   
    //继承
    //class Vehical
    //{
    //    public string Owner { get; set; }
    //    public Vehical()
    //    {
    //        Owner = "N/A";
    //    }
    //    public Vehical(string owner)
    //    {
    //        Owner= owner;
    //    }
    //}
    //class Car : Vehical {
    //    public Car()
    //    {
    //        Owner = "car owner";
    //    }
    //    public Car(string owner):base(owner) { }
    //    public void ShowOwner()
    //    {
    //        Console.WriteLine(Owner);
    //    }
    //}
    //class Bus : Vehicle
    //{
    //    public void SlowAccelerate()
    //    {
    //        Burn(1);
    //        _rpm += 500;
    //    }
    //}

    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int value)
        {
            Value = value;
        }
    }
    

    public class Program
    {
        public static void Main(string[] args)
        {
            //Student student = new Student() { Id = 1, PenColor = ConsoleColor.Green };
            //Student student2 = new Student() { Id = 2, PenColor = ConsoleColor.Yellow };
            ////student.DoWork();
            //////Action action = () => student2.DoWork();
            ////Action action = new Action(student2.DoWork);
            ////action();
            //Action action = () => student.DoWork();
            //Action action2 = () => student2.DoWork();
            //action.BeginInvoke(null, null);
            //action2.BeginInvoke(null, null);

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.ForegroundColor = ConsoleColor.Cyan;
            //    Console.WriteLine($"main function {i}");
            //    Thread.Sleep(500);
            //}

            //Calculator calculator = new Calculator();
            //Console.WriteLine(calculator.Add(1, 2));

            //Car car = new Car("BMW");
            //car.ShowOwner();

            //Car car = new Car();
            //car.TurboAccelerate();
            //Console.WriteLine(car.Speed);
            //Bus bus = new Bus();
            //bus.SlowAccelerate();
            //Console.WriteLine(bus.Speed);

            ////DFS BFS
            //var values = Enumerable.Range(0,10).ToArray();
            //var bst =GetTree(values,0,values.Length-1);
            //DFS(bst);
            //Console.WriteLine("=======================");
            //BFS(bst);
            //横向扩展成员多，纵向扩展版本改变
            Vehical1 v = new Car1();
            v.Run();
            Console.WriteLine(v.Speed);


        }
        static Node GetTree(int[] values,int li,int hi)
        {
            if (li > hi) { return null; }
            var mi = li+(hi-li)/2;
            var node =new Node(values[mi]);
            node.Left=GetTree(values, li, mi-1);
            node.Right=GetTree(values, mi+1,hi);
            return node;
        }
        static void DFS(Node node)
        {
            if (node == null) return;   
            DFS(node.Left);
            Console.WriteLine(node.Value);
            DFS(node.Right);
        }
        static void BFS(Node root)
        {
            var q=new Queue<Node>();    
            q.Enqueue(root);
            while (q.Count > 0) { 
                var node = q.Dequeue();
                Console.WriteLine(node.Value);
                if (node.Left != null)  q.Enqueue(node.Left);
                if(node.Right!= null) q.Enqueue(node.Right);
            }
        }
    }
}
