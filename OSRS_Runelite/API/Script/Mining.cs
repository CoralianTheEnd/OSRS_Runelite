using OSRS_Runelite.API.Helper;
using OSRS_Runelite.API.Wrappers.Ids;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Runelite.API.Script
{
    internal class Mining : AbstractScript
    {
        public Mining()
        {
            this.Author = "Coralian";
            this.Description = "Mining Script";
            this.Name = "This is a mining script";
        }

        public enum STATE
        {
            WALKING,
            MINING,
            DROP,
            IDLE,
            UNKNOW
        }

        public STATE GetState()
        {
            if (this.PlayerContainer.PoseAnimationId != PoseAnimations.IDLE)
            {
                Logger.Info("STATE: Walking");
                return STATE.WALKING;

            } else if (this.PlayerContainer.AnimationId == Animations.MINING)
            {
                Logger.Info("STATE: Mining");
                return STATE.MINING;
            }
            else if (this.InventoryContainer.IsFull())
            {
                Logger.Info("STATE: Dropping");
                return STATE.DROP;
            } else if (this.PlayerContainer.AnimationId == Animations.IDLE) 
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
                            Thread.Sleep(2000);
                        }

                        Thread.Sleep(2000);
                        break;
                    case STATE.MINING:
                        while (PlayerContainer.AnimationId == Animations.MINING)
                        {
                            Thread.Sleep(1000);
                        }
                        break;
                    case STATE.DROP:
                        foreach (var item in this.InventoryContainer.FindItemsById(
                            Items.IRON_ORE, 
                            Items.UNCUT_SAPPHIRE, 
                            Items.UNCUT_EMERALD, 
                            Items.UNCUT_RUBY, 
                            Items.UNCUT_DIAMOND))
                        {
                            item.Drop();
                        }
                        break;
                    case STATE.IDLE:
                        var WILLOW_TREE = this.GameObjectsContainer.FindClosestGameObjectByIds(
                            GameObjects.IRON_ROCK_0, 
                            GameObjects.IRON_ROCK_1);
                        if (WILLOW_TREE == null)
                        {
                            Logger.Error("No iron rocks available.");
                            break;
                        }

                        if (!WILLOW_TREE.LeftClickMiddle())
                        {
                            Logger.Error("failed to click rock.");
                            break;
                        }

                        Thread.Sleep(3000);
                        break;
                    case STATE.UNKNOW:
                        break;
                    default:
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
