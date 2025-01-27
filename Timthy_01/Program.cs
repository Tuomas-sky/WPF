using ClassLib.MyNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.Add(1,2));




        }
    }
}
