
using BabyStroller.SDK;
using System.Runtime.Loader;

namespace ReflectionBaby
{
    public class Program
    {
        static void Main(string[] args)
        {
            var folder = Path.Combine(Environment.CurrentDirectory, "Animals");//引入三方的类库
            Console.WriteLine(folder);
            var files = Directory.GetFiles(folder);
            Console.WriteLine(files.FirstOrDefault());
            var animalType = new List<Type>();
            foreach (var file in files)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
                var types = assembly.GetTypes();
                foreach (var type in types)
                {

                    if (type.GetInterfaces().Contains(typeof(IAnimal)))//&& !type.GetCustomAttributes(false).Contains(typeof(UnfinishedAttribute))
                    {
                        var isUnfinshed = type.GetCustomAttributes(false).Any(a=>a.GetType()==typeof(UnfinishedAttribute));
                        if (isUnfinshed) continue;
                        animalType.Add(type);
                    }
                    //if (type.GetMethod("Voice") != null)
                    //{
                    //    animalType.Add(type);
                    //}
                }
            }
            while (true)
            {
                for (int i = 0; i < animalType.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{animalType[i].Name}");
                }
                Console.WriteLine("===========================");
                Console.WriteLine("Please choose animals");
                int index = int.Parse(Console.ReadLine());
                if (index < 1 || index > animalType.Count)
                {
                    Console.WriteLine("No such animal.Try again");
                    continue;
                }
                Console.WriteLine("How much times?");
                int times = int.Parse(Console.ReadLine());
                var t = animalType[index - 1];
                //var m = t.GetMethod("Voice");
                var o = Activator.CreateInstance(t);
                var a=o as IAnimal;
                a.Voice(times);

               // m.Invoke(o, new object[] { times });

            }

#if false
 var folder = Path.Combine(Environment.CurrentDirectory, "Animals");//引入三方的类库
            Console.WriteLine(folder);
            var files = Directory.GetFiles(folder);
            var animalType=new List<Type>();
            foreach (var file in files)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.GetMethod("Voice") != null)
                    {
                        animalType.Add(type);
                    }
                }
            }
            while (true)
            {
                for (int i = 0; i < animalType.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{animalType[i].Name}");
                }
                Console.WriteLine("===========================");
                Console.WriteLine("Please choose animals");
                int index = int.Parse(Console.ReadLine());
                if (index < 1||index>animalType.Count)
                {
                    Console.WriteLine("No such animal.Try again");
                    continue;
                }
                Console.WriteLine("How much times?");
                int times = int.Parse(Console.ReadLine());
                var t = animalType[index-1];
                var m = t.GetMethod("Voice");
                var o =Activator.CreateInstance(t);
                m.Invoke(o,new object[] {times});

            }

#endif

        }
    }
}