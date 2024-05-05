using OSRS_Runelite.API.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Web
{
    internal class RequestData
    {
        // HttpClient is intended to be instantiated once and re-used throughout the life of an application.
        private static readonly HttpClient client = new HttpClient();

        internal static object BuildJson<T>(string dataType)
        {
            string rawJson = RequestClientData(dataType);

            if (rawJson == null)
            {
                Logger.Error("Failed to pull down JSON data from local host.");
                return null;
            }

            try
            {
                return JsonSerializer.Deserialize<T>((rawJson));

            }
            catch (Exception)
            {
                Logger.Error("Failed to format Json to provided class.");
                return null;
            }
        }

        public static T? RequestClientData<T>(string dataPath)
        {
            string requestUri = $"http://127.0.0.1:8080{dataPath}";

            if (string.IsNullOrEmpty(dataPath))
            {
                return default; // or throw an exception depending on how you want to handle this case
            }

            try
            {
                HttpResponseMessage response = client.GetAsync(requestUri).Result;
                response.EnsureSuccessStatusCode(); // Throw if not a success code.
                string responseContent = response.Content.ReadAsStringAsync().Result;

                // Attempt to convert the response string to the type T
                return (T)Convert.ChangeType(responseContent, typeof(T));

            }
            catch (Exception)
            {

                return default;
            }

        }

        public static string? RequestClientData(string dataPath)
        {
            string requestUri = $"http://127.0.0.1:8080{dataPath}";

            if (string.IsNullOrEmpty(requestUri))
            {
                return null; // or throw an exception depending on how you want to handle this case
            }

            try
            {
                HttpResponseMessage response = client.GetAsync(requestUri).Result; // GetAsync still returns a Task, use .Result to block
                response.EnsureSuccessStatusCode(); // Throw if not a success code.
                return response.Content.ReadAsStringAsync().Result; // Block and get the content as string
            }
            catch (AggregateException ae)
            {
                Console.WriteLine($"Error fetching data: {ae.Flatten().InnerException.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return null;
            }
        }

      
    }
}
