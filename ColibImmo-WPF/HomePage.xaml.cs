using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
    /// Logique d'interaction pour HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public System.Windows.CornerRadius CornerRadius { get; set; }
        public HomePage()
        {
            InitializeComponent();
            Welcome();
        }

        public void Welcome()
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            welcomeMessage.Text = $"Bienvenue {ti.ToTitleCase(Application.Current.Properties["firstname"].ToString())} {ti.ToTitleCase(Application.Current.Properties["lastname"].ToString())} sur ColibImmo";
        }
    }
}
