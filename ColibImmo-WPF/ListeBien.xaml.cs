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
                selectTypeProjet.ItemsSource = typeProject;
            }
            else
            {
                MessageBox.Show("Erreur de connexion.");
            }
        }

        private async void getFilterType(object sender, MouseButtonEventArgs e)
        {
            var senderText = sender as TextBlock;
            var senderBtn = sender as Button;

            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project/typeProject/");
            if (streamAPI != null)
            {
                Type_Project[]? typeProject = JsonSerializer.DeserializeAsync<Type_Project[]>(streamAPI).Result;
                string[] vs = new string[typeProject.Length];
                for (int i = 0; i < vs.Length; i++)
                {
                    if (typeProject[i].Name == senderText?.Text)
                    {
                        Client apiProjectByType = new Client();
                        Stream? streamAPIProjectByType = await apiProjectByType.GetCallAsync($"project/projectsByType/{typeProject[i].Id.ToString()}");
                        if (streamAPIProjectByType != null)
                        {
                            //(System.Collections.IEnumerable?)
                            Project[]? projectByType = JsonSerializer.DeserializeAsync<Project[]>(streamAPIProjectByType).Result;
                            testListeBien.ItemsSource = (System.Collections.IEnumerable?)projectByType;
                        }
                        else
                        {
                            MessageBox.Show("Erreur de connexion.");
                        }

                    }else if (senderBtn?.Content.ToString() == "All")
                    {
                        GetProjects();
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
                testListeBien.ItemsSource = projects;
            }
            else
            {
                MessageBox.Show("Erreur GetProjects.");
            }
        }


        private async void deleteProject(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TextBlock textBlock = (TextBlock)button.Content;
            var weburidelete = "http://api.colibimmo.cda.ve.manusien-ecolelamanu.fr/public/project/" + textBlock.Text;
            HttpClient client = new HttpClient();
            var res = await client.DeleteAsync(weburidelete);
        }

        public async void PostAsync(object sender, RoutedEventArgs e)
        {
            var postProject = new PostProject();
            postProject.idTypeProject = 1;
            postProject.idPerson = 5;
            postProject.idPersonAgent = 9;
            postProject.idAddress = 1;
            postProject.Type = 1;
            postProject.Rooms = "a:3:{i:0;a:2:{s:12:\"id_Type_room\";i:2;s:4:\"area\";i:50;}i:1;a:2:{s:12:\"id_Type_room\";i:1;s:4:\"area\";i:20;}i:2;a:2:{s:12:\"id_Type_room\";i:3;s:4:\"area\";i:10;}}";
            postProject.Options = "a:3:{i:0;i:3;i:1;i:3;i:2;i:3;}";


            var json = JsonSerializer.Serialize(postProject);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://api.colibimmo.cda.ve.manusien-ecolelamanu.fr/public/project";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            MessageBox.Show(result + postProject.idTypeProject + "id person : "+postProject.idPerson + "id personAgent : " + postProject.idPersonAgent + "id Adresse : " + postProject.idAddress + "id TYpe : " + postProject.Type + "room : " + postProject.Rooms + "option : " + postProject.Options);
        }
    }
}
