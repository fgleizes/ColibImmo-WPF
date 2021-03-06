using ColibImmo_WPF.API;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ColibImmo_WPF
{
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
                case "Calendar":
                    Main.Content = new CalendarPage();
                    break;
                case "Dashboard":
                    Main.Content = new DashboardPage();
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
            Application.Current.Properties.Remove("lastname");
            Application.Current.Properties.Remove("firstname");
            Hide();

            var window = new LoginWindow();
            window.Owner = this;
            window.Show();
        }
    }
}
