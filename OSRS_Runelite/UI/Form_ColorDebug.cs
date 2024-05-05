using OSRS_Runelite.API;
using OSRS_Runelite.UI.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSRS_Runelite.UI
{
    public partial class Form_ColorDebug : Form
    {
        public Form_ColorDebug()
        {
            InitializeComponent();

            PaintPublisher.OnPaint += OnPaint;
        }

        private void OnPaint(object sender, Bitmap bmp)
        {
            if (bmp == null)
            {
                return;
            }

            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new PaintPublisher.EventHandler_OnPaint(OnPaint), new object[] { sender, bmp });
                return;
            }

            pictureBox1.BackgroundImage = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // PaintPublisher.RaiseEvent_OnPaint(Client.GetCanvasImage());
        }
    }
}
