using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace ColibImmo_WPF
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            Welcome();
        }

        public void Welcome()
        {
            TextInfo? ti = CultureInfo.CurrentCulture.TextInfo;
            if(Application.Current.Properties != null)
            {
                string? firstname = Application.Current.Properties["firstname"]?.ToString();
                string? lastname = Application.Current.Properties["lastname"]?.ToString();

                if(firstname != null && lastname != null)
                {
                    welcomeMessage.Text = $"Bienvenue {ti.ToTitleCase(firstname)} {ti.ToTitleCase(lastname)} sur ColibImmo";
                }
            }
        }
    }
}

