namespace MG.Empleados.AD
{
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    public class ADCallApi
    {

        public static async Task<string> ConsultarDataGET(string Url = "http://masglobaltestapi.azurewebsites.net/api/Employees")
        {
            string responseContent = "";

            // Envuelva nuestro JSON dentro de un StringContent que luego puede ser utilizado por la clase HttpClient
            //var httpContent = new StringContent(await Task.Run(() => JsonConvert.SerializeObject(Parametro)), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                // Se hace una peticion y se espera una respuesta
                var httpResponse = await httpClient.GetAsync(Url);

                // Si la respuesta es diferente de null, hacemos la lectura del contenido
                if (httpResponse.Content != null)
                {
                    responseContent = await httpResponse.Content.ReadAsStringAsync();
                }
            }
            return responseContent;
        }




    }
}
