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
using System.Windows.Shapes;
using System.Windows.Navigation;
using CafeDiamondCemesterProjekt.View;

namespace CafeDiamondCemesterProjekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            View.Bookinger p = new Bookinger();
            DenneFrame.Navigate(p);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            View.ProdukterEvents p = new ProdukterEvents();
            DenneFrame.Navigate(p);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //if (login == false){
            NavigationService nav = NavigationService.GetNavigationService(this);
            View.UserAdmin p = new UserAdmin();
            DenneFrame.Navigate(p);
            //} else {
            //NavigationService nav = NavigationService.GetNavigationService(this);
           // View.UserAdmin p = new UserAdmin();
           // DenneFrame.Navigate(p);
            // }
        }
    }
}
