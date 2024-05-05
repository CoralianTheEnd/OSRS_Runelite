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

        private static readonly HttpClient client = new HttpClient();

        public static DataType? ConvertStandardClientData<DataType>(string dataPath)
        {
            string? responseData = RequestClientInformation(dataPath);

            if (string.IsNullOrWhiteSpace(responseData))
            {
                Logger.Error("Failed to request data.");
                return default;
            }
 
            try
            {
                return (DataType)Convert.ChangeType(responseData, typeof(DataType));

            }
            catch (Exception e)
            {
                Logger.Error($"Critical error in standard data conversion. \n {e.ToString}");
                return default;
            }
        }

        public static JsonClass? ConvertJsonClientData<JsonClass>(string dataPath)
        {
            string? responseData = RequestClientInformation(dataPath);

            if (string.IsNullOrWhiteSpace(responseData))
            {
                Logger.Error("Failed to request data.");
                return default;
            }

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<JsonClass>(responseData, options);

            }
            catch (Exception e)
            {
                Logger.Error($"Critical error in standard data conversion. \n {e.ToString}");
                return default;
            }
        }

        private static string? RequestClientInformation(string dataPath)
        {
            if (string.IsNullOrWhiteSpace(dataPath))
            {
                Logger.Error("Didn't pass a referance data path to request standard data.");
                return default;
            }

            string requestUri = $"{Web.Settings.HOST}:{Web.Settings.PORT}{dataPath}";

            if (!IsValidUri(requestUri))
            {
                Logger.Error("Invalid uri was constructed for standard data.");
                return default;
            }

            try
            {
                // GetAsync still returns a Task, use .Result to block 
                using HttpResponseMessage response = client.GetAsync(requestUri).Result;

                response.EnsureSuccessStatusCode(); // Throw if not a success code.


                return response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception e)
            {
                Logger.Error($"Critical error in request standard data request. \n {e.ToString}");
                return default;
            }
        }

        private static bool IsValidUri(string uriPath)
        {
            if (string.IsNullOrWhiteSpace(uriPath))
                return false;

            try
            {
                Uri uriResult;
                bool result = Uri.TryCreate(uriPath, UriKind.Absolute, out uriResult) && 
                                           (uriResult.Scheme == Uri.UriSchemeHttp ||
                                            uriResult.Scheme == Uri.UriSchemeHttps);
                return result;
            }
            catch
            {
                return false;
            }
        }
    }
}
