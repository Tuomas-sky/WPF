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

namespace framework_04_DependencyProperty_CallBack.Controls
{

    public partial class TrayControl : UserControl
    {
        public TrayControl()
        {
            InitializeComponent();
        }


        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Size.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(int), typeof(TrayControl),
                new PropertyMetadata(60, new PropertyChangedCallback(OnSizePropertyChangedCallback)));
        private static void OnSizePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TrayControl control = d as TrayControl;
            control.Initlize();
        }

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Count.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register("Count", typeof(int), typeof(TrayControl),
                new PropertyMetadata(0,
                    new PropertyChangedCallback(OnCountPropertyChangedCallback),
                    new CoerceValueCallback(OnCountCoreceValueCallback)));
        //这里演示当依赖属性值等于10，强制与10相乘，输出100
        private static object OnCountCoreceValueCallback(DependencyObject d, object baseValue)
        {
            int count = (int)baseValue;
            if (count == 10)
            {
                return count * 10;
            }
            return baseValue;
        }
        private static void OnCountPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TrayControl control = d as TrayControl;
            control.Initlize();
        }
        private void Initlize()
        {
            SelectedCount = 0;
            container.Children.Clear();
            SelectedItems.Clear();

            if (Count > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Style = Application.Current.Resources["CheckBoxDishStyle"] as Style;
                    checkBox.Width = Size;
                    checkBox.Height = Size;
                    checkBox.Tag = new Point(i * 10, Size + i * 2);
                    checkBox.Name = "_" + i.ToString();
                    checkBox.Checked += (sender, args) =>
                    {
                        SelectedCount++;
                        SelectedItems.Add(checkBox);
                    };
                    checkBox.Unchecked += (sender, args) =>
                    {
                        SelectedCount--;
                        SelectedItems.Remove(checkBox);

                    };
                    container.Children.Add(checkBox);
                }
            }
        }

        public int SelectedCount
        {
            get { return (int)GetValue(SelectedCountProperty); }
            set { SetValue(SelectedCountProperty, value); }
        }

        public static readonly DependencyProperty SelectedCountProperty =
            DependencyProperty.Register("SelectedCount", typeof(int), typeof(TrayControl),
                new PropertyMetadata(0));

        public List<CheckBox> SelectedItems
        {
            get { return (List<CheckBox>)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(List<CheckBox>), typeof(TrayControl),
                new PropertyMetadata(new List<CheckBox>()));
    }
}
