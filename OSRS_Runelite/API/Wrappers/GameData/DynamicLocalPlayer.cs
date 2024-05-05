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
                return Web.RequestData.RequestClientData<int>("/LocalPlayer/CombatLevel");
            }
        }

        public string OverheadIcon
        {
            get
            {
                
                return Web.RequestData.RequestClientData<string>("/LocalPlayer/CombatLevel");
            }
        }

        public string SkullIcon
        {
            get
            {
                // # http://localhost:8080/LocalPlayer/CombatLevel
                return Web.RequestData.RequestClientData<string>("/LocalPlayer/SkullIcon");
            }
        }

        public bool IsInteracting
        {
            get
            {
                // # http://localhost:8080/LocalPlayer/CombatLevel
                return Web.RequestData.RequestClientData<bool>("/LocalPlayer/SkullIcon");
            }
        }

        public string IsInteractingName
        {
            get
            {
                // # http://localhost:8080/LocalPlayer/CombatLevel
                return Web.RequestData.RequestClientData<string>("/LocalPlayer/IsInteractingName");
            }
        }

        public string OverheadText
        {
            get
            {
                // # http://localhost:8080/LocalPlayer/CombatLevel
                return Web.RequestData.RequestClientData<string>("/LocalPlayer/OverheadText");
            }
        }

        public bool IsDead
        {
            get
            {
                // # http://localhost:8080/LocalPlayer/CombatLevel
                return Web.RequestData.RequestClientData<bool>("/LocalPlayer/OverheadText");
            }
        }

        public int AnimationId
        {
            get
            {
                // # http://localhost:8080/LocalPlayer/CombatLevel
                return Web.RequestData.RequestClientData<int>("/LocalPlayer/AnimationId");
            }
        }

        public int PoseAnimationId
        {
            get
            {
                // # http://localhost:8080/LocalPlayer/CombatLevel
                return Web.RequestData.RequestClientData<int>("/LocalPlayer/PoseAnimationId");
            }
        }

        public int RunEnergy
        {
            get
            {
                // # http://localhost:8080/LocalPlayer/CombatLevel
                return Web.RequestData.RequestClientData<int>("/LocalPlayer/RunEnergy");
            }
        }

        public int HealthCurrent
        {
            get
            {
                // # http://localhost:8080/LocalPlayer/CombatLevel
                return Web.RequestData.RequestClientData<int>("/LocalPlayer/HealthCurrent");
            }
        }

        public int HealthMax
        {
            get
            {
                // # http://localhost:8080/LocalPlayer/CombatLevel
                return Web.RequestData.RequestClientData<int>("/LocalPlayer/HealthMax");
            }
        }

        public int PrayerCurrent
        {
            get
            {
                // # http://localhost:8080/LocalPlayer/CombatLevel
                return Web.RequestData.RequestClientData<int>("/LocalPlayer/PrayerCurrent");
            }
        }

        public int PrayerMax
        {
            get
            {
                // # http://localhost:8080/LocalPlayer/CombatLevel
                return Web.RequestData.RequestClientData<int>("/LocalPlayer/PrayerMax");
            }
        }
    }
}
