using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Wrappers.GameData
{
    public class DynamicLocalPlayer
    {
        public int CombatLevel =>
            Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/CombatLevel");

        public string OverheadIcon => 
            Web.RequestData.ConvertStandardClientData<string>("/LocalPlayer/CombatLevel");

        public string SkullIcon => 
            Web.RequestData.ConvertStandardClientData<string>("/LocalPlayer/SkullIcon");

        public bool IsInteracting => 
            Web.RequestData.ConvertStandardClientData<bool>("/LocalPlayer/SkullIcon");

        public string IsInteractingName => 
            Web.RequestData.ConvertStandardClientData<string>("/LocalPlayer/IsInteractingName");

        public string OverheadText => 
            Web.RequestData.ConvertStandardClientData<string>("/LocalPlayer/OverheadText");

        public bool IsDead => 
            Web.RequestData.ConvertStandardClientData<bool>("/LocalPlayer/OverheadText");

        public int AnimationId => 
            Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/AnimationId");

        public int PoseAnimationId =>
            Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/PoseAnimationId");

        public int RunEnergy => 
            Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/RunEnergy");

        public int HealthCurrent => 
            Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/HealthCurrent");

        public int HealthMax =>
            Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/HealthMax");

        public int PrayerCurrent => 
            Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/PrayerCurrent");

        public int PrayerMax => 
            Web.RequestData.ConvertStandardClientData<int>("/LocalPlayer/PrayerMax");

        public WorldPoint WorldPoint =>
            Web.RequestData.ConvertJsonClientData<WorldPoint>("/LocalPlayer/WorldPoint");// /LocalPlayer/WorldPoint
    }
}
