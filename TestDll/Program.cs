using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestDll
{

    //委托-事件
    //1、定义一个委托，作为事件的基础
    public delegate void NotificationHandler(string msg);
    //2、发布者类
    public class Publisher
    {
        //3、 定义基于自定义委托的事件   
        public event NotificationHandler Notify;
        //4、触发事件的方法
        public void OnNotify(string msg) {
            Console.WriteLine($"正在触发通知：{msg}");
            Notify?.Invoke(msg);
        }
    }
    //5、订阅者类
    public class Listener
    {
        private Publisher _publisher;
        public Listener(Publisher publisher) { 
            _publisher = publisher;
            _publisher.Notify += HandleNotification;
        }

        private void HandleNotification(string msg)
        {
            Console.WriteLine($"收到通知: {msg}");
        }
        private void Unregister() { 
            _publisher.Notify -= HandleNotification;
        }
    }


    internal class Program
    {
        public delegate void CSCallback(int tick);
        public static void CSCallbackFunction(int tick)
        {
            Console.WriteLine(tick.ToString());
        }
        //定义一个委托类型的实例，
        //在主程序中该委托实例将指向前面定义的CSCallbackFunction方法
        public static CSCallback callback;
        [DllImport("cppdll.dll",CharSet=CharSet.Auto,CallingConvention =CallingConvention.Cdecl)]
        public extern static void SetCallback(CSCallback callback);
        [DllImport("cppdll.dll",CharSet=CharSet.Auto,CallingConvention =CallingConvention.Cdecl)]
        public extern static int Add(int x, int y);
        [DllImport("cppdll.dll",CharSet = CharSet.Auto,CallingConvention =CallingConvention.Cdecl)]
        public extern static void SayHello([MarshalAs(UnmanagedType.LPStr)] string name);//通过 DllImport 属性从*.dll 中导入，必须和dll提供的接口的名字保持一致

        //传递结构体等复杂结构需要使用内存布局

        [StructLayout(LayoutKind.Sequential)]
        public struct MyStruct
        {
            public int x;
            public int y;
        }
        //PInvoke调用C运行时库中的messagebox函数
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        // public extern static int MessageBox(int hwnd,string text,string caption,int type);
        public extern static int MessageBox(IntPtr hwnd,ref MyStruct myStruct,string caption,int type);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //C#端：定义委托并将其传递给C++。（通过RegisterCallback函数传递过去）
        //C++端：接受函数指针并调用它。
        //
        //C#向C++传递委托，C#委托作为回调函数传递给C++
        //定义与函数指针匹配的委托
        public delegate int Callback(int x,int y);
        //用于回调函数
        public static int MyCallback(int x, int y)
        {
            Console.WriteLine($"C# Callback called with values: {x}, {y}");
            return x + y;
        }
        [DllImport("cppdll.dll",EntryPoint = "RegisterCallback", CharSet = CharSet.Auto,CallingConvention =CallingConvention.Cdecl)]
        public extern static void RegisterCallback(IntPtr callback);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //C++端：提供函数指针。
        //C #端：将函数指针转换为委托并调用。
        //C#代码：接收并调用C++的函数指针
        public delegate int FuncPtr(int x, int y);
        [DllImport("cppdll.dll",EntryPoint= "GetFuncPtr", CharSet=CharSet.Auto,CallingConvention =CallingConvention.Cdecl)]
        public extern static IntPtr GetFuncPtr();

        //回调机制
        public delegate void FileProcessCallbcak(string msg);
        //事件处理
        public class Button
        {
            public event EventHandler Click;
            public void OnClick()
            {
                Console.WriteLine("事件被点击");
                Click?.Invoke(this, EventArgs.Empty);
            }
        }



        static void Main(string[] args)
        {
            ////在CS的主程序中让callback指向CSCallbackFunction方法，代码如下所示：
            ////调用委托所指向的方法
            //callback = new CSCallback(CSCallbackFunction);
            ////将委托传递给C++
            //SetCallback(callback);
            ////SetCallback方法被执行后，在C#中定义的CSCallbackFunction就会被C++所调用。
            //  Console.WriteLine(Add(1,2));
            //int res = MessageBox(0, "content-wpf", "Title-ShowMsg", 0);
            //MyStruct myStruct = new MyStruct() { x = 101, y = 220 };
            //MessageBox(IntPtr.Zero, ref myStruct, "复杂数据类型", 0);
            //SayHello("Tom");

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///通过委托，C#可以将方法传递给C++进行回调，C++也可以将函数指针传递给C#，并在C#中调用
            ///
            ////创建委托实例并转换为函数指针
            //Callback cb=new Callback(MyCallback);
            //IntPtr cbptr = Marshal.GetFunctionPointerForDelegate(cb);
            //RegisterCallback(cbptr);
            //GC.KeepAlive(cb);//避免委托被回收
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //IntPtr ptr = GetFuncPtr();
            //FuncPtr func = (FuncPtr)Marshal.GetDelegateForFunctionPointer(ptr,typeof(FuncPtr));
            //int result = func(15, 7);
            //Console.WriteLine($"Result from C++ function: {result}");

            ////回调机制
            //string filename = "test.txt";
            //ProcessFile(filename, OnFileProcessed);
            //事件处理
            //var btn = new Button();
            //btn.Click += Btn_Click;
            //btn.Click += Btn_Click1;//多播委托
            //btn.OnClick();

            //Publisher publisher = new Publisher();
            //Listener listener = new Listener(publisher);
            //publisher.OnNotify("模拟订阅");


            Console.ReadKey();
        }

        private static void Btn_Click1(object sender, EventArgs e)
        {
            Console.WriteLine("处理按钮点击事件11111");
        }

        private static void Btn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("处理按钮点击事件");
        }

        static void ProcessFile(string filename,FileProcessCallbcak cb)
        {
            Console.WriteLine($"正在处理文件：{filename}");
            cb("文件处理完成");
        }
        static void OnFileProcessed(string msg) {
            Console.WriteLine(msg);
        }
   
    
    }
}
