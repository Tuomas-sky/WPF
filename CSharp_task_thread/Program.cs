using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp_task_thread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task task1 = new Task(() => { Thread.Sleep(100); Console.WriteLine($"thread_01 , id={Thread.CurrentThread.ManagedThreadId}"); });
            //task1.Start();
            //Task task2 = Task.Factory.StartNew(() => { Thread.Sleep(100); Console.WriteLine($"thread_02 , id={Thread.CurrentThread.ManagedThreadId}"); });
            //Task task3 = Task.Run(() => { Thread.Sleep(100); Console.WriteLine($"thread_03 , id={Thread.CurrentThread.ManagedThreadId}"); });
            //Console.WriteLine($"Main id={Thread.CurrentThread.ManagedThreadId}");
            //Task<int> task4 = new Task<int>(() => { Thread.Sleep(100); return 100; });
            //task4.Start();
            //Task<int> task5 = Task.Factory.StartNew(() => { Thread.Sleep(100); return 200; });
            //Task<int> task6 = Task.Run( () => { Thread.Sleep(100);return 300; });
            //Console.WriteLine("Task有返回值");
            //Console.WriteLine(task4.Result);
            //Console.WriteLine(task5.Result);
            //Console.WriteLine(task6.Result);
            //

            //Console.WriteLine("让Task同步执行，阻塞主线程");
            //Task task = new Task(() => { Thread.Sleep(100); Console.WriteLine("task 阻塞主线程"); });
            //task.RunSynchronously();
            //Console.WriteLine( "主线程执行结束");

            //Task阻塞主线程的方法 Wait / WaitAll / WaitAny,方便的控制阻塞线程 
            //Task t1 = new Task(() => { Thread.Sleep(100); Console.WriteLine("线程1执行完毕"); }); t1.Start(); 
            //Task t2 = new Task(() => { Thread.Sleep(100); Console.WriteLine("线程2执行完毕"); }); t2.Start();
            ////Task.WaitAll(t1,t2);
            //Task.WaitAny(t1,t2);
            //Console.WriteLine("主线程执行结束");

            ////Task的延续 WhenAny / WhenAll / ContinueWith(执行后续的操作)
            //Task t1 = new Task(() => { Thread.Sleep(100); Console.WriteLine("线程1执行完毕"); }); t1.Start();
            //Task t2 = new Task(() => { Thread.Sleep(100); Console.WriteLine("线程2执行完毕"); }); t2.Start();
            ////Task.WhenAll(t1, t2).ContinueWith((t) => { Thread.Sleep(100); Console.WriteLine("执行后续操作"); });
            //Task.Factory.ContinueWhenAll(new Task[] { t1, t2 }, (t) => { Thread.Sleep(100); Console.WriteLine("执行后续操作"); });
            //Console.WriteLine("主线程执行结束");

            ////Task任务取消CancellationtokenSource
            //int index = 0; bool isStop=false;
            //Thread thread = new Thread(
            //    () =>
            //    {
            //        while (!isStop) { 
            //            Thread.Sleep(1000);
            //        Console.WriteLine($"index={++index}");
            //        }
            //    }
            //    );
            //thread.Start();
            //Thread.Sleep(4000);
            //isStop = true;
            //Console.WriteLine("主线程执行结束");

            //CancellationTokenSource进行事件的通知
            //int index = 0;
            //CancellationTokenSource cancel = new CancellationTokenSource();
            ////注册任务取消的事件
            //cancel.Token.Register(() => { Console.WriteLine("任务被取消后执行的操作"); });
            //Task task = new Task(() =>
            //{
            //    while (!cancel.IsCancellationRequested) {
            //        Thread.Sleep(1000);
            //        Console.WriteLine($"index={++index}");
            //    }
            //});
            //task.Start();
            ////延时取消，效果等同于Thread.Sleep(5000);source.Cancel();
            //cancel.CancelAfter(5000);    
            ////Thread.Sleep(4000);
            ////cancel.Cancel();

            //async await
            //string content = GetContentAsync(Environment.CurrentDirectory + @"/result.txt").Result;
            //string content = GetContent(Environment.CurrentDirectory + @"/result.txt");
            //Console.WriteLine(content);

            //Console.WriteLine("begin");
            //DoWork();
            //Console.WriteLine("end");
            //Console.WriteLine("Starting concurrent asynchronous operations...");

            //// 启动多个异步任务
            //Task task1 = DoWorkAsync(1);
            //Task task2 = DoWorkAsync(2);
            //Task task3 = DoWorkAsync(3);
            //// 等待所有任务完成
            //Task.WhenAll(task1, task2, task3);
            //Console.WriteLine("All asynchronous operations finished.");

            ////parallel并发编程
            //Console.WriteLine("Starting parallel operation...");//并发编程
            //Parallel.For(0, 5, i =>
            //{
            //    Console.WriteLine($"Task {i} started by thread {Task.CurrentId}");
            //    Thread.Sleep(2000); // 模拟工作
            //    Console.WriteLine($"Task {i} completed by thread {Task.CurrentId}");
            //});
            //Console.WriteLine("Parallel operation finished.");


            Console.ReadKey();
        }
        static async Task DoWorkAsync(int taskNumber)
        {
            Console.WriteLine($"Task {taskNumber} started.");
            await Task.Delay(2000); // 模拟长时间操作
            Console.WriteLine($"Task {taskNumber} completed.");
        }
        async static Task DoWork()
        {
            await Task.Delay(3000);
            Console.WriteLine("Compalted");
        } 
        //异步方法
        async static Task<string> GetContentAsync(string name)
        {
            FileStream fs = new FileStream(name, FileMode.Open);
            var bytes = new byte[fs.Length];
            Console.WriteLine("开始异步读文件");
            int len = await fs.ReadAsync(bytes, 0, bytes.Length);
            string result = Encoding.UTF8.GetString(bytes);
            return result;  
        }
        static string GetContent(string name) { 
            FileStream fs =new FileStream(name, FileMode.Open);
            var bytes = new byte[fs.Length];
            Console.WriteLine("开始同步读文件");
            int len = fs.Read(bytes, 0, bytes.Length);
            string content = Encoding.UTF8.GetString(bytes);
            return content;
        }
    }
}
