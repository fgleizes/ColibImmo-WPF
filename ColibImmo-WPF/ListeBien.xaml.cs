using ColibImmo_WPF.API;
using ColibImmo_WPF.API.JSON;
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
using System.IO;
using System.Text.Json;
using System.Reflection;
using ColibImmo_WPF.Class;

namespace ColibImmo_WPF
{
    /// <summary>
    /// Logique d'interaction pour ListeBien.xaml
    /// </summary>
    public partial class ListeBien : Page
    {
        
        public ListeBien()
        {
            InitializeComponent();
            GetTypeProject();
            //GetProjects();
        }

        private async void GetTypeProject()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project/typeProject/");
            if (streamAPI != null)
            {
                Type_Project[]? projects = JsonSerializer.DeserializeAsync<Type_Project[]>(streamAPI).Result;
                listTypeProjetGrid.ItemsSource = projects;
                


    }
            else
            {
                MessageBox.Show("Erreur de connexion.");
            }
        }

       /* private async void GetFilterTypeProject(object sender, System.EventArgs e)
        {
            string? valueCb = listTypeProjetGrid.SelectedValue?.ToString();

            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync($"project/projectsByType/{valueCb}");

            if (streamAPI != null)
            {
                Project[]? projects = JsonSerializer.DeserializeAsync<Project[]>(streamAPI).Result;
                listOneProjetGrid.ItemsSource = projects;
            }
            else
            {
                MessageBox.Show("Erreur de connexion." + valueCb);
            }
        }

        private async void GetProjects()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project");

            if (streamAPI != null)
            {
                Project[]? projects = JsonSerializer.DeserializeAsync<Project[]>(streamAPI).Result;
                listOneProjetGrid.ItemsSource = projects;
            }
            else
            {
                MessageBox.Show("Erreur de connexion.");
            }
        }

        private void RefreshProject(object sender, System.EventArgs e)
        {
            listTypeProjetGrid.SelectedIndex = -1;
            listOneProjetGrid.ItemsSource = null;
            GetProjects();
        }*/
    }
}
