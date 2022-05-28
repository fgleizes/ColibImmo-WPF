using System;
using System.IO;
using System.Windows;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ColibImmo_WPF.Class;
using ColibImmo_WPF.API.JSON;
using System.Net.Http.Json;


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
         */
        private void Connect(bool isSecure = false)
        {
            clientApi.BaseAddress = new Uri(URL);
            clientApi.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (isSecure)
            {
                Token = Application.Current.Properties["apiToken"]?.ToString();
                clientApi.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token); ;
            }
            
        }
        public void Disconnect(string URI)
        {
            Connect();
            clientApi.GetStreamAsync(URI);
        }

        public async Task<Stream?> CreateCallAsync(DataClient dataClient, string URI, bool isSecure = false, FormData[]? formDatas = null)
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

            var response = (await clientApi.PostAsJsonAsync(URI + getData, dataClient));
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();
                return stream;
            }
            else
            {
                MessageBox.Show(response.ToString());
                return null;
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
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();
                return stream;
            }
            else
            {
                MessageBox.Show(response.ToString());
                return null;
            }
        }

        public async Task<Stream?> EditCallAsync(DataClient dataClient, string URI, bool isSecure = false, FormData[]? formDatas = null)
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

            var response = (await clientApi.PutAsJsonAsync(URI + getData, dataClient));
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();
                return stream;
            }
            else
            {
                MessageBox.Show(response.ToString());
                return null;
            }
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
            if (response.IsSuccessStatusCode)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();
                return stream;
            }
            else
            {
                MessageBox.Show(response.ToString());
                return null;
            }
        }
    }
}
