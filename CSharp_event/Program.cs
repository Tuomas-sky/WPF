using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CSharp_event
{
    public static class Program
    {
   
        [STAThread]
        static void Main()
        {
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.Action();
            customer.PayBill();

        }


    }

    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }
    //public delegate void OrderEventHandler(Customer sender, OrderEventArgs e);
    public class Customer
    {
        //private OrderEventHandler orderEventHandler;
        //public event OrderEventHandler Order
        //{
        //    add { orderEventHandler = value; }
        //    remove { orderEventHandler = value; }
        //}
        public event EventHandler Order;//事件的简略声明
        public double Bill { get; set; }
        public void PayBill() { Console.WriteLine($"I will pay ${Bill}."); }
        public void WorkIn() { Console.WriteLine("Work in..."); }
        public void SitDown() { Console.WriteLine("Sit down..."); }
        //触发事件一定是事件的拥有者触发
        public void Think()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Let me think...");
                Thread.Sleep(1000);
            }
            OnOrder("KK", "large");
        }
        //触发事件
        public void OnOrder(string dishname,string size)
        {
            //if (orderEventHandler != null)
            if (Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = dishname;
                e.Size = size;
                Order.Invoke(this, e);
            }
        }
        public void Action()
        {
            WorkIn();
            SitDown();
            Think();
        }

    }

    public class Waiter
    {
        //public void Action(Customer sender, OrderEventArgs e)
        public void Action(object sender, EventArgs e)
        {
            Customer customer = sender as Customer;
            OrderEventArgs order = e as OrderEventArgs; 
            Console.WriteLine($"I will server you the dish - {order.DishName}.");
            double price = 10;
            switch (order.Size)
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }
            customer.Bill += price;
        }
    }
}
