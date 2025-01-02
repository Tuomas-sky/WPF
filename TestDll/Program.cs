using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestDll
{
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

        static void Main(string[] args)
        {
            //在CS的主程序中让callback指向CSCallbackFunction方法，代码如下所示：
            //调用委托所指向的方法
            callback = new CSCallback(CSCallbackFunction);
            //将委托传递给C++
            SetCallback(callback);
            //SetCallback方法被执行后，在C#中定义的CSCallbackFunction就会被C++所调用。
            Console.ReadKey();
        }
    }
}
