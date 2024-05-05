using OSRS_Runelite.WinAPI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Imaging
{
    internal class Filter
    {
        // Function to match multiple colors for the target colors within a specific rectangle
        public List<Point> MatchMultipleColors(Bitmap parentBitmap, List<Color> targetColors, Rectangle searchArea, int tolerance)
        {
            // Verify arguments
            if (parentBitmap == null || targetColors == null || targetColors.Count == 0 || searchArea == Rectangle.Empty || tolerance < 0)
            {
                LogError("Invalid arguments: parentBitmap, targetColors, searchArea, or tolerance is invalid.");
                return null;
            }

            List<Point> matches = new List<Point>();

            // Lock the bitmap data to prevent unsafe access
            BitmapData bitmapData = parentBitmap.LockBits(searchArea, ImageLockMode.ReadOnly, parentBitmap.PixelFormat);
            bool errorOccured = false;

            // Verify bitmap data
            if (bitmapData == null || bitmapData.Scan0 == IntPtr.Zero)
            {
                LogError("Failed to lock bitmap data.");
                errorOccured = true;
            }

            if (!errorOccured)
            {
                try
                {
                    // Get the number of bytes per pixel
                    int bytesPerPixel = Image.GetPixelFormatSize(parentBitmap.PixelFormat) / 8;

                    // Get the address of the first line
                    IntPtr ptrFirstPixel = bitmapData.Scan0;

                    // Declare an array to hold the bytes of the bitmap
                    byte[] rgbValues = new byte[Math.Abs(bitmapData.Stride) * parentBitmap.Height];

                    // Copy the RGB values into the array
                    System.Runtime.InteropServices.Marshal.Copy(ptrFirstPixel, rgbValues, 0, rgbValues.Length);

                    // Iterate through the bitmap data
                    for (int y = 0; y < searchArea.Height; y++)
                    {
                        for (int x = 0; x < searchArea.Width; x++)
                        {
                            // Calculate the position of the current pixel in the byte array
                            int position = (y * bitmapData.Stride) + (x * bytesPerPixel);

                            // Extract the color components
                            Color pixelColor = Color.FromArgb(
                                rgbValues[position + 2], // Red
                                rgbValues[position + 1], // Green
                                rgbValues[position]);    // Blue

                            // Check if the pixel color matches any of the target colors within the tolerance
                            if (ColorMatchesAnyWithTolerance(pixelColor, targetColors, tolerance))
                            {
                                // Calculate the position relative to the parent bitmap
                                Point matchedPoint = new Point(searchArea.Left + x, searchArea.Top + y);
                                matches.Add(matchedPoint);
                            }
                        }
                    }
                }
                finally
                {
                    // Unlock the bitmap data
                    parentBitmap.UnlockBits(bitmapData);
                }
            }

            return matches;
        }

        // Function to check if a color matches any of the target colors within the tolerance
        private bool ColorMatchesAnyWithTolerance(Color color, List<Color> targetColors, int tolerance)
        {
            // Iterate through the target colors
            foreach (Color targetColor in targetColors)
            {
                // Calculate the difference in RGB values
                int deltaR = Math.Abs(color.R - targetColor.R);
                int deltaG = Math.Abs(color.G - targetColor.G);
                int deltaB = Math.Abs(color.B - targetColor.B);

                // Check if the color is within the tolerance range
                if (deltaR <= tolerance && deltaG <= tolerance && deltaB <= tolerance)
                {
                    return true;
                }
            }
            return false;
        }

        // Function to log errors
        private void LogError(string message)
        {
            // Log error message (implement logging mechanism here)
            Console.WriteLine("Error: " + message);
        }
    
        
    }

    internal class Filter_Bitmap
    {
        public Bitmap ProcessBitmap(Bitmap bitmap, List<Color> targetColors, int tolerance, Rectangle targetRegion)
        {
            // Verify arguments
            if (bitmap == null || targetColors == null || targetColors.Count == 0 || tolerance < 0 || targetRegion == Rectangle.Empty)
            {
                LogError("Invalid arguments: bitmap, targetColors, tolerance, or targetRegion is invalid.");
                return null;
            }

            // Create result bitmap
            Bitmap resultBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            // Lock source bitmap data
            BitmapData sourceData = LockBitmap(bitmap, targetRegion, ImageLockMode.ReadOnly);

            // Lock result bitmap data
            BitmapData resultData = LockBitmap(resultBitmap, targetRegion, ImageLockMode.WriteOnly);

            // Verify bitmap data
            if (sourceData == null || resultData == null)
            {
                LogError("Failed to lock bitmap data.");
                return null;
            }

            try
            {
                // Process bitmap data
                ProcessBitmapData(sourceData, resultData, targetColors, tolerance);
            }
            finally
            {
                // Unlock bitmap data
                UnlockBitmap(bitmap, sourceData);
                UnlockBitmap(resultBitmap, resultData);
            }

            return resultBitmap;
        }

        private void ProcessBitmapData(BitmapData sourceData, BitmapData resultData, List<Color> targetColors, int tolerance)
        {
            int bytesPerPixel = 4;
            int heightInPixels = sourceData.Height;
            int widthInBytes = sourceData.Width * bytesPerPixel;

            unsafe
            {
                byte* sourcePointer = (byte*)sourceData.Scan0;
                byte* resultPointer = (byte*)resultData.Scan0;

                for (int y = 0; y < heightInPixels; y++)
                {
                    for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                    {
                        int sourceIndex = y * sourceData.Stride + x;
                        int blue = sourcePointer[sourceIndex];
                        int green = sourcePointer[sourceIndex + 1];
                        int red = sourcePointer[sourceIndex + 2];
                        int alpha = sourcePointer[sourceIndex + 3];
                        Color pixelColor = Color.FromArgb(alpha, red, green, blue);

                        if (ColorMatchesAnyWithTolerance(pixelColor, targetColors, tolerance))
                        {
                            resultPointer[sourceIndex] = 255; // Set blue channel to 255
                            resultPointer[sourceIndex + 1] = 255; // Set green channel to 255
                            resultPointer[sourceIndex + 2] = 255; // Set red channel to 255
                            resultPointer[sourceIndex + 3] = 255; // Set alpha channel to 255
                        }
                        else
                        {
                            resultPointer[sourceIndex] = 0; // Set blue channel to 0
                            resultPointer[sourceIndex + 1] = 0; // Set green channel to 0
                            resultPointer[sourceIndex + 2] = 0; // Set red channel to 0
                            resultPointer[sourceIndex + 3] = 255; // Set alpha channel to 255
                        }
                    }
                }
            }
        }

        private bool ColorMatchesAnyWithTolerance(Color color, List<Color> targetColors, int tolerance)
        {
            // Iterate through the target colors
            foreach (Color targetColor in targetColors)
            {
                // Calculate the difference in RGB values
                int deltaR = Math.Abs(color.R - targetColor.R);
                int deltaG = Math.Abs(color.G - targetColor.G);
                int deltaB = Math.Abs(color.B - targetColor.B);

                // Check if the color is within the tolerance range
                if (deltaR <= tolerance && deltaG <= tolerance && deltaB <= tolerance)
                {
                    return true;
                }
            }
            return false;
        }

        private BitmapData LockBitmap(Bitmap bitmap, Rectangle targetRegion, ImageLockMode lockMode)
        {
            try
            {
                return bitmap.LockBits(targetRegion, lockMode, PixelFormat.Format32bppArgb);
            }
            catch (ArgumentException)
            {
                LogError("Failed to lock bitmap data.");
                return null;
            }
        }

        private void UnlockBitmap(Bitmap bitmap, BitmapData bitmapData)
        {
            try
            {
                bitmap.UnlockBits(bitmapData);
            }
            catch (ArgumentException)
            {
                LogError("Failed to unlock bitmap data.");
            }
        }

        private void LogError(string message)
        {
            // Log error message (implement logging mechanism here)
            Console.WriteLine("Error: " + message);
        }
    }
}

