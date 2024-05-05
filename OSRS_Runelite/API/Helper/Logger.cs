using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Helper
{
    public class Logger
    {
        #region Public facing methods

        public static void Okay(string msg)
        {
            Log_Okay(msg);
        }

        public static void Info(string msg)
        {
            Log_Info(msg);
        }

        public static void Error(string msg)
        {
            Log_Error(msg);
        }

        #endregion

        // # Filter and flush messages
        #region Private methods

        private static void Log_Okay(string msg)
        {
            Console.WriteLine($"{DateTime.Now} [+] {msg}");
        }

        private static void Log_Info(string msg)
        {
            Console.WriteLine($"{DateTime.Now} [*] {msg}");
        }

        private static void Log_Error(string msg)
        {
            Console.WriteLine($"{DateTime.Now} [!] {msg}");
        }

        #endregion

    }
}
