using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace framework_04_DependencyProperty_CallBack
{
    //使用依赖属性的回调函数

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in tray.SelectedItems)
            {
                MessageBox.Show($"{item.Name.ToString()} 移动坐标 = ({item.Tag.ToString()})");
            }
        }
    }
}