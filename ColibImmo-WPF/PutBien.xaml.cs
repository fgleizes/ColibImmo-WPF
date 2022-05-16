using ColibImmo_WPF.API;
using ColibImmo_WPF.API.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
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
            GetTypeProject();
            GetPerson();
            GetPersonAgent();
            GetAddress();
            GetEnergyIndex();
        }

        private async void GetTypeProject()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project/typeProject/");
            if (streamAPI != null)
            {
                Type_Project[]? typeProject = JsonSerializer.DeserializeAsync<Type_Project[]>(streamAPI).Result;
                TypeProject.ItemsSource = typeProject;
                TypeProject.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Erreur de connexion");
            }
        }

        private async void GetPerson()
        {
            Client api = new Client();
            api.Token = Application.Current.Properties["apiToken"].ToString();
            Stream? streamAPI = await api.GetCallAsync("person", null, true);
            if (streamAPI != null)
            {
                Person[]? person = JsonSerializer.DeserializeAsync<Person[]>(streamAPI).Result;
                ComboPerson.ItemsSource = person;
                ComboPerson.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Erreur de connexion");
            }
        }
        private async void GetPersonAgent()
        {
            Client api = new Client();
            api.Token = Application.Current.Properties["apiToken"].ToString();
            Stream? streamAPI = await api.GetCallAsync("person/role/4", null, true);
            if (streamAPI != null)
            {
                Person[]? personAgent = JsonSerializer.DeserializeAsync<Person[]>(streamAPI).Result;
                ComboPersonAgent.ItemsSource = personAgent;
                ComboPersonAgent.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Erreur de connexion");
            }
        }

        

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void GetAddress()
        {
            Client api = new Client();
            api.Token = Application.Current.Properties["apiToken"].ToString();
            Stream? streamAPI = await api.GetCallAsync("address", null, true);
            if (streamAPI != null)
            {
                Address[]? address = JsonSerializer.DeserializeAsync<Address[]>(streamAPI).Result;
                ComboAddress.ItemsSource = address;
                ComboAddress.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Erreur de connexion");
            }
        }

        private async void GetEnergyIndex()
        {
            Client api = new Client();
            api.Token = Application.Current.Properties["apiToken"].ToString();
            Stream? streamAPI = await api.GetCallAsync("project/energieIndexAll", null, true);
            if (streamAPI != null)
            {
                EnergyIndex[]? energyIndices = JsonSerializer.DeserializeAsync<EnergyIndex[]>(streamAPI).Result;
                ComboEnergyIndex.ItemsSource = energyIndices;
                ComboEnergyIndex.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("Erreur de connexion");
            }
        }

        private async void PutProjects(object sender, RoutedEventArgs e)
        {
            Person? selectedPerson = ComboPerson.SelectedItem as Person;
            Person? selectedPersonAgent = ComboPersonAgent.SelectedItem as Person;
            Type_Project? selectedTypeProject = TypeProject.SelectedItem as Type_Project;
            Address? selectedAddress = ComboAddress.SelectedItem as Address;
            EnergyIndex? selectedEnergyIndex = ComboEnergyIndex.SelectedItem as EnergyIndex;
            var url = "http://api.colibimmo.cda.ve.manusien-ecolelamanu.fr/public/project/" + id;
            using var client = new HttpClient();
            var dict = new Dictionary<string, string>();
            dict.Add("description", Description.Text);
            dict.Add("short_description", Resume.Text);
            dict.Add("price", Prix.Text);
            dict.Add("id_Type_project", selectedTypeProject.Id.ToString());
            dict.Add("id_Person", selectedPerson.Id.ToString());
            dict.Add("id_PersonAgent", selectedPersonAgent.Id.ToString());
            dict.Add("id_Address", selectedAddress.Id.ToString());
            dict.Add("id_Energy_index", selectedEnergyIndex.Id.ToString());
            var req = new HttpRequestMessage(HttpMethod.Put, url) { Content = new FormUrlEncodedContent(dict) };
            var res = await client.SendAsync(req);

        }
    }
}
