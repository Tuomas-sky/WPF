//using ReactiveUI;
//using System.ComponentModel;
//using System.Data;
//using System.Globalization;
//using System.IO;
//using System.Reactive;
//using System.Reactive.Linq;
//using System.Runtime.CompilerServices;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace framework_03_command
//{
//    public class ObservableObject : INotifyPropertyChanged
//    {
//        public event PropertyChangedEventHandler PropertyChanged;

//        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }
//    }

//    //ICommand接口的实现
//    public class RelayCommand1 : ICommand
//    {
//        public event EventHandler? CanExecuteChanged;
//        private Action action;
//        private Action<object> objectAction;
//        public RelayCommand1(Action action)
//        {
//            this.action = action;
//        }
//        public RelayCommand1(Action<object> objectAction)
//        {
//            this.objectAction = objectAction;
//        }
//        public bool CanExecute(object? parameter)
//        {
//            return true;
//        }

//        public void Execute(object? parameter)
//        {
//            action?.Invoke();
//            objectAction?.Invoke(parameter);
//        }
//    }
//    public class RelayCommand<T> : ICommand
//    {
//        public event EventHandler? CanExecuteChanged;
//        public Action<T> Action { get; }
//        public RelayCommand(Action<T> Action)
//        {
//            this.Action = Action;
//        }

//        public bool CanExecute(object? parameter)
//        {
//            return true;
//        }

//        public void Execute(object? parameter)
//        {
//            Action?.Invoke((T)parameter);
//        }
//    }

//    //3、创建一个多值转换器，其可以绑定多个XAML上的控件或控件属性
//    internal class MutilValueConvert : IMultiValueConverter
//    {
//        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
//        {
//            return values;
//        }

//        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
//        {
//            throw new NotImplementedException();
//        }
//    }
//    public class MainViewModel : ObservableObject
//    {

//        //1、通过继承ICommand 实现传递多个参数
//        public ICommand SubmitCommand { get; }

//        //ReactiveCommand
//        public ICommand GeneralCommand { get; }
//        public ICommand ParameterCommand { get; }
//        public ICommand TaskCommand { get; }
//        public ICommand CombineCommand { get; }
//        public ReactiveCommand<Unit, DateTime> ObservableCommand { get; }


//        //Prism
//        public DelegateCommand DelegateCommand { get; }
//        public DelegateCommand<string> ParamCommand { get; }
//        public CompositeCommand CompositeCommand { get; }

//        //Mvvmlight
//        public GalaSoft.MvvmLight.Command.RelayCommand<string> MvvmlightCommand { get; }
//        public MainViewModel()
//        {
//            //2、实例化，定义一个带参数的命令
//            SubmitCommand = new RelayCommand<object>(OnSubmitCommand);

//            //ReactiveCommand
//            GeneralCommand = ReactiveCommand.Create(General);
//            ParameterCommand = ReactiveCommand.Create<object, bool>(Parameter);
//            TaskCommand = ReactiveCommand.CreateFromTask(RunAsync);
//            var childCommand = new List<ReactiveCommandBase<Unit, Unit>>();
//            childCommand.Add(ReactiveCommand.Create<Unit, Unit>((o) =>
//            {
//                MessageBox.Show("childCommand1");
//                return Unit.Default;
//            }));
//            childCommand.Add(ReactiveCommand.Create<Unit, Unit>((o) =>
//            {
//                MessageBox.Show("childCommand2");
//                return Unit.Default;
//            }));
//            childCommand.Add(ReactiveCommand.Create<Unit, Unit>((o) =>
//            {
//                MessageBox.Show("childCommand3");
//                return Unit.Default;
//            }));
//            CombineCommand = ReactiveCommand.CreateCombined(childCommand);
//            ObservableCommand = ReactiveCommand.CreateFromObservable<Unit, DateTime>(DoObservableCommand);
//            ObservableCommand.Subscribe(v => ShowObservableResult(v));

//            //Prism
//            DelegateCommand = new DelegateCommand(() =>
//            {
//                MessageBox.Show("无参的DelegateCommand");
//            });
//            ParamCommand = new DelegateCommand<string>((msg) =>
//            {
//                MessageBox.Show($"有参的DelegateCommand,msg={msg}");
//            });
//            CompositeCommand = new CompositeCommand();
//            CompositeCommand.RegisterCommand(DelegateCommand);

//            //Mvvmlight
//            MvvmlightCommand = new GalaSoft.MvvmLight.Command.RelayCommand<string>((message) =>
//            {
//                MessageBox.Show(message);
//            });
//        }

