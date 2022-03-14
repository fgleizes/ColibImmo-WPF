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
            MessageBox.Show("hum1");
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
            api.Token = Application.Current.Properties["apiToken"].ToString();
            Stream? streamAPI = await api.GetCallAsync("person/" + idClient.id, null, true);

            if (streamAPI != null)
            {

                DataClient? clients = JsonSerializer.DeserializeAsync<DataClient>(streamAPI).Result;


                this.enTête.Text ="Modification "+ clients.Lastname + " " + clients.Firstname;
                this.lastname.Text = clients.Lastname;
                this.firstname.Text = clients.Firstname;
                this.mail.Text = clients.Mail;
                this.phone.Text = clients.Phone;
                

                

                if (clients.Address == null)
                {
                    this.number.Text = "pas d'adresse renseigné";
                    this.city.Text = "pas de ville renseigné";
                    this.zip_code.Text = "pas de département renseigné";
                }

                else
                {

                    this.number.Text = clients.Address.Number.ToString();
                    this.city.Text = "Ville : " + clients.Address.City;
                    this.zip_code.Text = "Code département : " + clients.Address.Zip_code;
                }

            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }
    }
}
