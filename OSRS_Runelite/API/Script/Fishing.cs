using OSRS_Runelite.API.Helper;
using OSRS_Runelite.API.Methods.Interactives;
using OSRS_Runelite.API.Wrappers.Ids;

namespace OSRS_Runelite.API.Script
{
    internal class Fishing : AbstractScript
    {
        public Fishing() 
        {
            this.Author = "Coralian";
            this.Description = "Fishing Script";
            this.Name = "This is a fishing script";
        }

        public enum STATE
        {
            WALKING,
            FISHING,
            DROP,
            IDLE,
            UNKNOW
        }

        public STATE GetState()
        {
            Thread.Sleep(10);

            if (this.PlayerContainer.PoseAnimationId != PoseAnimations.IDLE)
            {
                Logger.Info("STATE: Walking");
                return STATE.WALKING;

            }
            else if (this.PlayerContainer.AnimationId == Animations.FLY_FISHING ||
                     this.PlayerContainer.AnimationId == Animations.CASTING_ROD)
            {
                Logger.Info("STATE: Fishing");
                return STATE.FISHING;
            }
            else if (this.InventoryContainer.IsFull())
            {
                Logger.Info("STATE: Dropping");
                return STATE.DROP;
            }
            else if (this.PlayerContainer.AnimationId == Animations.IDLE)
            {
                Logger.Info("STATE: Idle");
                return STATE.IDLE;
            }

            Logger.Info("Unknown");
            return STATE.UNKNOW;
        }

        public override void OnRun()
        {
            base.OnRun();

            while (this.ShouldContinue())
            {

                switch (GetState())
                {
                    case STATE.WALKING:
                        while (this.PlayerContainer.PoseAnimationId != PoseAnimations.IDLE)
                        {
                            Thread.Sleep(100);
                        }

                        Thread.Sleep(600);
                        break;
                    case STATE.FISHING:
                        while (PlayerContainer.AnimationId == Animations.FLY_FISHING || 
                               PlayerContainer.AnimationId == Animations.CASTING_ROD)
                        {
                            Thread.Sleep(600);
                        }
                        break;
                    case STATE.DROP:
                        foreach (var item in this.InventoryContainer.FindItemsById(
                            Items.RAW_SALMON,
                            Items.RAW_TROUT))
                        {
                            item.Drop();
                        }
                        break;
                    case STATE.IDLE:
                        var FishingRodSpot = Npcs.GetClosest(NpcNames.ROD_FISHING_SPOT_0);

                        if (FishingRodSpot == null)
                        {
                            Logger.Error("Fishing Spots are empty.");
                            break;
                        }

                        if (!FishingRodSpot.LeftClick())
                        {
                            Logger.Error("failed to click rock.");
                            break;
                        }

                        Thread.Sleep(600);
                        break;
                    case STATE.UNKNOW:
                        break;
                }
            }
        }

        public override void OnStartUp()
        {
            base.OnStartUp();
        }

        public override void OnStop()
        {
            base.OnStop();
        }
    }
}
