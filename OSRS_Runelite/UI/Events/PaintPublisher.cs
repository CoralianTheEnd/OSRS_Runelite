using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.UI.Events
{
    internal class PaintPublisher
    {
        public delegate void EventHandler_OnPaint(object sender, Bitmap bmp);

        public static event EventHandler_OnPaint OnPaint;

        public static void RaiseEvent_OnPaint(Bitmap bmp)
        {
            // Check if there are subscribers to the event
            // Raise the event with custom parameters
            OnPaint?.Invoke(null, bmp);
        }
    }
}
