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

        private async void GetDetailsClient()
        {
            Client api = new Client();
            api.Token = Application.Current.Properties["apiToken"].ToString();
            Stream? streamAPI = await api.GetCallAsync("person/" + idClient.id, null, true);

            if (streamAPI != null)
            {

                DataClient? clients = JsonSerializer.DeserializeAsync<DataClient>(streamAPI).Result;


                this.enTête.Text ="Modification "+ clients.Lastname + " " + clients.Firstname;
                this.lastname = clients.Lastname;
                this.firstname = clients.Firstname;

                //this.created_at.Text = "Date inscription : " + clients.Created_at;
                //this.mail.Text = "Mail : " + clients.Mail;
                //this.phone.Text = "Phone : " + clients.Phone;

                if (clients.Address == null)
                {
                    //this.adresse.Text = "pas d'adresse renseigné";
                    //this.city.Text = "pas de ville renseigné";
                    //this.zip_code.Text = "pas de département renseigné";
                }

                else
                {

                    //this.adresse.Text = "Adresse : " + clients.Address.Number.ToString() + " " + clients.Address.Street;
                    //this.city.Text = "Ville : " + clients.Address.City;
                    //this.zip_code.Text = "Code département : " + clients.Address.Zip_code;
                }

            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }
    }
}
