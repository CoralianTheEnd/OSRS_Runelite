using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Wrappers.GameData
{
    public class DynamicLocalPlayer
    {
        public int CombatLevel
        {
            get
            {            
                return Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/CombatLevel");
            }
        }

        public string OverheadIcon
        {
            get
            {             
                return Web.RequestData.ConvertStandardClientData<string>("/LocalPlayer/CombatLevel");
            }
        }

        public string SkullIcon
        {
            get
            {             
                return Web.RequestData.ConvertStandardClientData<string>("/LocalPlayer/SkullIcon");
            }
        }

        public bool IsInteracting
        {
            get
            {               
                return Web.RequestData.ConvertStandardClientData<bool>("/LocalPlayer/SkullIcon");
            }
        }

        public string IsInteractingName
        {
            get
            {           
                return Web.RequestData.ConvertStandardClientData<string>("/LocalPlayer/IsInteractingName");
            }
        }

        public string OverheadText
        {
            get
            {
                return Web.RequestData.ConvertStandardClientData<string>("/LocalPlayer/OverheadText");
            }
        }

        public bool IsDead
        {
            get
            {
                return Web.RequestData.ConvertStandardClientData<bool>("/LocalPlayer/OverheadText");
            }
        }

        public int AnimationId
        {
            get
            {
                return Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/AnimationId");
            }
        }

        public int PoseAnimationId
        {
            get
            {
                return Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/PoseAnimationId");
            }
        }

        public int RunEnergy
        {
            get
            {
                return Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/RunEnergy");
            }
        }

        public int HealthCurrent
        {
            get
            { 
                return Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/HealthCurrent");
            }
        }

        public int HealthMax
        {
            get
            {
                return Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/HealthMax");
            }
        }

        public int PrayerCurrent
        {
            get
            {
                return Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/PrayerCurrent");
            }
        }

        public int PrayerMax
        {
            get
            { 
                return Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/PrayerMax");
            }
        }
    }
}
