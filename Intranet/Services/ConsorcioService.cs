using Intranet.ServicesInterfaces;
using Intranet.Util;
using Models_core;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Intranet.Services
{
    public class ConsorcioService : IConsorcioService
    {
        private readonly HttpClient _httpClient;
        string urlApiCore = "";
        Funciones funciones = new Funciones();

        public ConsorcioService(IConfiguration _config)
        {
            _httpClient = new HttpClient();
            urlApiCore = _config[nameof(AppSettings.urlApiCore)];
        }

        public bool Delete(int id)
        {
            bool rpta = false;

            string ruta = urlApiCore + "/Consorcio/" + id;

            using (var cliente = new HttpClient { BaseAddress = new Uri(urlApiCore) })
            {
                HttpResponseMessage message =
                    cliente.DeleteAsync(ruta).Result;

                if (message.IsSuccessStatusCode)
                    rpta = true;
            }
            return rpta;
        }

        public async Task<List<Consorcio>> GetAll()
        {
            List<Consorcio> lista = new List<Consorcio>();
            var url = $"{urlApiCore}/Consorcio";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;

                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            var jsonStringResult = JsonConvert.DeserializeObject<List<Consorcio>>(responseBody);

                            lista = jsonStringResult;
                        }

                    }
                }
            }
            catch (WebException ex)
            {
                lista = null;
            }
            return lista;
        }

        public async Task<Consorcio> GetByID(int id)
        {
            Consorcio lista = new Consorcio();
            var url = $"{urlApiCore}/Consorcio/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;

                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            var jsonStringResult = JsonConvert.DeserializeObject<Consorcio>(responseBody);

                            lista = jsonStringResult;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                lista = null;
            }
            return lista;
        }

        public bool Insertar(Consorcio consorcio)
        {
            bool rpta = false;
            var itemJson = JsonConvert.SerializeObject(consorcio);

            string ruta = urlApiCore + "/Consorcio";

            using (var cliente = new HttpClient { BaseAddress = new Uri(urlApiCore) })
            {
                var inputMessage = new HttpRequestMessage
                {
                    Content = new StringContent(itemJson, Encoding.UTF8, "application/json")
                };

                inputMessage.Method = HttpMethod.Post;
                inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage message =
                    cliente.PostAsync(ruta, inputMessage.Content).Result;

                if (message.IsSuccessStatusCode)
                {
                    rpta = true;
                }
                else
                    rpta = false;
            }

            return rpta;
        }

        public bool Update(Consorcio consorcio)
        {
            bool rpta = false;
            var itemJson = JsonConvert.SerializeObject(consorcio);

            string ruta = urlApiCore + $"/Consorcio/{consorcio.id}";

            using (var cliente = new HttpClient { BaseAddress = new Uri(urlApiCore) })
            {
                var inputMessage = new HttpRequestMessage
                {
                    Content = new StringContent(itemJson, Encoding.UTF8, "application/json")
                };

                inputMessage.Method = HttpMethod.Put;
                inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage message =
                    cliente.PutAsync(ruta, inputMessage.Content).Result;

                if (message.IsSuccessStatusCode)
                {
                    rpta = true;
                }
                else
                    rpta = false;
            }

            return rpta;
        }

    }
}
