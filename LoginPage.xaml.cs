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

namespace SamleProgram
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private static CollectionPage CollectionNavigate = new CollectionPage();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(LoginUsername.Text == "tobias" && LoginPassword.Text == "1234")
            {
                NavigationService.Navigate(CollectionNavigate);
            }
            else if (LoginUsername.Text == "user" && LoginPassword.Text == "user")
            {
                NavigationService.Navigate(CollectionNavigate);
            }
            else
            {
                MessageBox.Show("Wrong Username or Password!\nMake sure you are spelling it correctly!");
            }
        }
    }
}
