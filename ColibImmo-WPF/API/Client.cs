using System;
using System.IO;
using System.Windows;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ColibImmo_WPF.Class;
using System.Windows.Navigation;

namespace ColibImmo_WPF.API
{
    internal class Client
    {
        //Cet objet permet de se connecter à une url
        HttpClient clientApi = new HttpClient();
        
        readonly string URL = "http://api.colibimmo.cda.ve.manusien-ecolelamanu.fr/public/";

        public string? Token { get; set; }

        /**
         * Méthode pour faire la connection à l'API
         * 
         */
        private void Connect(bool isSecure = false)
        {
            clientApi.BaseAddress = new Uri(URL);
            clientApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (isSecure)
            {
                Token = Application.Current.Properties["apiToken"].ToString();
                clientApi.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token); ;
            }
            
        }

        



      

        public async Task<Stream?> GetCallAsync(string URI, FormData[]? formDatas = null, bool isSecure = false)
        {
            Connect(isSecure);
            string getData = "";
            if (formDatas != null)
            {
                getData += "?";
                bool isFirst = true;
                string glueData = "";
                foreach (FormData formData in formDatas)
                {
                    if (!isFirst)
                    {
                        glueData = "&";
                    }
                    getData += glueData + formData.Field + "=" + formData.Value;
                    isFirst = false;
                }
            }

            HttpResponseMessage response = await clientApi.GetAsync(URI + getData);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            Stream stream = await response.Content.ReadAsStreamAsync();
            return stream;
        }

      



        public async Task<Stream?> DeleteCallAsync(string URI, FormData[]? formDatas = null, bool isSecure = false)
        {
            Connect(isSecure);
            string getData = "";
            if (formDatas != null)
            {
                getData += "?";
                bool isFirst = true;
                string glueData = "";
                foreach (FormData formData in formDatas)
                {
                    if (!isFirst)
                    {
                        glueData = "&";
                    }
                    getData += glueData + formData.Field + "=" + formData.Value;
                    isFirst = false;
                }
            }

            HttpResponseMessage response = await clientApi.DeleteAsync(URI + getData);
            if (!response.IsSuccessStatusCode)
            {
                return null;

            }
            Stream stream = await response.Content.ReadAsStreamAsync();
            MessageBox.Show("client supprimé");

            return stream;
            


        }

       





        public void Disconnect(string URI)
        {
            Connect();
            clientApi.GetStreamAsync(URI);
        }
    }
}
