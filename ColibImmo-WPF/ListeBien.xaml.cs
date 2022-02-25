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
   
    public partial class ListeBien : Page
    {
        
        public ListeBien()
        {
            InitializeComponent();
            GetTypeProject();
            GetProjects();
            //GetFilterTypeProject();
        }

        private async void GetTypeProject()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project/typeProject/");
            if (streamAPI != null)
            {
                Type_Project[]? typeProject = JsonSerializer.DeserializeAsync<Type_Project[]>(streamAPI).Result;
                selectTypeProjetGrid.ItemsSource = typeProject;
            }
            else
            {
                MessageBox.Show("Erreur de connexion.");
            }
        }

        private async void textbox1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textSender = (TextBlock)sender;

            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project/typeProject/");
            if (streamAPI != null)
            {
                Type_Project[]? typeProject = JsonSerializer.DeserializeAsync<Type_Project[]>(streamAPI).Result;
                string[] vs = new string[typeProject.Length];
                for (int i = 0; i < vs.Length; i++)
                {
                    if (typeProject[i].Name == textSender.Text)
                    {

                        Client apiProjectByType = new Client();
                        Stream? streamAPIProjectByType = await apiProjectByType.GetCallAsync($"project/projectsByType/{typeProject[i].Id.ToString()}");
                        if (streamAPIProjectByType != null)
                        {
                            Project[]? projectByType = JsonSerializer.DeserializeAsync<Project[]>(streamAPIProjectByType).Result;
                            string[] vsByType = new string[projectByType.Length];
                            for (int numberLength = 0; numberLength < vsByType.Length; numberLength++)
                            {
                                List<Project> items = new List<Project>();
                                items.Add(new Project() { Reference = projectByType[numberLength].Reference, Description = projectByType[numberLength].Description });
                                testListeBien.ItemsSource = items;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Erreur de connexion.");
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Erreur GetTypeProject.");
            }
        }
        private async void GetProjects()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project");

            if (streamAPI != null)
            {
                Project[]? projects = JsonSerializer.DeserializeAsync<Project[]>(streamAPI).Result;
                testListeBien.ItemsSource = projects;
            }
            else
            {
                MessageBox.Show("Erreur GetProjects.");
            }
        }
    }
}
