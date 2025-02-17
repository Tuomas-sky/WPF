using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflection
{
    public class Student
    {
        public int age;
        public int Id { get; set; }

        public void Show1()
        {
            Console.WriteLine("Show1()");
        }
        public string Show2(string name)
        {
            return $"hello,{name}";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            //1、通过反射的方法可以遍历成员，调用成员
              {
                // object obj = new Student();
                //Type type = obj.GetType();
                //Console.WriteLine(type.Namespace);
                //Console.WriteLine(type.FullName);
                //Console.WriteLine(type.Name);
                //    Console.WriteLine("=============================");
                }
            //常用方法
            {  //GetFileds()获取所有公开字段
            //GetFiled(string name)获取特定名称
            //GetProperties()公开属性
            //GetProperty()特定属性
            //GetMethods() 公开方法
            //GetMethod()特定方法

            //MethodInfo常用方法
            //Invoke(obj,object[]参数列表) 调用
            }

            //反射对字段的作用
            {

                //foreach(var field in type.GetFields())
                //{
                //    if (field.Name == "age")
                //    {
                //        Console.WriteLine(field.Name);
                //        Console.WriteLine(field.FieldType.FullName);
                //        field.SetValue(obj, 26);
                //        Console.WriteLine(field.GetValue(obj));
                //    }
                //}
                ////获取特定字段
                //type.GetField("age").SetValue(obj, 30);
                //Console.WriteLine(type.GetField("age").GetValue(obj));
            }

            ////反射对属性的作用
            {
                //foreach (var item in type.GetProperties()) {
                //    Console.WriteLine(item.Name);
                //    Console.WriteLine(item.PropertyType.FullName);
                //    item.SetValue(obj, 1001);
                //    Console.WriteLine(item.GetValue(obj));
                //}
                ////获取特定属性
                //type.GetProperty("Id").SetValue(obj,2002);
                //Console.WriteLine(type.GetProperty("Id").GetValue(obj));
            }

            //反射对方法的作用
            {
                ////属性的本质 get set 方法
                //foreach (var method in type.GetMethods())
                //{
                //    Console.WriteLine(method.Name);
                //}
                //type.GetMethod("Show1").Invoke(obj, new object[0]);
                //var res = type.GetMethod("Show2").Invoke(obj, new object[] { "Tim" });
                //Console.WriteLine(res.ToString());
            }


            //2、通过dll加载，获取类型，然后创建对象.反射核心
            {
                //获取绝对路径
                //Environment.CurrentDirectory 获取程序集的完全限定路径，即exe所在的文件夹
                Console.WriteLine(Environment.CurrentDirectory + @"\StudentManager.UserManager.ClassLib.dll");
                //动态引用一个
                Assembly assembly = Assembly.LoadFile(Environment.CurrentDirectory + @"\StudentManager.UserManager.ClassLib.dll");
                //通过一系列is属性来过滤出自己需要的
                //foreach(var type in assembly.GetTypes())
                //{
                //    Console.WriteLine(type.FullName);
                //    Console.WriteLine(type.IsClass);
                //    Console.WriteLine(type.IsEnum);
                //}
                var user = assembly.GetTypes().First(m => !m.IsAbstract && m.IsClass);
                Console.WriteLine(user.FullName);
                //和1的区别===没有对象,是否可以自己生成？
                //创建对象
                object obj = assembly.CreateInstance(user.FullName);
                user.GetProperty("Age").SetValue(obj, 26);
                user.GetProperty("Name").SetValue(obj, "Tom");
                user.GetMethod("SayHi").Invoke(obj,new object[0] );



            }



        }
    }
}
