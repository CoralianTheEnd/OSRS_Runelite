using static OSRS_Runelite.WinAPI.Native;
using OSRS_Runelite.API.Wrappers.GameData;
using OSRS_Runelite.API;
using OSRS_Runelite.WinAPI;
using OSRS_Runelite.API.Script;
using OSRS_Runelite.API.Wrappers.Ids;
using OSRS_Runelite.API.Helper;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text;
using System.Web;

namespace OSRS_Runelite.UI
{
    public partial class Form_Main : Form
    {
        private AbstractScript scriptTarget;

        public Form_Main()
        {
            InitializeComponent();
        }

        private void toolStripLabel_FindWindow_Click(object sender, EventArgs e)
        {

            IntPtr pMainWindowHandle = Native.FindWindow(null, "RuneLite - Coralian-Boo"); //  - Coralian-Boo

            if (pMainWindowHandle == IntPtr.Zero)
            {
                Console.WriteLine("Failed main window find.");
                return;
            }
            Console.WriteLine("Found RuneLite main window handle.");

            IntPtr pSecondaryWindow = FindWindowEx(pMainWindowHandle, 0, "SunAwtCanvas", null);

            if (pSecondaryWindow == IntPtr.Zero)
            {
                Console.WriteLine("Failed first canvas find.");
                return;
            }
            Console.WriteLine("Found first RuneScape window handle.");


            IntPtr pTrueCanvas = FindWindowEx(pSecondaryWindow, 0, "SunAwtCanvas", null);

            if (pTrueCanvas == IntPtr.Zero)
            {
                Console.WriteLine("Failed primary canvas find.");
                return;
            }
            Console.WriteLine("Found primary RuneScape window handle.");

            Settings.pMainWindow = pMainWindowHandle;
            Settings.pFirstGameWindow = pSecondaryWindow;
            Settings.pPrimaryGameWindow = pTrueCanvas;

        }

        private void stopScriptLabel_Click(object sender, EventArgs e)
        {
            if (scriptTarget != null)
            {
                scriptTarget.Stop();
            }
        }

        private void startScriptLabel_Click(object sender, EventArgs e)
        {
            //scriptTarget = new Woodcutting();
            //scriptTarget.Start();

            //scriptTarget = new Mining();
            //scriptTarget.Start();

            scriptTarget = new Fishing();
            scriptTarget.Start();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            List<Npc> v = API.Methods.Interactives.Npcs.GetAll();
            foreach (Npc item in v)
            {
                Console.WriteLine(item.Name.ToString());

                Console.WriteLine(item.Id.ToString());

                Console.WriteLine(item.ClickBox.ToString());

                if (item.Name.Equals("Rod Fishing spot"))
                {
                    item.LeftClick();
                }
            }


        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            API.Input.Keyboard.keyboardRotateToYaw(2000);
        }

        private async void toolStripLabel3_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            try
            {
                string type = "Objects";
                int[] ids = { 11364, 11365 };
                string requestBody = $"Type:{type} Ids:{string.Join(", ", ids)}";

                HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:8080/Post",
                    new StringContent(requestBody, System.Text.Encoding.UTF8, "text/plain"));
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }
            finally
            {
                client.Dispose();
            }
        }

        HttpClient client = new HttpClient();

        async Task<string> SendPostDataAsync(string url, Dictionary<string, string> data)
        {
            // Serialize the dictionary to JSON
            string jsonData = JsonSerializer.Serialize(data);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Request successful.");
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
                return responseContent; // Return the response content
            }
            else
            {
                Console.WriteLine($"Failed to send request: {response.StatusCode}");
                return $"Error: {response.StatusCode}";
            }
        }

        async Task<string> SendMultipleIdsAsync(string url, List<string> ids)
        {
            // Join IDs with a comma
            string idString = String.Join(",", ids);
            // Encode the string to ensure safe transmission
            idString = HttpUtility.UrlEncode(idString);

            // Form the data to send
            Dictionary<string, string> formData = new Dictionary<string, string>
            {
                { "Type", "Objects" },
                { "Id", idString }
            };

            var content = new FormUrlEncodedContent(formData);
            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return responseContent;
            }
            else
            {
                return $"Error: {response.StatusCode}";
            }
        }
    }
}
