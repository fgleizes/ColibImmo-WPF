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
using System.Net.Http;
using System.Text.Json.Nodes;

namespace ColibImmo_WPF
{

    public partial class ListProject : Page
    {
        string? currentFilter;

        public ListProject()
        {
            InitializeComponent();
            GetTypeProject();
            GetProjects();
        }

        private async void GetTypeProject()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project/typeProject/");
            if (streamAPI != null)
            {
                Type_Project[]? typeProject = JsonSerializer.DeserializeAsync<Type_Project[]>(streamAPI).Result;
                selectTypeProjet.ItemsSource = typeProject;
            }
            else
            {
                MessageBox.Show("Erreur de connexion.");
            }
        }

        private void Filter_MouseDown(object sender, RoutedEventArgs e)
        {
            var senderText = sender as TextBlock;

            if (senderText != null)
            {
                currentFilter = senderText.Text;
                GetFilteredProjects();
            }
            else 
            {
                currentFilter = null;
                GetProjects();
                selectTypeProjet.SelectedItem = null;
            }

            
        }

        private async void GetFilteredProjects()
        {
            if (currentFilter != null)
            {
                Client api = new Client();
                Stream? streamAPI = await api.GetCallAsync("project/typeProject/");
                if (streamAPI != null)
                {
                    Type_Project[]? typeProject = JsonSerializer.DeserializeAsync<Type_Project[]>(streamAPI).Result;
                    for (int i = 0; i < typeProject?.Length; i++)
                    {
                        if (typeProject[i].Name == currentFilter)
                        {
                            Client apiProjectByType = new Client();
                            Stream? streamAPIProjectByType = await apiProjectByType.GetCallAsync($"project/projectsByType/{typeProject[i].Id.ToString()}");
                            if (streamAPIProjectByType != null)
                            {
                                ProjectFilter[]? projectByType = JsonSerializer.DeserializeAsync<ProjectFilter[]>(streamAPIProjectByType).Result;
                                listProject.ItemsSource = projectByType;
                            }
                            else
                            {
                                MessageBox.Show("Erreur de connexion.");
                            }

                        }
                    }
                }
            }
        }

        private async void GetProjects()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project");

            if (streamAPI != null)
            {
                Project[]? projects = JsonSerializer.DeserializeAsync<Project[]>(streamAPI).Result;
                listProject.ItemsSource = projects;
            }
            else
            {
                MessageBox.Show("Erreur GetProjects.");
            }
        }


        private async void deleteProject(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmez-vous vouloir supprimer ce projet ?", "Supprimer projet", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Button button = (Button)sender;
                StackPanel ModelStackpanel = new StackPanel();
                ModelStackpanel = (StackPanel)button.Content;
                TextBlock ModelTextBlock = new TextBlock();
                foreach (var child in ModelStackpanel.Children)
                {
                    if (child.GetType().ToString() == "System.Windows.Controls.TextBlock")
                    {
                        ModelTextBlock = (TextBlock)child;
                        var webUriDelete = "http://api.colibimmo.cda.ve.manusien-ecolelamanu.fr/public/project/" + ModelTextBlock.Text;
                        HttpClient client = new HttpClient();
                        var res = await client.DeleteAsync(webUriDelete);

                        if(res.IsSuccessStatusCode)
                        {
                            if (currentFilter != null)
                            {
                                GetFilteredProjects();
                            }
                            else
                            {
                                GetProjects();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de la suppression de ce projet. Veuillez contacter votre administrateur.");
                        }
                    }

                }
            }
        }

        public void PostAsync(object sender, RoutedEventArgs e)
        {
            AddBien newPage = new AddBien();
            this.NavigationService.Navigate(newPage);
        }

        private void PutAsync(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            StackPanel ModelStackpanel = new StackPanel();
            ModelStackpanel = (StackPanel)button.Content;
            TextBlock ModelTextBlock = new TextBlock();
            foreach (var child in ModelStackpanel.Children)
            {
                if (child.GetType().ToString() == "System.Windows.Controls.TextBlock")
                {
                    ModelTextBlock = (TextBlock)child;
                    PutBien newpage = new PutBien(ModelTextBlock.Text);
                    this.NavigationService.Navigate(newpage, ModelTextBlock.Text);
                }

            }
        }
    }
}
