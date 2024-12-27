using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace wpf_02_template
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Person : ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

        private string occupation;
        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; RaisePropertyChanged(); }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; RaisePropertyChanged(); }
        }

        private int money;
        public int Money
        {
            get { return money; }
            set { money = value; RaisePropertyChanged(); }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; RaisePropertyChanged(); }
        }
    }
    public class Sentence : ObservableObject
    {
        //step1 创建数据实体
        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(); }
        }
    }

    public class MainViewModel : ObservableObject
    {
        //step2数据实体放到ViewModel中
        private ObservableCollection<Sentence> poetries = new ObservableCollection<Sentence>();
        public ObservableCollection<Sentence> Poetries
        {
            get { return poetries; }
            set { poetries = value; RaisePropertyChanged(); }
        }

        private List<Person> persons = new List<Person>();
        public List<Person> Persons
        {
            get { return persons; }
            set { persons = value; RaisePropertyChanged(); }
        }

        private Person person;
        public Person Person
        {
            get { return person; }
            set { person = value; RaisePropertyChanged(); }
        }
        public MainViewModel()

        {

            Poetries.Add(new Sentence() { Content = "汉皇重色思倾国，御宇多年求不得。" });
            Poetries.Add(new Sentence() { Content = "杨家有女初长成，养在深闺人未识。" });
            Poetries.Add(new Sentence() { Content = "天生丽质难自弃，一朝选在君王侧。" });
            Poetries.Add(new Sentence() { Content = "回眸一笑百媚生，六宫粉黛无颜色。" });
            Poetries.Add(new Sentence() { Content = "春寒赐浴华清池，温泉水滑洗凝脂。" });
            Poetries.Add(new Sentence() { Content = "侍儿扶起娇无力，始是新承恩泽时。" });
            Poetries.Add(new Sentence() { Content = "云鬓花颜金步摇，芙蓉帐暖度春宵。" });


            person = new Person()
            {
                Name = "Michael Jackson",
                Occupation = "Musicians",
                Age = 25,
                Money = 9999999,
                Address = "Address1"
            };
            var bill = new Person()
            {
                Name = "比尔·盖茨（Bill Gates）",
                Occupation = "微软公司创始人",
                Age = 61,
                Money = 9999999,
                Address = "Address2"
            };
            var musk = new Person()
            {
                Name = "Elon Reeve Musk",
                Occupation = "首席执行官",
                Age = 50,
                Money = 365214580,
                Address = "Address3"
            };
            var jeff = new Person()
            {
                Name = "杰夫·贝索斯（Jeff Bezos）",
                Occupation = "董事会执行主席",
                Age = 25,
                Money = 85745845,
                Address = "Address4"
            };
            //persons.Add(person);
            //persons.Add(bill);
            //persons.Add(musk);
            //persons.Add(jeff);
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel ();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TreeViewItem item = new TreeViewItem() { Header = "逻辑树" };
            //LogicalTree(item, this);
            TreeViewItem item = new TreeViewItem() { Header = "可视化树根" };
            VisualTree(item,this);
            //_TreeView.Items.Add(item);
        }
        private void LogicalTree(TreeViewItem item, object element)
        {
            if (!(element is DependencyObject)) return;

            TreeViewItem treeViewItem = new TreeViewItem { Header = element.GetType().Name };

            item.Items.Add(treeViewItem);

            var elements = LogicalTreeHelper.GetChildren(element as DependencyObject);

            foreach (object child in elements)
            {
                LogicalTree(treeViewItem, child);
            }
        }
        private void VisualTree(TreeViewItem item, object element)
        {
            if (!(element is DependencyObject)) return;

            TreeViewItem treeViewItem = new TreeViewItem { Header = element.GetType().Name };

            item.Items.Add(treeViewItem);

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element as DependencyObject); i++)
            {
                VisualTree(treeViewItem, VisualTreeHelper.GetChild(element as DependencyObject, i));
            }
        }
    }
}