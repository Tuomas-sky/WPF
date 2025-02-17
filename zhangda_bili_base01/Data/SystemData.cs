using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhangda_bili_base01.Data
{
    public static class SystemData
    {
        public static string UserName { get; set; }

        //扩展方法
        public static int CompareInt(this int num, int other)
        {
            if (num > other) {
                return 1;
            }else if (num < other)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static int ParseInt(this string str)
        {
            return int.Parse(str);
        }


    }
}
