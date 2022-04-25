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
        string id;
        public PutBien(string value)
        {
            InitializeComponent();
            id = value.ToString();
        }

        private async void PutProjects(object sender, RoutedEventArgs e)
        {
            var url = "http://api.colibimmo.cda.ve.manusien-ecolelamanu.fr/public/project/" + id;
            using var client = new HttpClient();
            var dict = new Dictionary<string, string>();
            dict.Add("description", Description.Text);
            dict.Add("short_description", Resume.Text);
            dict.Add("price", Prix.Text);
            var req = new HttpRequestMessage(HttpMethod.Put, url) { Content = new FormUrlEncodedContent(dict) };
            var res = await client.SendAsync(req);

        }
    }
}
