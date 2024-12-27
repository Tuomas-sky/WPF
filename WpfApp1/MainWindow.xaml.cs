using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
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

namespace WpfApp1
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string popertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(popertyName));
        }
    }

    public class Person:ObservableObject
    {
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value;RaisePropertyChanged(); }
        }
    }
    public class MainViewModel : ObservableObject
    {
        private Person person;
        public Person Person
        {
            get { return person; }
            set { person = value; RaisePropertyChanged(); }
        }
        public MainViewModel() {
            person = new Person()
            {
                Age = 20,
            };
        }
    }

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext=new MainViewModel();


            //listbox.Items.Add(new Person { Age = 1, Name = "ZS", Address = "BJ" });
            //listbox.Items.Add(new Person { Age = 2, Name = "LS", Address = "SH" });
            //listbox.Items.Add(new Person { Age = 3, Name = "WW", Address = "TJ" });

            //this.btn1.Click += Btn1_Click;
            //Task.Factory.StartNew(() =>
            //{
            //    Task.Delay(3000).Wait();
            //    btn1.Dispatcher.Invoke(() =>
            //    {
            //        btn1.Content = "wpf";
            //    });
            //}
            //);
        }

        //private void click(object sender, RoutedEventArgs e)
        //{
        //    var vm=DataContext as MainViewModel;
        //    if(vm == null) return;
        //    vm.Person.Age=new Random().Next(1,100);

        //}

        //private void Button_Click1(object sender, RoutedEventArgs e)
        //{
        //    var selectedItem = listbox.SelectedItem;
        //    var selectedValue = listbox.SelectedValue;
        //    _TextBlock.Text=$"{selectedItem},{selectedValue}";
        //}

        //private void button2_Click(object sender, RoutedEventArgs e)
        //{
        //    Process.Start("https://www.wpfsoft.com/2023/08/28/1399.html");
        //}
        //int count = 1;
        //private void btn1_Click(object sender, RoutedEventArgs e)
        //{
        //    Message.Show($"重复时间:{DateTime.Now.ToLongTimeString()} {DateTime.Now.Millisecond},重复次数:{count++}");
        //}

        //private void click(object sender, RoutedEventArgs e)
        //{
        //    string order = string.Empty;
        //    if (cb1.IsChecked == true)
        //    {
        //        order += cb1.Content + ",";
        //    }
        //    if (cb2.IsChecked == true)
        //    {
        //        order += cb2.Content + ",";
        //    }
        //    if (cb3.IsChecked == true)
        //    {
        //        order += cb3.Content;
        //    }
        //    if (cb4.IsChecked == true)
        //    {
        //        order += cb4.Content;
        //    }
        //    if (!string.IsNullOrEmpty(order))
        //    {
        //        MessageBox.Show(order);
        //    }
        //}


        //private void Btn1_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        //private void btn1_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}
    }
}