using System.Globalization;
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

namespace framework_03_command_02
{

    //3、创建一个多值转换器，其可以绑定多个XAML上的控件或控件属性
    public class MultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.ToArray();//必须ToArray()
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    //1、实现一个ICommand接口，通过继承ICommand 实现传递多个参数
    public class RelayCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<T> Action { get; }
        public RelayCommand(Action<T> action) { Action = action; }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter) { 
            Action?.Invoke((T)parameter);
        }
    }
    public class MainViewModel
    {
        //2、实例化，定义一个带参数的命令
        public ICommand SubmitCommand { get; }
        public MainViewModel()
        {
            SubmitCommand = new RelayCommand<object>(OnSubmitCommand);
        }
        private void OnSubmitCommand(object parameter) { 
            string content=string.Empty;
            if (parameter is Object[] array) {
                foreach (var item in array) {
                    if (item is TextBlock textBlock) {
                        content += textBlock.Text + "\r\n";
                    }
                }
            }
            MessageBox.Show(content);
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext=new MainViewModel();
        }
    }
}