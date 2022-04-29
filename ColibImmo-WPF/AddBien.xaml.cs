using ColibImmo_WPF.API;
using ColibImmo_WPF.API.JSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
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
    /// Logique d'interaction pour AddBien.xaml
    /// </summary>
    public partial class AddBien : Page
    {
        private Type_Project[]? typeProject = null;
        public AddBien()
        {
            InitializeComponent();
            GetTypeProject();
            GetPerson();
            GetPersonAgent();
            GetAddress();
            GetTypeProperty();
            GetEnergyIndex();
        }
        private async void GetTypeProject()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project/typeProject/");
            if (streamAPI != null)
            {
                typeProject = JsonSerializer.DeserializeAsync<Type_Project[]>(streamAPI).Result;
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

        private async void GetTypeProperty()
        {
            Client api = new Client();
            api.Token = Application.Current.Properties["apiToken"].ToString();
            Stream? streamAPI = await api.GetCallAsync("typeProperty", null, true);
            if (streamAPI != null)
            {
                Type_Property[]? type_Properties = JsonSerializer.DeserializeAsync<Type_Property[]>(streamAPI).Result;
                ComboTypeProperty.ItemsSource = type_Properties;
                ComboTypeProperty.SelectedIndex = 1;
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



        public async void AddProject(object sender, RoutedEventArgs e)
        {
            Person? selectedPerson = ComboPerson.SelectedItem as Person;
            Person? selectedPersonAgent = ComboPersonAgent.SelectedItem as Person;
            Type_Project? selectedTypeProject = TypeProject.SelectedItem as Type_Project;
            Address? selectedAddress = ComboAddress.SelectedItem as Address;
            Type_Property? selectedTypeProperty = ComboTypeProperty.SelectedItem as Type_Property;
            EnergyIndex? selectedEnergyIndex = ComboEnergyIndex.SelectedItem as EnergyIndex;
            var postProject = new PostProject();
            if (Prix.Text == string.Empty)
            {
                MessageBox.Show("Mettez le prix");
            }
            else
            {
                postProject.Description = Description.Text;
                postProject.shortDescription = Resume.Text;
                postProject.Price = int.Parse(Prix.Text);
                postProject.idTypeProject = int.Parse(selectedTypeProject.Id.ToString());
                postProject.idPerson = int.Parse(selectedPerson.Id.ToString());
                postProject.idPersonAgent = int.Parse(selectedPersonAgent.Id.ToString());
                postProject.idAddress = int.Parse(selectedAddress.Id.ToString());
                postProject.Type = int.Parse(selectedTypeProperty.Id.ToString());
                postProject.idEnergyindex = int.Parse(selectedEnergyIndex.Id.ToString());
                postProject.Rooms = "a:3:{i:0;a:2:{s:12:\"id_Type_room\";i:2;s:4:\"area\";i:50;}i:1;a:2:{s:12:\"id_Type_room\";i:1;s:4:\"area\";i:20;}i:2;a:2:{s:12:\"id_Type_room\";i:3;s:4:\"area\";i:10;}}";
                postProject.Options = "a:3:{i:0;i:3;i:1;i:3;i:2;i:3;}";
            }
            


            var json = JsonSerializer.Serialize(postProject);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://api.colibimmo.cda.ve.manusien-ecolelamanu.fr/public/project";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            MessageBox.Show("Projet créer");
        }
    }
}
