using Intranet.ServicesInterfaces.Planes;
using Intranet.Util;
using Models_core;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Intranet.Services.Planes
{
    public class LicenciaService : ILicenciaService
    {
        private readonly HttpClient _httpClient;
        string urlApiCore = "";
        Funciones funciones = new Funciones();

        public LicenciaService(IConfiguration _config)
        {
            _httpClient = new HttpClient();
            urlApiCore = _config[nameof(AppSettings.urlApiCore)];
        }

        public async Task<List<Licencia>> GetAll()
        {
            List<Licencia> lista = new List<Licencia>();
            var url = $"{urlApiCore}/Licencia";
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

                            var jsonStringResult = JsonConvert.DeserializeObject<List<Licencia>>(responseBody);

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

        public async Task<Licencia> GetByIDs(int idPaquete, int idSala)
        {
            Licencia lista = new Licencia();
            var url = $"{urlApiCore}/Licencia/{idPaquete}/{idSala}";
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

                            var jsonStringResult = JsonConvert.DeserializeObject<Licencia>(responseBody);

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

        public async Task<Licencia> GetLicenciaRemota(int idSistema, int idSala, DateTime date)
        {

            string fecha = date.ToString("dd-MM-yyyy hh:mm:ss");

            Licencia lista = new Licencia();
            var url = $"{urlApiCore}/Licencia/GetLicenciaRemota/{idSistema}/{idSala}/{fecha}";
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

                            var jsonStringResult = JsonConvert.DeserializeObject<Licencia>(responseBody);

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

        public bool Insert(Licencia item)
        {
            bool rpta = false;
            var itemJson = JsonConvert.SerializeObject(item);

            string ruta = urlApiCore + "/Licencia";

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
    }
}
