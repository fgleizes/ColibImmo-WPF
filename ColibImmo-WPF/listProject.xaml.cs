using ColibImmo_WPF.API;
using ColibImmo_WPF.API.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ColibImmo_WPF
{
    /// <summary>
    /// Logique d'interaction pour listProjet.xaml
    /// </summary>
    public partial class listProject : Window
    {
        public listProject()
        {
            InitializeComponent();
            GetProjects();
        }

        private async void GetProjects()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project");

            if (streamAPI != null)
            {
                Project[]? projects = JsonSerializer.DeserializeAsync<Project[]>(streamAPI).Result;
                //Application.Current.Properties.Add("apiToken", auth.Token);
                //errormessage3.Text = "";
                //Hide();
                //var window = new MainWindow();
                //window.Owner = this;
                //window.Show();
                //MessageBoxResult result = MessageBox.Show(Application.Current.Properties["apiToken"] as string);
                listProjectGrid.ItemsSource = (System.Collections.IEnumerable?)projects;
            }
            else
            {
                MessageBox.Show("Erreur de connexion.");
            }
        }
    }
}
