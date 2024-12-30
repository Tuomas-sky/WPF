using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_01
{
    public class Test
    {
        


    }
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class Box
    {
        public Product product { get; set; }
    }
    public class Logger
    {
        public void Log(Product product)
        {
            Console.WriteLine($"{product.Name} is wraped at {DateTime.UtcNow},price:{product.Price}");
        }
    }

    public class WrapProduct
    {
        public Box wrapProduct(Func<Product> getProduct, Action<Product> log)
        {
            Box box = new Box();
            box.product = getProduct();
            double price = getProduct().Price;
            if (price > 20)
            {
                log(box.product);
            }
            return box;
        }
    }
    public class ProductFactor
    {
        public Product MilkProduct()
        {
            Product product = new Product() { Name = "Milk", Price = 55 };
            return product;
        }
        public Product FruitProduct()
        {
            Product product = new Product() { Name = "Fruit", Price = 30 };
            return product;
        }
    }


}
