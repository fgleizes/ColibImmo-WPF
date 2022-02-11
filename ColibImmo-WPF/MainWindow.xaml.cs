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
using System.Windows.Threading;

namespace ColibImmo_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        
        double panelWidth;
        bool hidden;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0,0);
            timer.Tick += Timer_Tick;
            panelWidth = sidePanel.Width;
            listView.SelectedIndex = 0;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem item = (ListViewItem)listView.Items[listView.SelectedIndex];
            switch (item.Name)
            {
                case "HomePage":
                    Main.Content = new HomePage();
                    break;
                case "ListClient":
                    Main.Content = new ListClientPage();
                    break;
                case "ListProject":
                    Main.Content = new ListProject();
                    break;
                case "ListProperty":
                    Main.Content = new ListeBien();
                    break;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                sidePanel.Width -= 1;
                if (sidePanel.Width <= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width += 1;
                if (sidePanel.Width >= 280)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void PanelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
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
