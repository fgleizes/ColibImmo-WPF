using System;
using System.IO;
using System.Windows;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ColibImmo_WPF.Class;

namespace ColibImmo_WPF.API
{
    internal class Client
    {
        //Cet objet permet de se connecter à une url
        HttpClient clientApi = new HttpClient();

        readonly string URL = "http://api.colibimmo.cda.ve.manusien-ecolelamanu.fr/public/";

        /**
         * Méthode pour faire la connection à l'API
         * 
         */
        private void Connect()
        {
            clientApi.BaseAddress = new Uri(URL);
            clientApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Stream?> GetCallAsync(string URI, FormData[]? formDatas = null)
        {
            Connect();
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

        public void Disconnect(string URI)
        {
            Connect();
            clientApi.GetStreamAsync(URI);
        }
    }
}
