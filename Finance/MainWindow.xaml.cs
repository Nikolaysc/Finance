using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Finance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HelloViewModel vm = new HelloViewModel();
        public MainWindow()
        {
            InitializeComponent();

            DataContext = vm;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            vm.OnClicked();
        }
    }

    class HelloViewModel:INotifyPropertyChanged
    {
        int countClicked;
        public string Text => $"Clickect {countClicked} times";

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnClicked()
        {
            countClicked++;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
        }
    }
}
