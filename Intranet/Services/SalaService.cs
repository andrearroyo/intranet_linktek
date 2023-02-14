using Intranet.ServicesInterfaces;
using Intranet.Util;
using Models_core;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Intranet.Services
{
    public class SalaService : ISalaService
    {
        private readonly HttpClient _httpClient;
        string urlApiCore = "";
        Funciones funciones = new Funciones();

        public SalaService(IConfiguration _config)
        {
            _httpClient = new HttpClient();
            urlApiCore = _config[nameof(AppSettings.urlApiCore)];
        }

        public bool Delete(int id)
        {
            bool rpta = false;

            string ruta = urlApiCore + "/Sala/" + id;

            using (var cliente = new HttpClient { BaseAddress = new Uri(urlApiCore) })
            {
                HttpResponseMessage message =
                    cliente.DeleteAsync(ruta).Result;

                if (message.IsSuccessStatusCode)
                    rpta = true;
            }
            return rpta;
        }

        public async Task<List<Sala>> GetAll()
        {
            List<Sala> lista = new List<Sala>();
            var url = $"{urlApiCore}/Sala";
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

                            var jsonStringResult = JsonConvert.DeserializeObject<List<Sala>>(responseBody);

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

        public async Task<Sala> GetByID(int id)
        {
            Sala lista = new Sala();
            var url = $"{urlApiCore}/Sala/{id}";
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

                            var jsonStringResult = JsonConvert.DeserializeObject<Sala>(responseBody);

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

        public bool Insertar(Sala sala)
        {
            bool rpta = false;
            var itemJson = JsonConvert.SerializeObject(sala);

            string ruta = urlApiCore + "/Sala";

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

        public bool Update(Sala sala)
        {
            bool rpta = false;
            var itemJson = JsonConvert.SerializeObject(sala);

            string ruta = urlApiCore + $"/Sala/{sala.idSala}";

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
