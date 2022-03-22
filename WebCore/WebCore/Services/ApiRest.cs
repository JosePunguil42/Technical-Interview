using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Services
{
    public static class ApiRest
    {
        public static async Task<T> PostRestAsync<T>(string controladorAccion, object objeto)
        {
            using (HttpClient oClienteHttp = ConfigurarClienteHttp())
            {
                HttpResponseMessage oRespuesta = new();
                string postCuerpo = JsonConvert.SerializeObject(objeto);
                oRespuesta = await oClienteHttp.PostAsync(controladorAccion, new StringContent(postCuerpo, Encoding.UTF8, "application/json")).ConfigureAwait(false);
                return await ManejarRespuesta<T>(oRespuesta).ConfigureAwait(false);
            }
        }

        public static async Task<T> GetRestAsync<T>(string controladorAccion)
        {
            using (HttpClient oClienteHttp = ConfigurarClienteHttp())
            {
                HttpResponseMessage oRespuesta = new();
                oRespuesta = await oClienteHttp.GetAsync(controladorAccion).ConfigureAwait(false);
                await oRespuesta.Content.ReadAsStringAsync().ConfigureAwait(false);
                return await ManejarRespuesta<T>(oRespuesta).ConfigureAwait(false);
            }
        }

        public static async Task<T> PutRestAsync<T>(string controladorAccion, object objeto)
        {
            using (HttpClient oClienteHttp = ConfigurarClienteHttp())
            {
                HttpResponseMessage oRespuesta = new();
                string postCuerpo = JsonConvert.SerializeObject(objeto);
                oRespuesta = await oClienteHttp.PutAsync(controladorAccion, new StringContent(postCuerpo, Encoding.UTF8, "application/json")).ConfigureAwait(false);
                return await ManejarRespuesta<T>(oRespuesta).ConfigureAwait(false);
            }
        }

        public static async Task<T> DeleteRestAsync<T>(string controladorAccion)
        {
            using (HttpClient oClienteHttp = ConfigurarClienteHttp())
            {
                HttpResponseMessage oRespuesta = new();
                oRespuesta = await oClienteHttp.DeleteAsync(controladorAccion).ConfigureAwait(false);
                await oRespuesta.Content.ReadAsStringAsync().ConfigureAwait(false);
                return await ManejarRespuesta<T>(oRespuesta).ConfigureAwait(false);
            }
        }

        private static HttpClient ConfigurarClienteHttp()
        {
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            string url = configuration["AppSettings:UrlRest"];
            string urlRest = url + "/";
            HttpClient oClienteHttp = new HttpClient()
            {
                BaseAddress = new Uri(urlRest)
            };
            oClienteHttp.DefaultRequestHeaders.Accept.Clear();
            return oClienteHttp;
        }

        private static async Task<T> ManejarRespuesta<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                string respuestaJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                System.Diagnostics.Debug.WriteLine(respuestaJson);
                return JsonConvert.DeserializeObject<T>(respuestaJson);
            }
            return default;
        }
    }
}
