using ColibImmo_WPF.API;
using ColibImmo_WPF.API.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// Logique d'interaction pour EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        public EditClientPage()
        {
            InitializeComponent();
            GetDetailsClient();
        }

        private async void BtnEditClient(object sender, RoutedEventArgs e)
        {
            string? firstnameText = firstname.Text;
            string? lastnameText = lastname.Text;
            string? mailText = mail.Text;
            string? phoneText = phone.Text;
            DataClient p = new DataClient { Firstname = firstnameText, Lastname = lastnameText, Mail = mailText, Phone = phoneText, Id_Role = 5 };
            Client api = new Client();
            Stream? streamAPI = await api.EditCallAsync(p, "person/" + idClient.id, true, null);
            this.NavigationService.Navigate(new Uri("ListClientPage.xaml", UriKind.Relative));
        }

        private async void GetDetailsClient()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("person/" + idClient.id, null, true);

            if (streamAPI != null)
            {
                DataClient? clients = JsonSerializer.DeserializeAsync<DataClient>(streamAPI).Result;

                enTête.Text ="Modification "+ clients?.Lastname + " " + clients?.Firstname;
                lastname.Text = clients?.Lastname;
                firstname.Text = clients?.Firstname;
                mail.Text = clients?.Mail;
                phone.Text = clients?.Phone;
                
                if (clients?.AddressClient == null)
                {
                    number.Text = "pas d'adresse renseigné";
                    city.Text = "pas de ville renseigné";
                    zip_code.Text = "pas de département renseigné";
                }
                else
                {
                    number.Text = clients.AddressClient.Number.ToString();
                    city.Text = "Ville : " + clients.AddressClient.City;
                    zip_code.Text = "Code département : " + clients.AddressClient.ZipCode;
                }
            }
            else
            {
                MessageBox.Show("Erreur de connexion");
            }
        }
    }
}
