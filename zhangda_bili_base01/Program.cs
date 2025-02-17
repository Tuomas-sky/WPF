using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zhangda_bili_base01.Data;

namespace zhangda_bili_base01
{
   
    class Stu1
    {
        public int Id { get; set; }
    }

    public class Stu
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
    }


    public class Program
    {
        //static
        public void ReadStaticData()
        {
            Console.WriteLine(Data.SystemData.UserName);
        }

        //struct
        struct StuStruct
        {
            //struct 中不能对字段直接进行初始化，可通过构造函数对所有字段和属性进行赋值
            //也可以通过结构名称直接给字段赋值，通过new 对象给属性赋值
            //结构不能有显示的无参构造函数,因为结构的默认无参构造函数不会消失  
            //public StuStruct() { }
            //public int age=1001;
            public int _age;
            public string _name;
            public StuStruct(int age, string name)
            {
                _age = age;
                _name = name;
                Address = "address";
                Heigh = 100;
                Width = 200;
            }
            //如果给结构里的属性赋值的时候，要将数据取出来然后赋值之后再塞回去
            //类似于
            //Point point = new Point();
            //point.X = 10;
            //    point.Y = 20;
            //    point = point;
            public string Address { get; set; }
            public int Heigh { get; set; }
            public int Width { get; set; }  
        }

        static void Show(Sex sex)
        {
            switch(sex)
            {
                case Sex.Man:
                    Console.WriteLine("man");
                    break;
                case Sex.Women:
                    Console.WriteLine("women");
                    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
//args用于接收exe运行时cmd后边接收的参数
            {
                //foreach (string arg in args)
                //{
                //    Console.WriteLine(arg);
                //}
            }

            //string字符串：C#认为是一个字符数组，实际上是一个类，new String(new char[]{'a','s','d'});
#if false
            {
               

                //判断是不是同一个对象,object.ReferenceEquals(),但是强制new String()就不会相同
                string str1 = "abc";
                string str2 = "abc";
                Console.WriteLine(object.ReferenceEquals(str1 ,str2));//true
                string str3 = new String(new char[] { 'a', 'b', 'c' });
                Console.WriteLine(object.ReferenceEquals(str1,str3));//false
                //C#中，所有的基本类型都可以使用==来判断内容是否相同
                Console.WriteLine(str1==str2);//true
                Console.WriteLine(str1==str3);//true

                //C#字符串中常见的方法
                string str = "asd,,,fg?asd.fg";
                Console.WriteLine(str.Length);//
                Console.WriteLine(str.ToUpper());//转大写
                Console.WriteLine(str.ToLower());//转小写
                Console.WriteLine(str.Substring(3));//截取字符串，从start位置到最后
                Console.WriteLine(str.Substring(3,4));//截取字符串，从start位置开始截取4个
                Console.WriteLine(str.IndexOf("as"));//查找字符位置，从0到最后，找到返回下标，找不到返回-1
                Console.WriteLine(str.IndexOf('s',1));//查找字符位置，从index到最后，找到返回下标，找不到返回-1
                Console.WriteLine(str.IndexOf('s',1,5));//查找字符位置，从index往后找count个，找到返回下标，找不到返回-1
                Console.WriteLine(str.Contains("asd"));//bool类型，判断"asd"是否在str中出现过
                Console.WriteLine(str.LastIndexOf('a'));//从后往前找
                Console.WriteLine($"str.length={str.Split(',', '?', '.').Length}");
                foreach (var c in str.Split(',', '?', '.')) //按照指定字符进行切分，
                    Console.WriteLine(c);
                Console.WriteLine("---------------------------");
                Console.WriteLine($"str.length={str.Split(new char[] { ',', '?', '.' }, StringSplitOptions.RemoveEmptyEntries).Length}");
                foreach (var item in str.Split(new char[] { ',', '?', '.' }, StringSplitOptions.RemoveEmptyEntries))//移除空白项
                {
                    Console.WriteLine(item);
                }
                ////拼接操作,大数据建议使用StringBuilder快很多，+操作的话更耗时,
                //StringBuilder sb = new StringBuilder();
                //Console.WriteLine($"StringBuilder start time={DateTime.Now.ToString("G")}");
                //for (int i = 0; i < 10000000; i++)
                //{
                //    sb.Append(i);
                //}
                //Console.WriteLine($"StringBuilder end time={DateTime.Now.ToString("G")}");
                //string strtime = "";
                //Console.WriteLine($"++opration start time={DateTime.Now.ToString("G")}");
                //for(int i = 0; i < 50000; i++)
                //{
                //    strtime += i;
                //}
                //Console.WriteLine($"++opration end time={DateTime.Now.ToString("G")}");

                //拼接操作
                int age = 10;
                string name = "tim";
                string stradd=string.Format($"name={0} ,age={1}",name,age);
                Console.WriteLine(stradd);

                //enum:一组有限的值，保护了数据的有效性 
                Show(Sex.man);
                Show((Sex)Enum.Parse(typeof(Sex),"women"));//将输入的字符串解析为enum类型进行传递
                Show((Sex)0);//通过数字进行传递


            }

#endif
            //值类型&引用类型& ref & out & static & struct  key-value键值对
#if false
            {
                //1、值类型 byte/char/short/int/long/float/double/ decimal/bool /enum/struct === 存放在栈内存，空间小
                //装箱 值->引用
                //引用类型 数组/类/接口/委托/事件 ===存放在堆内存，空间大
                object obj = 1; object obj2 = "hello";
                //拆箱 引用->值
                int i=(int)obj; string s=(string)obj2; Console.WriteLine($"{i}  ,{s}");
                //值和引用对应 的内地址是不同的
                int age1 = 10; int age2 = age1;
                Console.WriteLine(object.ReferenceEquals(age1,age2));//false-值类型
                string str1 = new string(new char[] {'a','b','c'});
                string str2 = str1;
                Console.WriteLine(object.ReferenceEquals(str1,str2));//true-引用类型
                str1 += "!";//+操作开辟了新的内存空间,创建了新的对象，和原来的str2的控件不一样了，导致object.ReferenceEquals(str1,str2)结果为true
                Console.WriteLine($"{str1}   {str2}");

                //2、ref关键字：再调用方法的内部修改外部的 “值类型” 数据

                //3、out关键字：在方法的内部输出除返回值以外的数据
                //Console.WriteLine("输入一个数字：");
                //string num = Console.ReadLine();
                //int res;
                //if (int.TryParse(num, out res))
                //{
                //    Console.WriteLine($"input={num}");
                //}
                //else
                //{
                //    Console.WriteLine("输入有误");
                //}

                //4、static
                //I 静态字段/静态属性
                //  ①项目共享数据；
                //II 整个系统只有一份，在项目执行成功之后字段初始化
                //III 静态类->成员必须都是静态
                //Ⅳ 扩展方法，必须在静态类中,调用时两种写法

                //Console.WriteLine("输入用户名：");
                //Data.SystemData.UserName=Console.ReadLine();
                //new Program() .ReadStaticData();
                Console.WriteLine(  2.CompareInt(5)  );
                Console.WriteLine(Data.SystemData.CompareInt(4,2));
                Console.WriteLine("99".ParseInt()+100);
                Console.WriteLine(Data.SystemData.ParseInt("12333"));

                //5、//struct 中不能对字段直接进行初始化，可通过构造函数对所有字段和属性进行赋值
                //也可以通过结构名称直接给字段赋值，通过new 对象给属性赋值
             
            }
#endif

            //集合
#if false
            {
                ////1、可以伸缩 ArrayList-不推荐，因为其参数太大 object类型
                //ArrayList li = new ArrayList();
                //li.Add(11);li.Add(12);li.Add(13);
                //Console.WriteLine(li.Count);
                ////取值用下标
                //Console.WriteLine(li[0]);
                

                //2、List-推荐使用的泛型集合，具有数组类型的一致性，集合的可伸缩性，更多好用的方法
                //2.1 Romove() 删除数据后，会重新整理下标，数据会往前移
                List<int> list = new List<int>();
                list.Add(1);list.Add(2);list.Add(3);list.Add(4); list.Add(5);   
                list.Remove(1); list.Remove(1);//通过数据本身删除一个元素，可重复删除
                list.RemoveAt(2);
                //foreach(int i in list) 
                //    Console.WriteLine(i);
                //list.RemoveAll(m => m > 0);
                //Console.WriteLine($"list RemoveAll:{list.Count}");
                Console.WriteLine();

                //2.2 Insert() 在指定位置插入指定元素
                list.Insert(2, 20);
                foreach (int i in list.OrderBy(m=>m))//数据本身升序排序
                    Console.WriteLine(i);

                List<Stu1 > stu = new List<Stu1>();
                stu.Add(new Stu1() { Id = 1001 });
                stu.Add(new Stu1() { Id = 1002 });
                stu.Add(new Stu1() { Id = 1003 });
                stu.Add(new Stu1() { Id = 1004 });
                // stu.Remove(new Stu1() { Id = 1001 });//元素为对象时，不可以使用新创建的数据类型相同的对象，来移除原有的对象，因为这是两个不同 的对象
                Console.WriteLine($"remove前：{stu.Count}");
                stu.Remove(stu[0]);//通过数据删除
                stu.RemoveAt(0);//通过下标删除，小心数据量是否和下标匹配，不匹配会出现error
                Console.WriteLine($"remove后：{stu.Count}");

                //2.3 Clear / RemoveAll(pre) 删除所有元素
                stu.Clear();//清空所有元素
                //list.RemoveAll(list.Contains);//清空所有元素
                Console.WriteLine($"stu clear后：{stu.Count}");

                //2.4 List的一些基本方法
                Console.WriteLine(list.Sum());
                Console.WriteLine(list.Max());
                Console.WriteLine(list.Min());
                Console.WriteLine(list.Average());
                Console.WriteLine(list.Count(m=>m%2==0));

            }
#endif

            //Key-value Dictionary<K,V>字典.key不能重复
#if false
            {
                Dictionary<string,string> dic = new Dictionary<string,string>();
                //1、Add() 增加元素 ContainsKey(Key)-是否包含Key元素

                dic.Add("1", "123");dic.Add("2", "abc");
                if (dic.ContainsKey("1"))
                {
                    Console.WriteLine("已经存在");
                }
                else
                {
                    dic.Add("1", "222");
                }
                Console.WriteLine(dic.Count);
               // Console.WriteLine(dic["1"]);
               foreach(var item in dic)
                {
                    var str = string.Format($"key={0},value={1}",item.Key,item.Value);
                    //Console.WriteLine($"key={item.Key},value={item.Value}");
                    Console.WriteLine(str);
                }

            }
#endif
            //C# base gengeric List<T>
#if false
            {
                List<string> list = new List<string> { "123", "ads3", "fsdkhfjhouj", "23" };
                //1、Where 获取所有满足条件的元素
                Console.WriteLine(list.Where(x => x.Length > 3).Count());
                foreach (var item in list.Where(m => m.Length > 3))
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("-------------------------------------");
                //2、First获得满足条件的第一个元素。如果没有匹配的元素会报错
                Console.WriteLine(list.First(m => m.Contains("23")));
                //3、FirstOrDefault获得满足条件的第一个元素。如果没有匹配的元素不会报错
                Console.WriteLine(list.FirstOrDefault(m => m.Contains("33")));
                Console.WriteLine("-------------------------------------");
                //4、Any 是否有任意一个元素满足 return bool
                Console.WriteLine(list.Any(m => m.Contains("00")));
                if (list.Any(m => m.Contains("asd")))
                {
                    Console.WriteLine(list.First(m => m.Contains("asd")));
                }
                else
                {
                    Console.WriteLine("查找的数据不存在");
                }
                Console.WriteLine("-------------------------------------");
                //5、All 是否所以元素满足
                Console.WriteLine(list.All(m => m.Length > 2));
                Console.WriteLine("-------------------------------------");
                //6、Count()返回个数 Count(pre)返回满足条件的个数
                Console.WriteLine(list.Count());
                Console.WriteLine(list.Count(m => m.Length > 2));
                Console.WriteLine("-------------------------------------");
                //7、OrderBy() 排序，默认升序,经常与Where一起使用
                foreach (var item in list.Where(m => m.Length > 2).OrderBy(m => m))
                {
                    Console.WriteLine(item);
                }
                //foreach (var item in list.Where(m => m.Length > 2).OrderByDescending(m => m))//降序
                //{
                //    Console.WriteLine(item);
                //}
                Console.WriteLine("-------------------------------------");
                //8、Take(n) 获取集合中 的前n个元素
                //skip(n) 跳过前n个元素后剩下的元素
                foreach (var item in list.Where(m => m.Length > 2).OrderBy(m => m).Skip(1).Take(2))
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("-------------------------------------");
                List<Stu> stus = new List<Stu> {
                new Stu(){Id=1,Name="Tim1",Age=15},
                new Stu(){Id=2,Name="Tim2",Age=25},
                new Stu(){Id=3,Name="Tim3",Age=35},
                new Stu(){Id=4,Name="Tim4",Age=45},
            };
                foreach (var stu in stus.Where(m => m.Age < 30).OrderByDescending(m => m.Age))
                {
                    Console.WriteLine(stu.Age);
                }
                var res = stus.Where(m => m.Age < 40).OrderByDescending(m => m.Age).First();
                Console.WriteLine($"Id={res.Id},Name={res.Name},Age={res.Age}");
                Console.WriteLine("-------------------------------------");

                //泛型类
                //GenericClass<int> gc = new GenericClass<int>();
                //gc.ShowTypename(12);
                GenericClass<Stu1> gc = new GenericClass<Stu1>();
                gc.ShowTypename(new Stu1());
                Console.WriteLine("-------------------------------------");







            }
#endif
            //C# 连接数据库
#if false
            {
                //1、创建连接
                SqlConnection con = new SqlConnection(@"server=.;database=QQDb;uid=sa;pwd=sa");
                try
                {
                    con.Open();
                }catch (Exception ex)
                {
                    Console.WriteLine("打开失败");
                    Console.WriteLine(ex.Message);
                }
                //2、创建指令
                //2.1 绑定连接对象
                //2.2 设置要执行的sql语句
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = con,
                    CommandText = "insert into qquser values('123','asd','getdata()',1,2)",
                };
                //执行cmd.ExecuteNonQuery()的sql语句并得到影响的行数（改动几行） insert delete update 
                Console.WriteLine(cmd.ExecuteNonQuery()); 
                //3、关闭连接
                con.Close();

            }
#endif

            //OOP
#if false
            {
                //1、继承：子承父业
                //2、重载overlode：方法名相同，参数不同

                //this. =>调用本类中 的所有成员   base. =>调用父类中的所有成员（排除私有成员）
                // this():子类构造函数调用其他构造函数 base():调用父类的构造函数
                Teacher t = new Teacher(1, "tim", Sex.Man, "bj");
                //3、多态
                //里氏替换原则：父类型变量可以接收子类型对象
                //4、重写 override
                Cat cat = new Cat();
                cat.Run();// new方法隐藏
                cat.Call();//override方法覆盖
                
                //Animal a=new Animal();
                //a.Run();
                //a.Call();
                Animal a2 = cat;
                a2.Run();// new方法隐藏
                a2.Call();
                //5、抽象方法：抽象类，虚方法
                //抽象方法必须写在抽象类中；抽象方法没有方法体；使用abstract关键字修饰；抽象类不能实例化；子类如果没有实现抽象类的全部方法，那么子类也要声明为抽象类
                //6、密封类 sealed-无法实现继承
            }


#endif
            //interface
#if false
            {
                //多实现：一个类可以实现多个接口；
                //单继承：一个类只能有一个父类（基类）
                //继承父类写在接口的前面，逗号分隔
                //接口也有继承关系，可以继承其他接口，子承父业
                //接口有相同的方法,需要分别实现
                //Demo demo = new Demo();
                //IA ia=demo as IA;
                //ia.Work();
                //IB ib =demo as IB;
                //ib.Work();
                //Worker worker = new Worker(); worker.Work();


            }


#endif

            //文件操作和xml
#if true
            {
                //1、该用法项目一般不用，直接使用微软提供的File

                //string filename = "./test.txt";
                //////1、建立管道-文件流
                ////FileStream fs = new FileStream(filename, FileMode.Create);
                //////2、创建写入器（水泵）-参数为管道，和文件流建立关系
                ////StreamWriter sw = new StreamWriter(fs);
                //////3、写入数据
                ////sw.WriteLine("第一句话");
                ////sw.WriteLine("第二句话");
                //////4、关闭写入器
                ////sw.Close();
                //////5、关闭管道
                ////fs.Close();
                ////1、创建管道
                //FileStream fs2 = new FileStream(filename, FileMode.Open);
                //////2、创建读取器-参数为管道
                ////StreamReader sr = new StreamReader(fs2);
                //////3、读取数据
                ////Console.WriteLine(sr.ReadToEnd());
                //////4、关闭读取器
                ////sr.Close();
                ////5、关闭管道
                //fs2.Close();
                //using用法
                ////2-1 使用using(),看是否实现了Disposable，可以省略sr.Close(),自动释放对象
                //using (FileStream fs = new FileStream("test.txt", FileMode.Open))
                //{
                //    using (StreamReader sr = new StreamReader(fs))
                //    {
                //        Console.WriteLine(sr.ReadToEnd());
                //    }
                //}

                //2.1File工具类-自动追加
                //File.WriteAllText("a.txt", "hello world");
                //Console.WriteLine(File.ReadAllText("a.txt"));
                ////2.2自己追加 ->AppendText
                //var writer = File.AppendText("b.txt");
                //writer.WriteLine("hello Csharp");
                //writer.Close();
                //Console.WriteLine(File.ReadAllText("b.txt"));
                //2.3判断文件是否存在
                //if (File.Exists("c.txt"))
                //{
                //    var write = File.AppendText("c.txt");
                //    write.WriteLine("文件已存在");
                //    write.Close();
                //    Console.WriteLine(File.ReadAllText("c.txt"));
                //    Console.WriteLine("文件存在，追加");
                //}
                //else
                //{
                //    File.WriteAllText("c.txt", "创建文件\n");
                //    Console.WriteLine("文件不存在，创建");
                //}
                //2.4 Copy拷贝
                //File.Copy("c.txt", "../cc.txt");
                ////2.5 Move移动--重命名操作
                //File.Move("b.txt", "bb.txt");
                //File.Delete("bb.txt");
                //File.GetCreationTime("c.txt");//获取文件创建时间

                ////3.FileInfo实体对象
                //FileInfo fi = new FileInfo("c.txt");
                //Console.WriteLine(fi.Length);
                //Console.WriteLine(fi.FullName);
                //Console.WriteLine(fi.Extension);

                //4、创建文件夹
                if (!Directory.Exists(@"aa\bb"))
                {
                    Directory.CreateDirectory(@"aa\bb");
                    Console.WriteLine("创建了");
                }
                else
                {
                    Console.WriteLine("已存在");
                }

                //查找指定目录下的文件
                var files = Directory.GetFiles(@"aa\bb");
                foreach (var file in files)
                {
                    //得到全路径
                    FileInfo fi = new FileInfo(file);
                    Console.WriteLine(fi.FullName);
                }
                Console.WriteLine("---------------------------");
                //查找文件夹下的文件夹
                var floder = Directory.GetDirectories(@"aa\bb");
               



            }
#endif



        }
    }
}
