using OSRS_Runelite.WinAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API
{
    internal class Client
    {
        public static Bitmap? GetCanvasImage()
        {
            if (Settings.pPrimaryGameWindow == IntPtr.Zero)
            {
                // Log error: Primary client window handle is not set.
                return null;
            }

            Structures.RECT rect;
            // Get the dimensions of the window
            unsafe
            {
                if (!Native.GetWindowRect(Settings.pPrimaryGameWindow, &rect))
                {
                    // Log error: Failed to get window dimensions.
                    return null;
                }
            }

            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            // Validate window dimensions
            if (width <= 0 || height <= 0)
            {
                // Log error: Window dimensions are invalid.
                return null;
            }

            // Get the device context of the window
            IntPtr hdcSrc = Native.GetWindowDC(Settings.pPrimaryGameWindow);
            if (hdcSrc == IntPtr.Zero)
            {
                // Log error: Failed to get device context of the window.
                return null;
            }

            IntPtr hdcDest = Native.CreateCompatibleDC(hdcSrc);
            if (hdcDest == IntPtr.Zero)
            {
                // Log error: Failed to create compatible device context.
                _ = Native.ReleaseDC(Settings.pPrimaryGameWindow, hdcSrc);
                return null;
            }

            IntPtr hBitmap = Native.CreateCompatibleBitmap(hdcSrc, width, height);
            if (hBitmap == IntPtr.Zero)
            {
                // Log error: Failed to create compatible bitmap.
                _ = Native.DeleteDC(hdcDest);
                _ = Native.ReleaseDC(Settings.pPrimaryGameWindow, hdcSrc);
                return null;
            }

            IntPtr hOld = Native.SelectObject(hdcDest, hBitmap);
            if (!Native.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, Constants.SRCCOPY))
            {
                // Log error: Failed to perform BitBlt operation.
                _ = Native.SelectObject(hdcDest, hOld);
                _ = Native.DeleteObject(hBitmap);
                _ = Native.DeleteDC(hdcDest);
                _ = Native.ReleaseDC(Settings.pPrimaryGameWindow, hdcSrc);
                return null;
            }

            Bitmap bmp = null;
            try
            {
                bmp = Image.FromHbitmap(hBitmap);
            }
            catch (Exception)
            {
                // Log error: Failed to create Bitmap from HBITMAP.
            }

            _ = Native.SelectObject(hdcDest, hOld);
            _ = Native.DeleteObject(hBitmap);
            _ = Native.DeleteDC(hdcDest);
            _ = Native.ReleaseDC(Settings.pPrimaryGameWindow, hdcSrc);

            return bmp;
        }
    }
}
