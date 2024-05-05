using OSRS_Runelite.API.Wrappers.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSRS_Runelite.API.Helper;

namespace OSRS_Runelite.API.Script
{
    public class AbstractScript
    {
        public string Author;
        public string Description;
        public string Name;

        public DynamicLocalPlayer PlayerContainer;
        public GameObjectContainer GameObjectsContainer;
        public InventoryContainer InventoryContainer;

        protected CancellationTokenSource cancellationTokenSource;
        protected CancellationToken cancellationToken;

        public AbstractScript()
        {
            PlayerContainer = new DynamicLocalPlayer();
            GameObjectsContainer = new GameObjectContainer();
            InventoryContainer = new InventoryContainer();

            cancellationTokenSource = new CancellationTokenSource();
        }

        public virtual void OnStartUp()
        {
            Logger.Okay($"Loading script: {this.Name} by {this.Author}");
            Logger.Okay($"{this.Description}");
            Logger.Okay($"Starting script: {this.Name}"); 
        }

        public virtual void OnRun()
        {
            Logger.Okay($"Starting script: {this.Name} by {this.Author}");
            Logger.Okay($"{this.Description}");
        }

        public virtual void OnStop()
        {
            Logger.Okay($"Stopping script: {this.Name}");  
        }

        public void Start()
        {
            Task.Run(() => OnRun(), cancellationToken);
        }

        public void Stop()
        {
            cancellationTokenSource.Cancel();
            OnStop();
        }
     
        protected bool ShouldContinue()
        {
            return !cancellationTokenSource.IsCancellationRequested;
        }

    }
}
