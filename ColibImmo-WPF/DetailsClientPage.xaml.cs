using ColibImmo_WPF.API;
using ColibImmo_WPF.API.JSON;
using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace ColibImmo_WPF
{
    public partial class DetailsClientPage : Page
    {
        public DetailsClientPage()
        {
            InitializeComponent();
            GetDetailsClient();
            GetProjectsListByClient();
            GetAppointmentsListByClient();
        }

        private async void GetDetailsClient()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("person/" + idClient.id, null, true);

            if (streamAPI != null)
            {
                DataClient? clients = JsonSerializer.DeserializeAsync<DataClient>(streamAPI).Result;

                lastname.Text = $"{clients?.Lastname} {clients?.Firstname}";
                created_at.Text = $"Date inscription : {DateTime.Parse(clients?.Created_at)}";
                mail.Text = $"Mail : {clients?.Mail}";
                phone.Text = $"Phone : {clients?.Phone}";

                if (clients?.AddressClient == null)
                {
                    adresse.Text = "Pas d'adresse renseigné";
                    city.Text = "Pas de ville renseigné";
                    zip_code.Text = "Pas de département renseigné";
                }
                else
                {
                    adresse.Text = $"Adresse : {clients.AddressClient.Number} {clients.AddressClient.Street}";
                    city.Text = $"Ville : {clients.AddressClient.City}";
                    zip_code.Text = $"Code département : {clients.AddressClient.ZipCode}";
                }
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

        private async void GetProjectsListByClient()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("project/person/"+idClient.id, null, true);
            
            if (streamAPI != null)
            {
                ProjectClient[]? projects = JsonSerializer.DeserializeAsync<ProjectClient[]>(streamAPI).Result;
                ListProjectByClientContainer.ItemsSource = projects;
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

        private async void GetAppointmentsListByClient()
        {
            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("appointment/customerAppointments/" + idClient.id, null, true);

            if (streamAPI != null)
            {
                Appointment[]? appointments = JsonSerializer.DeserializeAsync<Appointment[]>(streamAPI).Result;
                if (appointments != null)
                {
                    foreach (Appointment appointment in appointments)
                    {
                        if (appointment.Start != null && appointment.End != null)
                        {
                            DateTime myStartDate = DateTime.Parse(appointment.Start);
                            DateTime myEndDate = DateTime.Parse(appointment.End);
                            appointment.AppointmentHour = $"{myStartDate.Hour} : {myStartDate.Minute} — {myEndDate.Hour} : {myStartDate.Minute}";
                            appointment.Start = myStartDate.ToShortDateString();
                        }
                    
                    }
                    ListAppointmentByClientContainer.ItemsSource = appointments;
                }
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }
    }
}
