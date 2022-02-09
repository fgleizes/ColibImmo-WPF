using System;
using System.Windows;
using System.Text.RegularExpressions;
using ColibImmo_WPF.Class;
using ColibImmo_WPF.API;
using System.Text.Json;
using ColibImmo_WPF.API.JSON;
using System.Windows.Input;
using System.Windows.Controls;
using System.IO;
using System.Threading.Tasks;

namespace ColibImmo_WPF
{
    /// <summary>
    /// Logique d'interaction pour LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void textBox_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ValidInputs();
            }
            else if (e.Key == Key.Escape)
            {
                if (e.Source.ToString() == "System.Windows.Controls.PasswordBox")
                {
                    PasswordBox? passwordBox = e.Source as PasswordBox;
                    if (passwordBox != null)
                    {
                        passwordBox.Password = "";
                    }
                } 
                else
                {
                    TextBox? txtBox = e.Source as TextBox;
                    if (txtBox != null)
                    {
                        txtBox.Text = "";
                    }
                }
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            ValidInputs();
        }

        private void ValidInputs()
        {
            bool emailBoxError;
            bool passwordBoxError;

            if (emailBox.Text.Length == 0)
            {
                errormessage1.Text = "Saisissez votre adresse email.";
                emailBox.Focus();
                emailBoxError = true;
            }
            else if (!Regex.IsMatch(emailBox.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage1.Text = "Saisissez une adresse email valide.";
                emailBox.Select(0, emailBox.Text.Length);
                emailBox.Focus();
                emailBoxError = true;
            }
            else
            {
                errormessage1.Text = "";
                emailBoxError = false;
            }

            if (passwordBox.Password.ToString().Length == 0)
            {
                errormessage2.Text = "Saisissez votre mot de passe.";
                emailBox.Focus();
                passwordBoxError = true;
            }
            else
            {
                errormessage2.Text = "";
                passwordBoxError = false;
            }

            if (emailBoxError == false && passwordBoxError == false)
            {
                Login();
            }
        }

        private async void Login()
        {
            string email = emailBox.Text;
            string password = passwordBox.Password;

            FormData[] formDataArray = new FormData[]
            {
                new FormData
                {
                    Field = "mail",
                    Value = email
                },
                new FormData
                {
                    Field = "password",
                    Value = password
                }
            };

            Client api = new Client();
            Stream? streamAPI = await api.GetCallAsync("user/login", formDataArray);

            if(streamAPI != null)
            {
                Auth? auth = JsonSerializer.DeserializeAsync<Auth>(streamAPI).Result;
                Application.Current.Properties.Add("apiToken", auth.Token);
                errormessage3.Text = "";
                Hide();
                var window = new MainWindow();
                window.Owner = this;
                window.Show();
                MessageBoxResult result = MessageBox.Show(Application.Current.Properties["apiToken"] as string);
            }
            else
            {
                errormessage3.Text = "Votre identifiant ou votre mot de passe est erroné.";
                MessageBox.Show("Erreur de connexion.");
            }
        }
    }
}
