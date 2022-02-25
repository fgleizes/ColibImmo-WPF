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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColibImmo_WPF
{
    /// <summary>
    /// Logique d'interaction pour CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {
        public CalendarPage()
        {
            InitializeComponent();
            GetProjects();
            cldSample.SelectedDate = DateTime.Now.AddDays(1);
        }

        private async void GetProjects()
        {
            Client api = new();
            Stream? streamAPI = await api.GetCallAsync("appointment", null, true);

            if (streamAPI != null)
            {
                List<Appointment>? appointments = JsonSerializer.DeserializeAsync<List<Appointment>>(streamAPI).Result;
                foreach (Appointment appointment in appointments)
                {
                    DateTime myStartDate = DateTime.Parse(appointment.Start);
                    DateTime myEndDate = DateTime.Parse(appointment.End);
                    appointment.AppointmentHour = myStartDate.Hour.ToString() + ":" + myStartDate.Minute.ToString() + " — " + myEndDate.Hour.ToString() + ":" + myStartDate.Minute.ToString();
                    appointment.AppointmentDate = myStartDate.Day + "/" + myStartDate.Month + "/" + myStartDate.Year;
                }
                ListAppointmentContainer.ItemsSource = appointments;
            }
            else
            {
                MessageBox.Show("Erreur de connexion.");
            }
        }
    }
}
