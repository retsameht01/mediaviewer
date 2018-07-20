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
        private Uri baseAPIURL;
        public string ErrorMessage { get; set; }
        private String credentialBase64;
        //https://www.gposdev.com/20003/api/
        public GposApi(string apiURL, string apiPass)
        {
            credentialBase64 = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes("admin:" + apiPass));
            try
            {
                baseAPIURL = new Uri(apiURL);
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
                    httpClient.BaseAddress = baseAPIURL;
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
                    httpClient.BaseAddress = baseAPIURL;
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
                    httpClient.BaseAddress = baseAPIURL;
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
