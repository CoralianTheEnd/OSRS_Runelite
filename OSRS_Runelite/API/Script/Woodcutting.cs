using OSRS_Runelite.API.Helper;
using OSRS_Runelite.API.Wrappers.Ids;

namespace OSRS_Runelite.API.Script
{
    public class Woodcutting : AbstractScript
    {
        public Woodcutting()
        {
            this.Author = "Coralian";
            this.Description = "Automatic willow chopper & experimental Script.";
            this.Name = "This is a woodcutting script.";
        }

        public enum STATE
        {
            WALKING,
            WOODCUTTING,
            NEED_TO_DROP,
            IDLE,
            UNKNOWN
        }
       
        public STATE GetState()
        {
            if (this.PlayerContainer.PoseAnimationId != 808)
            {
                Logger.Info("STATE: Walking");
                return STATE.WALKING;
            } 
            else if (this.PlayerContainer.AnimationId == Animations.WOODCUTTING)
            {
                Logger.Info("STATE: Woodcutting");
                return STATE.WOODCUTTING;
            }
            else if (InventoryContainer.IsFull()) // #(this.InventoryContainer.FindItemsById(Items.WILLOW_LOG).Count > 0)
            {
                Logger.Info("STATE: Dropping");
                return STATE.NEED_TO_DROP;
            }
            else if (this.PlayerContainer.AnimationId == Animations.IDLE)
            {
                Logger.Info("STATE: Idle");
                return STATE.IDLE;
            }

            Logger.Info("STATE: Unknown");
            return STATE.UNKNOWN;
        }

        public override void OnRun()
        {
            base.OnRun();

            while (this.ShouldContinue())
            {

                switch (GetState())
                {
                    case STATE.WALKING:
                        while (this.PlayerContainer.PoseAnimationId != 808)
                        {
                            Thread.Sleep(1000);
                        }

                        Thread.Sleep(2000);

                        break;
                    case STATE.WOODCUTTING:
                        while (PlayerContainer.AnimationId == Animations.WOODCUTTING)
                        {
                            Thread.Sleep(1000);
                        }
                        break;
                    case STATE.NEED_TO_DROP:
                        foreach (var item in this.InventoryContainer.FindItemsById(Items.WILLOW_LOG))
                        {
                             item.Drop();
                        }
                        break;
                    case STATE.IDLE:
                        var WILLOW_TREE = this.GameObjectsContainer.GetFirstOnScreen(GameObjects.WILLOW_TREE_0, GameObjects.WILLOW_TREE_1);
                        if (WILLOW_TREE == null)
                        {
                            Logger.Error("Willow tree's are null.");
                            break;
                        }

                        if (!WILLOW_TREE.LeftClickMiddle())
                        {
                            Logger.Error("failed to click willow.");
                            break;
                        }

                        Thread.Sleep(2000);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