//        //ICommand实现
//        public RelayCommand1 OpenCommand { get; set; } = new RelayCommand1(() =>
//        {
//            MessageBox.Show("Hello Command");
//        });
//        public RelayCommand1 OpenParamCommand { get; set; } = new RelayCommand1((param) =>
//        {
//            MessageBox.Show(param.ToString());
//        });

//        public RelayCommand<object> OpenTParamCommand { get; set; } = new RelayCommand<object>((t) =>
//        {
//            MessageBox.Show(t.ToString());
//        });

//        public RelayCommand<TextBox> MouseDownCommand { get; set; } = new RelayCommand<TextBox>((textbox) =>
//        {
//            textbox.Text += DateTime.Now + " 您单击了TextBox" + "\r";
//        });

//        //ReactivableCommand
//        private void RunInBackground()
//        {
//            throw new NotImplementedException();
//        }

//        private IObservable<DateTime> DoObservableCommand(Unit arg)
//        {
//            //todo 业务代码

//            var result = DateTime.Now;

//            return Observable.Return(result).Delay(TimeSpan.FromSeconds(1));
//        }

//        private void ShowObservableResult(DateTime v)
//        {
//            MessageBox.Show($"时间：{v}");
//        }

//        private async Task RunAsync()
//        {
//            await Task.Delay(3000);
//        }

//        private bool Parameter(object arg)
//        {
//            MessageBox.Show(arg.ToString());
//            return true;
//        }

//        private void General()
//        {
//            MessageBox.Show("ReactiveCommand！");
//        }

//        private void OnSubmitCommand(object args)
//        {
//            string content = string.Empty;
//            if (args is Object[] array)
//            {
//                foreach (var item in array)
//                {
//                    if (item is TextBlock textBlock)
//                    {
//                        content += textBlock.Text + "\r\n";
//                    }
//                }
//            }
//            MessageBox.Show(content);
//        }

//        //ReactiveCommand示例
//        //public class MainWiewModelReactive:ReactiveObject
//        //{
//        //    public ICommand GeneralCommand { get;  }
//        //    public ICommand ParameterCommand { get; }
//        //    public ICommand TaskCommand { get; }
//        //    public ICommand CombineCommand { get; }
//        //    public ReactiveCommand<Unit ,DateTime> ObservableCommand { get; }

//        //    public MainWiewModelReactive()
//        //    {
//        //        GeneralCommand = ReactiveCommand.Create(General);
//        //        ParameterCommand = ReactiveCommand.Create<object, bool>(Parameter);
//        //        TaskCommand = ReactiveCommand.CreateFromTask(RunAsync);
//        //        var childCommand = new List<ReactiveCommandBase<Unit,Unit>>();
//        //        childCommand.Add(ReactiveCommand.Create<Unit, Unit> ((o) =>
//        //        {
//        //            MessageBox.Show("childCommand");
//        //            return Unit.Default;
//        //        }));
//        //    }

//        //}
//        public partial class MainWindow : Window
//        {
//            private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
//            {
//                MessageBox.Show("我是ALT+S");
//            }
//            private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
//            {
//                e.CanExecute = true;
//            }
//            public MainWindow()
//            {
//                InitializeComponent();
//                //this.DataContext = new MainViewModel();
//            }
//            //Application

//            private void OpenCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
//            {
//                e.CanExecute = true;
//            }

//            private void OpenCommandExecuted(object sender, ExecutedRoutedEventArgs e)
//            {
//                var openFileDialog = new Microsoft.Win32.OpenFileDialog()
//                {
//                    Filter = "文本文档 (.txt)|*.txt",
//                    Multiselect = true,
//                };
//                var result = openFileDialog.ShowDialog();
//                if (result == true)
//                {
//                    textbox.Text = File.ReadAllText(openFileDialog.FileName);
//                }
//            }

//            private void CutCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
//            {
//                e.CanExecute = textbox != null && textbox.SelectionLength > 0;
//            }

//            private void CutCommandExecuted(object sender, ExecutedRoutedEventArgs e)
//            {
//                textbox.Cut();
//            }

//            private void PasteCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
//            {
//                e.CanExecute = Clipboard.ContainsText();
//            }

//            private void PasteCommandExecuted(object sender, ExecutedRoutedEventArgs e)
//            {
//                textbox.Paste();
//            }

//            private void SaveCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
//            {
//                e.CanExecute = textbox != null && textbox.Text.Length > 0;
//            }

//            private void SaveCommandExecuted(object sender, ExecutedRoutedEventArgs e)
//            {
//                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
//                {
//                    Filter = "文本文档 (.txt)|*.txt"
//                };

//                if (saveFileDialog.ShowDialog() == true)
//                {
//                    File.WriteAllText(saveFileDialog.FileName, textbox.Text);
//                }
//            }
//        }
//    }
//}