using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timothy_02_interfce_abstract
{
    public interface IPhone
    {
        void Send();
        void Receive();
    }
    public class User
    {
        private IPhone _phone;
        public User(IPhone phone)
        {
            _phone = phone;
        }
        public void U() { _phone.Send(); _phone.Receive(); }
    }
    public class Ximi:IPhone
    {
        public void Send() {
            Console.WriteLine("send");
        }
        public void Receive() {
            Console.WriteLine("receive");
        }
    }
}