using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace framework_06_Page_navigation
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            _timeTextBlock.Text = DateTime.Now.ToString();
        }
        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //有3种方式可以导航到Page2，但是我们选择了第二种
            //注意Page2被实例化后，在每次前进或后退的操作中，Page2的时间是不会变化的
            //这是因为导航日志记录了当前页面。
            //第Page1和Page3每次进入时，时间都会发生变化

            //第1种导航方式
            //NavigationService ns = NavigationService.GetNavigationService(this);
            //ns.Navigate(new Uri("Page2.xaml", UriKind.Relative));

            //第2种导航方法
            Page2 page2 = new Page2();
            this.NavigationService.Navigate(page2);

            //第3种导航方式
            //this.NavigationService.Navigate(new Uri("Page2.xaml", UriKind.Relative));

        }
    }
}
