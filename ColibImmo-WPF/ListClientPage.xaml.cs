using ColibImmo_WPF.API;
using ColibImmo_WPF.API.JSON;
using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace ColibImmo_WPF
{
    public static class idClient
    {
        public static string? id;
        
    }

    public static class AddFormClientContent
    {
        public static string? Content;
    }

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
            Stream? streamAPI = await api.GetCallAsync("person/role/5",null,true);

            if (streamAPI != null)
            {
                DataClient[]? clients = JsonSerializer.DeserializeAsync<DataClient[]>(streamAPI).Result;
                ListClientContainer.ItemsSource = clients;
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

        private async void BtnCreateClient(object sender, RoutedEventArgs e)
        {
            string firstnameText = firstnameAddForm.Text;
            string lastnameText = lastnameAddForm.Text;
            string mailText = mailAddForm.Text;
            string phoneText = phoneAddForm.Text;
            DataClient p = new DataClient { Firstname = firstnameText, Lastname = lastnameText, Mail = mailText, Phone = phoneText, Id_Role = 5 };
            Client api = new Client();
            await api.CreateCallAsync(p,"person", true, null);
            NavigationService.Navigate(new Uri("ListClientPage.xaml", UriKind.Relative));
        }

        private async void BtnDeleteClients(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirmez-vous vouloir supprimer ce client ?", "Supprimer client", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Client api = new Client();
                Button idButton = (Button)sender;
                idClient.id = idButton.Tag.ToString();
                await api.DeleteCallAsync("person/"+idClient.id, null, true);
                InitializeComponent();
                GetClients();
            }
        }
    
        private void BtnDetailsClientPage(object sender, RoutedEventArgs e)
        {
            Button idButton = (Button)sender;
            idClient.id = idButton.Tag.ToString();
            NavigationService.Navigate(new Uri("DetailsClientPage.xaml", UriKind.Relative));
        }

        private void BtnEditClientPage(object sender, RoutedEventArgs e)
        {
            Button idButton = (Button)sender;
            idClient.id = idButton.Tag.ToString();
            NavigationService.Navigate(new Uri("EditClientPage.xaml", UriKind.Relative));
        }
        
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
