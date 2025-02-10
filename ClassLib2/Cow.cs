using BabyStroller.SDK;

namespace ClassLib2
{
    [Unfinished]
    public class Cow:IAnimal
    {
        public void Voice(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("cow cow ..");
            }
        }
    }
}
