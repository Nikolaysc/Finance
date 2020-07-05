using FinanceCore.Model;
using FinanceCore.ViewModel;
using System;
using System.Collections.Generic;
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

namespace FinanceCore.Views
{
    /// <summary>
    /// Interaction logic for CreateNewPage.xaml
    /// </summary>
    public partial class CreateNewPage : Page
    {
        public CreateNewPage()
        {
            InitializeComponent(); 
            this.Loaded += CreateNewPage_Loaded;
        }

        private void CreateNewPage_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new CreateNewViewModel(NavigationService);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox lb)
            {
                var item = lb.SelectedItem as Category;
                ((CreateNewViewModel)DataContext).SelectectCategory(item);
            }
        }
    }
}
