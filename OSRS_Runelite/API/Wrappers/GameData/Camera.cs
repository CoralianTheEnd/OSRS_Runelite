using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Wrappers.GameData
{
    internal class DynamicCamera
    {
        public int Yaw => 
            Web.RequestData.ConvertStandardClientData<int>("/Camera/Yaw");


        public int Pitch => 
            Web.RequestData.ConvertStandardClientData<int>("/Camera/Pitch");


        public int Zoom => 
            Web.RequestData.ConvertStandardClientData<int>("/Camera/Zoom");


        public int X => 
            Web.RequestData.ConvertStandardClientData<int>("/Camera/X");


        public int Y =>
            Web.RequestData.ConvertStandardClientData<int>("/Camera/Y");


        public int Z => 
            Web.RequestData.ConvertStandardClientData<int>("/Camera/Z");


        public int X2 => 
            Web.RequestData.ConvertStandardClientData<int>("/Camera/X2");


        public int Y2 => 
            Web.RequestData.ConvertStandardClientData<int>("/Camera/Y2");


        public int Z2 => 
            Web.RequestData.ConvertStandardClientData<int>("/Camera/Z2");

    }
}
