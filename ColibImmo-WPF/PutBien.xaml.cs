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
        DetailsProject? project = null;
        public PutBien(string value)
        {
            InitializeComponent();
            id = value.ToString();
            GetDetailsProject();
        }

        private async void GetDetailsProject()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project/" + id);

            if (streamAPI != null)
            {
                project = JsonSerializer.DeserializeAsync<DetailsProject>(streamAPI).Result;
                if(project != null)
                {
                    Description.Text = project.Description;
                    Resume.Text = project.shortDescription;
                    Prix.Text = project.Price.ToString();
                }
            }
            else
            {
                MessageBox.Show("Erreur de connexion");
            }

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
                if(typeProject != null)
                {
                    TypeProject.ItemsSource = typeProject;
                    for(int i = 0; i < typeProject.Length; i++)
                    {
                        if (typeProject[i].Id == project?.typeProject?.Id)
                        {
                            TypeProject.SelectedIndex = i;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Erreur de connexion");
            }
        }

        private async void GetPerson()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("person", null, true);
            if (streamAPI != null)
            {
                Person[]? person = JsonSerializer.DeserializeAsync<Person[]>(streamAPI).Result;

                if (person != null)
                {
                    ComboPerson.ItemsSource = person;
                    for (int i = 0; i < person.Length; i++)
                    {
                        if (person[i].Id == project?.idPerson)
                        {
                            ComboPerson.SelectedIndex = i;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Erreur de connexion");
            }
        }
        private async void GetPersonAgent()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("person/role/4", null, true);
            if (streamAPI != null)
            {
                Person[]? personAgent = JsonSerializer.DeserializeAsync<Person[]>(streamAPI).Result;
                if (personAgent != null)
                {
                    ComboPersonAgent.ItemsSource = personAgent;
                    for (int i = 0; i < personAgent.Length; i++)
                    {
                        if (personAgent[i].Id == project?.idPersonAgent)
                        {
                            ComboPersonAgent.SelectedIndex = i;
                        }
                    }
                }
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
            Stream? streamAPI = await api.GetCallAsync("address", null, true);
            if (streamAPI != null)
            {
                Address[]? address = JsonSerializer.DeserializeAsync<Address[]>(streamAPI).Result;
                if (address != null)
                {
                    ComboAddress.ItemsSource = address;
                    for (int i = 0; i < address.Length; i++)
                    {
                        if (address[i].Id == project?.address?.Id)
                        {
                            ComboAddress.SelectedIndex = i;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Erreur de connexion");
            }
        }

        private async void GetEnergyIndex()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project/energieIndexAll", null, true);
            if (streamAPI != null)
            {
                EnergyIndex[]? energyIndices = JsonSerializer.DeserializeAsync<EnergyIndex[]>(streamAPI).Result;
                if (energyIndices != null)
                {
                    ComboEnergyIndex.ItemsSource = energyIndices;
                    for (int i = 0; i < energyIndices.Length; i++)
                    {
                        if (energyIndices[i].Id == project?.idEnergyIndex)
                        {
                            ComboEnergyIndex.SelectedIndex = i;
                        }
                    }
                }
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
            if(Description.Text != null)
            {
                dict.Add("description", Description.Text);
            }
            if(Resume.Text != null)
            {
                dict.Add("short_description", Resume.Text);
            }
            if(Prix.Text != null)
            {
                dict.Add("price", Prix.Text);
            }
            if(selectedTypeProject != null)
            {
                dict.Add("id_Type_project", selectedTypeProject.Id.ToString());
            }
            if(selectedPerson != null)
            {
                dict.Add("id_Person", selectedPerson.Id.ToString());
            }
            if(selectedPersonAgent != null)
            {
                dict.Add("id_PersonAgent", selectedPersonAgent.Id.ToString());
            }
            if(selectedAddress != null)
            {
                dict.Add("id_Address", selectedAddress.Id.ToString());
            }
            if(selectedEnergyIndex != null)
            {
                dict.Add("id_Energy_index", selectedEnergyIndex.Id.ToString());
            }
            var req = new HttpRequestMessage(HttpMethod.Put, url) { Content = new FormUrlEncodedContent(dict) };
            var res = await client.SendAsync(req);

            if (res.IsSuccessStatusCode)
            {
                NavigationService.Navigate(new Uri("listProject.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification de ce projet!");
            }
        }
    }
}
