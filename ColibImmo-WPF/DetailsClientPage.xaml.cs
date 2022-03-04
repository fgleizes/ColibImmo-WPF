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
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class DetailsClientPage : Page
    {
        public DetailsClientPage()
        {
            InitializeComponent();
            GetDetailsClient();
            GetProjectsListByClient();
            GetAppointmentsListByClient();
        }

        private async void GetProjectsListByClient()
        {
            Client api = new Client();
            api.Token = Application.Current.Properties["apiToken"].ToString();
            Stream? streamAPI = await api.GetCallAsync("project/person/"+idClient.id, null, true);
            
            if (streamAPI != null)
            {
                Project[]? projects = JsonSerializer.DeserializeAsync<Project[]>(streamAPI).Result;
                ListProjectByClientContainer.ItemsSource = (System.Collections.IEnumerable?)projects;
                
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

        private async void GetAppointmentsListByClient()
        {
            Client api = new Client();
            api.Token = Application.Current.Properties["apiToken"].ToString();
            Stream? streamAPI = await api.GetCallAsync("appointment/customerAppointments/" + idClient.id, null, true);

            if (streamAPI != null)
            {
                Appointment[]? appointments = JsonSerializer.DeserializeAsync<Appointment[]>(streamAPI).Result;
                foreach (Appointment appointment in appointments)
                {
                    DateTime myStartDate = DateTime.Parse(appointment.Start);
                    DateTime myEndDate = DateTime.Parse(appointment.End);
                    appointment.AppointmentHour = myStartDate.Hour.ToString() + ":" + myStartDate.Minute.ToString() + " — " + myEndDate.Hour.ToString() + ":" + myStartDate.Minute.ToString();
                    appointment.Start = myStartDate.ToShortDateString();
                    
                }
                ListAppointmentByClientContainer.ItemsSource = appointments;
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

        private async void GetDetailsClient()
        {
            Client api = new Client();
            api.Token = Application.Current.Properties["apiToken"].ToString();
            Stream? streamAPI = await api.GetCallAsync("person/"+idClient.id,null, true);
            
            if (streamAPI != null)
            {

                DataClient? clients = JsonSerializer.DeserializeAsync<DataClient>(streamAPI).Result;
                

                this.lastname.Text = clients.Lastname+" "+clients.Firstname;
                this.created_at.Text ="Date inscription : "+clients.Created_at;
                this.mail.Text ="Mail : "+clients.Mail;
                this.phone.Text = "Phone : " + clients.Phone;

                if (clients.Address == null)
                {
                    this.adresse.Text = "pas d'adresse renseigné";
                    this.city.Text = "pas de ville renseigné";
                    this.zip_code.Text = "pas de département renseigné";
                }

                else
                {

                this.adresse.Text = "Adresse : "+clients.Address.Number.ToString()+" " +clients.Address.Street;
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
