using System.ComponentModel;
using framework_05_RouteEvent.Controls;
using System.Runtime.CompilerServices;
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

namespace framework_05_RouteEvent
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = "") { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MainViewModel : ObservableObject
    {
        public MainViewModel() { }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Widget_Completed(object sender, RoutedEventArgs e)
        {
            Widget widget = sender as Widget;
            listBox.Items.Insert(0, $"完成目标销售额：{widget.Value}");
        }
        //PreviewMouseUp
        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"Window对象的隧道事件PreviewMouseUp被触发");
        }
        private void Border_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"Border对象的隧道事件PreviewMouseUp被触发");
        }
        private void Canvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"Canvas对象的隧道事件PreviewMouseUp被触发");
        }
        //private void Button_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    MessageBox.Show($"Button确定按钮的隧道事件PreviewMouseUp被触发");
        //}
        //private void Button_PreviewMouseUp_1(object sender, MouseButtonEventArgs e)
        //{
        //    MessageBox.Show($"Button取消按钮的隧道事件PreviewMouseUp被触发");
        //}
        //MouseUp

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"Window对象的冒泡事件MouseUp被触发");
        }
        private void Border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"Border对象的冒泡事件MouseUp被触发");
        }
        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"Canvas对象的冒泡事件MouseUp被触发");
        }
        //private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    MessageBox.Show($"Button1的冒泡事件MouseUp被触发");
        //}
        //private void Button_MouseUp_1(object sender, MouseButtonEventArgs e)
        //{
        //    MessageBox.Show($"Button2的冒泡事件MouseUp被触发");
        //}

    }
}