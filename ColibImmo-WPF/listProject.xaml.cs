using ColibImmo_WPF.API;
using ColibImmo_WPF.API.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
    public partial class ListProject : Page
    {
        public ListProject()
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
                
                listProjectGrid.ItemsSource = projects;
            }
            else
            {
                MessageBox.Show("Erreur de connexion.");
            }
        }

        private void PutProject(object sender, RoutedEventArgs e)
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
                    PutBien newpage = new PutBien(ModelTextBlock.Text);
                    this.NavigationService.Navigate(newpage, ModelTextBlock.Text);

                }

            }



        }

        private async void DeleteProject(object sender, RoutedEventArgs e)
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
                    MessageBox.Show("Le projet est supprimé");

                }

            }
            
        }
    }
}
