using static OSRS_Runelite.WinAPI.Native;
using OSRS_Runelite.API.Wrappers.GameData;
using OSRS_Runelite.API;
using OSRS_Runelite.WinAPI;
using OSRS_Runelite.API.Script;
using OSRS_Runelite.API.Wrappers.Ids;
using OSRS_Runelite.API.Helper;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace OSRS_Runelite.UI
{
    public partial class Form_Main : Form
    {
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

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            //CameraContainer cameraContainer = new CameraContainer();

            //Console.WriteLine(cameraContainer.Camera.Yaw);
            //Console.WriteLine(cameraContainer.Camera.Pitch);
            //Console.WriteLine(cameraContainer.Camera.Zoom);
            //Console.WriteLine(cameraContainer.Camera.X);
            //Console.WriteLine(cameraContainer.Camera.Y);
            //Console.WriteLine(cameraContainer.Camera.Z);
            //Console.WriteLine(cameraContainer.Camera.X2);
            //Console.WriteLine(cameraContainer.Camera.Y2);
            //Console.WriteLine(cameraContainer.Camera.Z2);

            API.Input.Keyboard.keyboardRotateToYaw(2000);
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {

        }

        AbstractScript scriptTarget;

        private void stopScriptLabel_Click(object sender, EventArgs e)
        {
            if (scriptTarget != null)
            {
                scriptTarget.Stop();
            }
        }

        private void startScriptLabel_Click(object sender, EventArgs e)
        {
            scriptTarget = new Woodcutting();
            scriptTarget.Start();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            // TestScript ts = new TestScript();
            // ts.Start();

            // Console.Write(DynamicLocalPlayer.CombatLevel);
        }

        public class TestScript : AbstractScript
        {
            public override void OnRun()
            {
                base.OnRun();

                while (true)
                {
                    var inv =
    InventoryContainer.FindItemsById(Items.WILLOW_LOG);

                    Console.WriteLine(inv.Count);

                    inv[0].RightClick();

                    Thread.Sleep(1000);
                }



            }
        }
    }
}
