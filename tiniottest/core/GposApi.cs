using System;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace core
{
	public class GposApi<T> where T : class
    {
        private Uri baseAddress;
        public string ErrorMessage { get; set; }
        private String credentialBase64;
        public GposApi()
        {
            credentialBase64 = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes("admin:6786716888"));
            try
            {
                baseAddress = new Uri("https://www.gposdev.com/20002/api/");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
        public Task<T> GetAsync(string endpoint)
        {
            return Task.Run<T>(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    var responseString = string.Empty;
                    httpClient.BaseAddress = baseAddress;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentialBase64);
                    try
                    {
                        responseString = await httpClient.GetStringAsync(endpoint);
                        var returnedObject = JsonConvert.DeserializeObject<T>(responseString);
                        return returnedObject;
                    }
                    catch (Exception ex)
                    {
                        var mesg = ex.Message;
                        return null;
                    }
                }
            });
        }
        public Task<string> PostAsync(string endpoint, T postObject)
        {
            return Task.Run<string>(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(
                            postObject,
                            Formatting.Indented,
                            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    httpClient.BaseAddress = baseAddress;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                   
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentialBase64);
                    try
                    {
                        var responseMessage = await httpClient.PostAsync(endpoint, content);
                        var stringResponse = await responseMessage.Content.ReadAsStringAsync();
                        return stringResponse;
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            });
        }

        public Task<string> PutAsync(string endpoint, T postObject)
        {
            return Task.Run<string>(async () =>
            {
                using (var httpClient = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(
                            postObject,
                            Formatting.Indented,
                            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    httpClient.BaseAddress = baseAddress;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentialBase64);
                    try
                    {
                        var responseMessage = await httpClient.PutAsync(endpoint, content);
                        var stringResponse = await responseMessage.Content.ReadAsStringAsync();
                        return stringResponse;
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            });
        }

    }    
}
