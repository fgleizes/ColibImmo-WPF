using ColibImmo_WPF.API;
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
    /// Logique d'interaction pour PutBien.xaml
    /// </summary>
    public partial class PutBien : Page
    {
        public PutBien(string value)
        {
            InitializeComponent();
            PutProjects(value.ToString());
        }

        private async void PutProjects(string id)
        {
            var putProject = new PutProject();
            putProject.Description = "a vendre aux gens";
            putProject.idTypeProject = 1;
            putProject.idPerson = 5;
            putProject.idPersonAgent = 9;
            putProject.idAddress = 1;
            putProject.Type = 1;
            putProject.Rooms = "a:3:{i:0;a:2:{s:12:\"id_Type_room\";i:2;s:4:\"area\";i:50;}i:1;a:2:{s:12:\"id_Type_room\";i:1;s:4:\"area\";i:20;}i:2;a:2:{s:12:\"id_Type_room\";i:3;s:4:\"area\";i:10;}}";
            putProject.Options = "a:3:{i:0;i:3;i:1;i:3;i:2;i:3;}";


            var json = JsonSerializer.Serialize(putProject);

            var data = new StringContent(json, Encoding.UTF8, "application/x-www-form-urlencoded");

            var url = "http://api.colibimmo.cda.ve.manusien-ecolelamanu.fr/public/project/" + id;
            using var client = new HttpClient();

            var response = await client.PutAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
        }

    }
}
