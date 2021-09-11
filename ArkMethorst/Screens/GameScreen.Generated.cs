#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
namespace ArkMethorst.Screens
{
    public partial class GameScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static ArkMethorst.GumRuntimes.GameScreenGumRuntime GameScreenGum;
        
        protected FlatRedBall.TileGraphics.LayeredTileMap Map;
        protected FlatRedBall.TileCollisions.TileShapeCollection SolidCollision;
        protected FlatRedBall.TileCollisions.TileShapeCollection CloudCollision;
        private FlatRedBall.Math.PositionedObjectList<ArkMethorst.Entities.Player> PlayerList;
        private ArkMethorst.Entities.Player Player1;
        private FlatRedBall.Math.Collision.DelegateListVsSingleRelationship<Entities.Player, FlatRedBall.TileCollisions.TileShapeCollection> PlayerListVsSolidCollision;
        private FlatRedBall.Math.Collision.DelegateListVsSingleRelationship<Entities.Player, FlatRedBall.TileCollisions.TileShapeCollection> PlayerListVsCloudCollision;
        private FlatRedBall.Entities.CameraControllingEntity CameraControllingEntityInstance;
        private FlatRedBall.Math.Geometry.ShapeCollection PitCollision;
        private FlatRedBall.Math.Collision.ListVsShapeCollectionRelationship<Entities.Player> PlayerListVsPitCollision;
        private FlatRedBall.Math.PositionedObjectList<ArkMethorst.Entities.Checkpoint> CheckpointList;
        private FlatRedBall.Math.Collision.ListVsListRelationship<Entities.Player, Entities.Checkpoint> PlayerListVsCheckpointList;
        private FlatRedBall.Math.PositionedObjectList<ArkMethorst.Entities.EndOfLevel> EndOfLevelList;
        private FlatRedBall.Math.Collision.ListVsListRelationship<Entities.Player, Entities.EndOfLevel> PlayerListVsEndOfLevelList;
        public event System.Action<Entities.Player, FlatRedBall.Math.Geometry.ShapeCollection> PlayerListVsPitCollisionCollisionOccurred;
        public event System.Action<Entities.Player, Entities.Checkpoint> PlayerListVsCheckpointListCollisionOccurred;
        public event System.Action<Entities.Player, Entities.EndOfLevel> PlayerListVsEndOfLevelListCollisionOccurred;
        ArkMethorst.FormsControls.Screens.GameScreenGumForms Forms;
        public GameScreen () 
        	: base ("GameScreen")
        {
            // Not instantiating for FlatRedBall.TileGraphics.LayeredTileMap Map in Screens\GameScreen (Screen) because properties on the object prevent it
            // Not instantiating for FlatRedBall.TileCollisions.TileShapeCollection SolidCollision in Screens\GameScreen (Screen) because properties on the object prevent it
            // Not instantiating for FlatRedBall.TileCollisions.TileShapeCollection CloudCollision in Screens\GameScreen (Screen) because properties on the object prevent it
            PlayerList = new FlatRedBall.Math.PositionedObjectList<ArkMethorst.Entities.Player>();
            PlayerList.Name = "PlayerList";
            CheckpointList = new FlatRedBall.Math.PositionedObjectList<ArkMethorst.Entities.Checkpoint>();
            CheckpointList.Name = "CheckpointList";
            EndOfLevelList = new FlatRedBall.Math.PositionedObjectList<ArkMethorst.Entities.EndOfLevel>();
            EndOfLevelList.Name = "EndOfLevelList";
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            // Not instantiating for FlatRedBall.TileGraphics.LayeredTileMap Map in Screens\GameScreen (Screen) because properties on the object prevent it
            // Not instantiating for FlatRedBall.TileCollisions.TileShapeCollection SolidCollision in Screens\GameScreen (Screen) because properties on the object prevent it
            // Not instantiating for FlatRedBall.TileCollisions.TileShapeCollection CloudCollision in Screens\GameScreen (Screen) because properties on the object prevent it
            PlayerList.Clear();
            Player1 = new ArkMethorst.Entities.Player(ContentManagerName, false);
            Player1.Name = "Player1";
            CameraControllingEntityInstance = new FlatRedBall.Entities.CameraControllingEntity();
            CameraControllingEntityInstance.Name = "CameraControllingEntityInstance";
            PitCollision = new FlatRedBall.Math.Geometry.ShapeCollection();
            PitCollision.Name = "PitCollision";
            CheckpointList.Clear();
            EndOfLevelList.Clear();
                {
        var temp = new FlatRedBall.Math.Collision.DelegateListVsSingleRelationship<Entities.Player, FlatRedBall.TileCollisions.TileShapeCollection>(PlayerList, SolidCollision);
        var isCloud = false;
        temp.CollisionFunction = (first, second) =>
        {
            return first.CollideAgainst(second, isCloud);
        }
        ;
        FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Add(temp);
        PlayerListVsSolidCollision = temp;
    }
    PlayerListVsSolidCollision.Name = "PlayerListVsSolidCollision";

                {
        var temp = new FlatRedBall.Math.Collision.DelegateListVsSingleRelationship<Entities.Player, FlatRedBall.TileCollisions.TileShapeCollection>(PlayerList, CloudCollision);
        var isCloud = true;
        temp.CollisionFunction = (first, second) =>
        {
            return first.CollideAgainst(second, isCloud);
        }
        ;
        FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Add(temp);
        PlayerListVsCloudCollision = temp;
    }
    PlayerListVsCloudCollision.Name = "PlayerListVsCloudCollision";

                PlayerListVsPitCollision = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(PlayerList, PitCollision);
    PlayerListVsPitCollision.Name = "PlayerListVsPitCollision";

                PlayerListVsCheckpointList = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(PlayerList, CheckpointList);
    PlayerListVsCheckpointList.CollisionLimit = FlatRedBall.Math.Collision.CollisionLimit.All;
    PlayerListVsCheckpointList.ListVsListLoopingMode = FlatRedBall.Math.Collision.ListVsListLoopingMode.PreventDoubleChecksPerFrame;
    PlayerListVsCheckpointList.Name = "PlayerListVsCheckpointList";

                PlayerListVsEndOfLevelList = FlatRedBall.Math.Collision.CollisionManager.Self.CreateRelationship(PlayerList, EndOfLevelList);
    PlayerListVsEndOfLevelList.CollisionLimit = FlatRedBall.Math.Collision.CollisionLimit.All;
    PlayerListVsEndOfLevelList.ListVsListLoopingMode = FlatRedBall.Math.Collision.ListVsListLoopingMode.PreventDoubleChecksPerFrame;
    PlayerListVsEndOfLevelList.Name = "PlayerListVsEndOfLevelList";

            Forms = new ArkMethorst.FormsControls.Screens.GameScreenGumForms(GameScreenGum);
            // normally we wait to set variables until after the object is created, but in this case if the
            // TileShapeCollection doesn't have its Visible set before creating the tiles, it can result in
            // really bad performance issues, as shapes will be made visible, then invisible. Really bad perf!
            if (SolidCollision != null)
            {
                SolidCollision.Visible = false;
            }
            FlatRedBall.TileCollisions.TileShapeCollectionLayeredTileMapExtensions.AddCollisionFromTilesWithType(SolidCollision, Map, "SolidCollision", false);
            // normally we wait to set variables until after the object is created, but in this case if the
            // TileShapeCollection doesn't have its Visible set before creating the tiles, it can result in
            // really bad performance issues, as shapes will be made visible, then invisible. Really bad perf!
            if (CloudCollision != null)
            {
                CloudCollision.Visible = false;
            }
            FlatRedBall.TileCollisions.TileShapeCollectionLayeredTileMapExtensions.AddCollisionFromTilesWithType(CloudCollision, Map, "CloudCollision", false);
            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            GameScreenGum.AddToManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += RefreshLayoutInternal;
            Factories.PlayerFactory.Initialize(ContentManagerName);
            Factories.CheckpointFactory.Initialize(ContentManagerName);
            Factories.EndOfLevelFactory.Initialize(ContentManagerName);
            Factories.PlayerFactory.AddList(PlayerList);
            Factories.CheckpointFactory.AddList(CheckpointList);
            Factories.EndOfLevelFactory.AddList(EndOfLevelList);
            Player1.AddToManagers(mLayer);
            FlatRedBall.SpriteManager.AddPositionedObject(CameraControllingEntityInstance); CameraControllingEntityInstance.Activity();
            PitCollision.AddToManagers();
            FlatRedBall.TileEntities.TileEntityInstantiator.CreateEntitiesFrom(Map);
            base.AddToManagers();
            AddToManagersBottomUp();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                for (int i = PlayerList.Count - 1; i > -1; i--)
                {
                    if (i < PlayerList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        PlayerList[i].Activity();
                    }
                }
                CameraControllingEntityInstance.Activity();
                for (int i = CheckpointList.Count - 1; i > -1; i--)
                {
                    if (i < CheckpointList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        CheckpointList[i].Activity();
                    }
                }
                for (int i = EndOfLevelList.Count - 1; i > -1; i--)
                {
                    if (i < EndOfLevelList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        EndOfLevelList[i].Activity();
                    }
                }
            }
            else
            {
            }
            base.Activity(firstTimeCalled);
            if (!IsActivityFinished)
            {
                CustomActivity(firstTimeCalled);
            }
        }
        public override void Destroy () 
        {
            base.Destroy();
            Factories.PlayerFactory.Destroy();
            Factories.CheckpointFactory.Destroy();
            Factories.EndOfLevelFactory.Destroy();
            GameScreenGum.RemoveFromManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged -= RefreshLayoutInternal;
            GameScreenGum = null;
            
            PlayerList.MakeOneWay();
            CheckpointList.MakeOneWay();
            EndOfLevelList.MakeOneWay();
            for (int i = PlayerList.Count - 1; i > -1; i--)
            {
                PlayerList[i].Destroy();
            }
            if (CameraControllingEntityInstance != null)
            {
                FlatRedBall.SpriteManager.RemovePositionedObject(CameraControllingEntityInstance);;
            }
            if (PitCollision != null)
            {
                PitCollision.RemoveFromManagers(ContentManagerName != "Global");
            }
            for (int i = CheckpointList.Count - 1; i > -1; i--)
            {
                CheckpointList[i].Destroy();
            }
            for (int i = EndOfLevelList.Count - 1; i > -1; i--)
            {
                EndOfLevelList[i].Destroy();
            }
            PlayerList.MakeTwoWay();
            CheckpointList.MakeTwoWay();
            EndOfLevelList.MakeTwoWay();
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            PlayerListVsPitCollision.CollisionOccurred += OnPlayerListVsPitCollisionCollisionOccurred;
            PlayerListVsPitCollision.CollisionOccurred += OnPlayerListVsPitCollisionCollisionOccurredTunnel;
            PlayerListVsCheckpointList.CollisionOccurred += OnPlayerListVsCheckpointListCollisionOccurred;
            PlayerListVsCheckpointList.CollisionOccurred += OnPlayerListVsCheckpointListCollisionOccurredTunnel;
            PlayerListVsEndOfLevelList.CollisionOccurred += OnPlayerListVsEndOfLevelListCollisionOccurred;
            PlayerListVsEndOfLevelList.CollisionOccurred += OnPlayerListVsEndOfLevelListCollisionOccurredTunnel;
            if (Map!= null)
            {
                if (Map.Parent == null)
                {
                    Map.Z = -3f;
                }
                else
                {
                    Map.RelativeZ = -3f;
                }
            }
            if (SolidCollision!= null)
            {
            }
            if (CloudCollision!= null)
            {
            }
            PlayerList.Add(Player1);
            CameraControllingEntityInstance.Targets = PlayerList;
            CameraControllingEntityInstance.Map = Map;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp () 
        {
            CameraSetup.ResetCamera(SpriteManager.Camera);
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            GameScreenGum.RemoveFromManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged -= RefreshLayoutInternal;
            for (int i = PlayerList.Count - 1; i > -1; i--)
            {
                PlayerList[i].Destroy();
            }
            if (CameraControllingEntityInstance != null)
            {
                FlatRedBall.SpriteManager.RemovePositionedObject(CameraControllingEntityInstance);;
            }
            if (PitCollision != null)
            {
                PitCollision.RemoveFromManagers(false);
            }
            for (int i = CheckpointList.Count - 1; i > -1; i--)
            {
                CheckpointList[i].Destroy();
            }
            for (int i = EndOfLevelList.Count - 1; i > -1; i--)
            {
                EndOfLevelList[i].Destroy();
            }
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
                Player1.AssignCustomVariables(true);
            }
            if (Map != null)
            {
                if (Map.Parent == null)
                {
                    Map.Z = -3f;
                }
                else
                {
                    Map.RelativeZ = -3f;
                }
            }
            if (SolidCollision != null)
            {
            }
            if (CloudCollision != null)
            {
            }
            CameraControllingEntityInstance.Targets = PlayerList;
            CameraControllingEntityInstance.Map = Map;
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            if (Map != null)
            {
            }
            if (SolidCollision != null)
            {
            }
            if (CloudCollision != null)
            {
            }
            for (int i = 0; i < PlayerList.Count; i++)
            {
                PlayerList[i].ConvertToManuallyUpdated();
            }
            for (int i = 0; i < CheckpointList.Count; i++)
            {
                CheckpointList[i].ConvertToManuallyUpdated();
            }
            for (int i = 0; i < EndOfLevelList.Count; i++)
            {
                EndOfLevelList[i].ConvertToManuallyUpdated();
            }
        }
        public static void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            // Set the content manager for Gum
            var contentManagerWrapper = new FlatRedBall.Gum.ContentManagerWrapper();
            contentManagerWrapper.ContentManagerName = contentManagerName;
            RenderingLibrary.Content.LoaderManager.Self.ContentLoader = contentManagerWrapper;
            // Access the GumProject just in case it's async loaded
            var throwaway = GlobalContent.GumProject;
            #if DEBUG
            if (contentManagerName == FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                HasBeenLoadedWithGlobalContentManager = true;
            }
            else if (HasBeenLoadedWithGlobalContentManager)
            {
                throw new System.Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
            }
            #endif
            if(GameScreenGum == null) GameScreenGum = (ArkMethorst.GumRuntimes.GameScreenGumRuntime)GumRuntime.ElementSaveExtensions.CreateGueForElement(Gum.Managers.ObjectFinder.Self.GetScreen("GameScreenGum"), true);
            CustomLoadStaticContent(contentManagerName);
        }
        public override void PauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Pause();
            base.PauseThisScreen();
        }
        public override void UnpauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Unpause();
            base.UnpauseThisScreen();
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "GameScreenGum":
                    return GameScreenGum;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "GameScreenGum":
                    return GameScreenGum;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "GameScreenGum":
                    return GameScreenGum;
            }
            return null;
        }
        private void RefreshLayoutInternal (object sender, EventArgs e) 
        {
            GameScreenGum.UpdateLayout();
        }
    }
}
