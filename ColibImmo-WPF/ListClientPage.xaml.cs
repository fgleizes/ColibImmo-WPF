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
using System.IO;
using System.Text.Json;

namespace ColibImmo_WPF
{
    public static class idClient
    {
        public static string? id;
        
    }
    /// <summary>
    /// Logique d'interaction pour ListClientPage.xaml
    /// </summary>
    public partial class ListClientPage : Page
    {
        public ListClientPage()
        {
            InitializeComponent();
            GetClients();
        }
        private async void GetClients()
        {
            Client api = new Client();
<<<<<<< HEAD
            api.Token = Application.Current.Properties["apiToken"].ToString();
            Stream? streamAPI = await api.GetCallAsync("person/role/5",null,true);
            
=======
            Stream? streamAPI = await api.GetCallAsync("person/role/5",null,true);

>>>>>>> d7a069493c664c91b19252ab0211e828df4cc9a5
            if (streamAPI != null)
            {
                DataClient[]? clients = JsonSerializer.DeserializeAsync<DataClient[]>(streamAPI).Result;
                ListClientContainer.ItemsSource = (System.Collections.IEnumerable?)clients;
                
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

      



        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //private async void DeleteClient (object sender, RoutedEventArgs e)
        //{
        //    Client api = new Client();
        //    Button idButton = (Button)sender;
        //    idClient.id = idButton.Tag.ToString();
        //    Stream? streamAPI = await api.GetCallAsync("person/" + idClient.id);
            


        //}
        

        private void BtnDetailsClientPage(object sender, RoutedEventArgs e)
        {
            Button idButton = (Button)sender;
            idClient.id = idButton.Tag.ToString();
            
            this.NavigationService.Navigate(new Uri("DetailsClientPage.xaml", UriKind.Relative));
        }
    }
}
