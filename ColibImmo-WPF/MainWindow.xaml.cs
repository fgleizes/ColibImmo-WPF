using ColibImmo_WPF.API;
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

namespace ColibImmo_WPF
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

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            Client api = new Client();
            api.Disconnect("user/logout");
            Application.Current.Properties.Remove("apiToken");
            MessageBoxResult result = MessageBox.Show(Application.Current.Properties["apiToken"] as string);
            Hide();

            var window = new LoginWindow();
            window.Owner = this;
            window.Show();
        }
    }
}
