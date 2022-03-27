using ColibImmo_WPF.API.JSON;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColibImmo_WPF
{
    /// <summary>
    /// Logique d'interaction pour AddBien.xaml
    /// </summary>
    public partial class AddBien : Page
    {
        public AddBien()
        {
            InitializeComponent();
        }


        public async void AddProject(object sender, RoutedEventArgs e)
        {
            var postProject = new PostProject();
            postProject.Description = Description.Text;
            postProject.shortDescription =Resume.Text;
            postProject.Price = int.Parse(Prix.Text);
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
        }
    }
}
