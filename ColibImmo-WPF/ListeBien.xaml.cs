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
            //GetFilterTypeProject();
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
                MessageBox.Show("Erreur GetTypeProject.");
            }
        }

        private async void textbox1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
<<<<<<< HEAD
            if(listTypeProjetGrid.SelectedIndex != -1)
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
                    MessageBox.Show("Erreur GetFilterTypeProject" + valueCb);
                }
=======
            TextBlock tb = (TextBlock)sender;
           
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project/typeProject/");
            if (streamAPI != null)
            {
                Type_Project[]? projects = JsonSerializer.DeserializeAsync<Type_Project[]>(streamAPI).Result;
                string[] vs = new string[projects.Length];
                for (int i = 0; i < vs.Length; i++)
                {
                    if (projects[i].Name == tb.Text)
                    {
                        
                        Client apiProjectByType = new Client();
                        Stream? streamAPIProjectByType = await apiProjectByType.GetCallAsync($"project/projectsByType/{projects[i].Id.ToString()}");
                        if (streamAPIProjectByType != null)
                        {
                            Project[]? projectByType = JsonSerializer.DeserializeAsync<Project[]>(streamAPIProjectByType).Result;
                            MessageBox.Show(projectByType.ToString());
                            string[] vsByType = new string[projectByType.Length];
                            for (int j = 0; j < vsByType.Length; j++)
                            {

                                //dgUsers.ItemsSource = projectByType;

                            }
                            //lvUsers.ItemsSource = projects;
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
                MessageBox.Show("Erreur de connexion.");
>>>>>>> d7a069493c664c91b19252ab0211e828df4cc9a5
            }
        }

        /*private async void GetFilterTypeProject(object sender, System.EventArgs e)
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



         private void RefreshProject(object sender, System.EventArgs e)
         {
             listTypeProjetGrid.SelectedIndex = -1;
             listOneProjetGrid.ItemsSource = null;
             GetProjects();
         }*/


        /*private async void GetProjects()
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
                MessageBox.Show("Erreur GetProjects.");
            }
<<<<<<< HEAD
        }

        private void RefreshProjectButton_Click(object sender, System.EventArgs e)
        {
            listTypeProjetGrid.SelectedIndex = -1;
            listOneProjetGrid.ItemsSource = null;
            GetProjects();
        }
=======
        }*/
>>>>>>> d7a069493c664c91b19252ab0211e828df4cc9a5
    }
}
