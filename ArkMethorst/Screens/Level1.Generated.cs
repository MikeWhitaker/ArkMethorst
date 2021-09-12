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
    public partial class Level1 : GameScreen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static ArkMethorst.GumRuntimes.Level1GumRuntime Level1Gum;
        protected static FlatRedBall.TileGraphics.LayeredTileMap Level1Map;
        
        private FlatRedBall.Math.Collision.DelegateCollisionRelationship<ArkMethorst.Entities.Piglet, FlatRedBall.TileCollisions.TileShapeCollection> PigletInstanceVsSolidCollision;
        private ArkMethorst.Entities.Piglet PigletInstance;
        public event System.Action<ArkMethorst.Entities.Piglet, FlatRedBall.TileCollisions.TileShapeCollection> PigletInstanceVsSolidCollisionCollisionOccurred;
        ArkMethorst.FormsControls.Screens.Level1GumForms Forms;
        public Level1 () 
        	: base ()
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            Map = Level1Map;
            SolidCollision = new FlatRedBall.TileCollisions.TileShapeCollection();
            CloudCollision = new FlatRedBall.TileCollisions.TileShapeCollection();
            PigletInstance = new ArkMethorst.Entities.Piglet(ContentManagerName, false);
            PigletInstance.Name = "PigletInstance";
                {
        var temp = new FlatRedBall.Math.Collision.DelegateCollisionRelationship<ArkMethorst.Entities.Piglet, FlatRedBall.TileCollisions.TileShapeCollection>(PigletInstance, SolidCollision);
        var isCloud = false;
        temp.CollisionFunction = (first, second) =>
        {
            return first.CollideAgainst(second, isCloud);
        }
        ;
        FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Add(temp);
        PigletInstanceVsSolidCollision = temp;
    }
    PigletInstanceVsSolidCollision.Name = "PigletInstanceVsSolidCollision";

            Forms = new ArkMethorst.FormsControls.Screens.Level1GumForms(Level1Gum);
            
            
            base.Initialize(addToManagers);
        }
        public override void AddToManagers () 
        {
            Level1Gum.AddToManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += RefreshLayoutInternal;
            Level1Map.AddToManagers(mLayer);
            PigletInstance.AddToManagers(mLayer);
            base.AddToManagers();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                Level1Map?.AnimateSelf();;
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
            Level1Gum.RemoveFromManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged -= RefreshLayoutInternal;
            Level1Gum = null;
            Level1Map.Destroy();
            Level1Map = null;
            
            PigletList.MakeOneWay();
            if (Map != null)
            {
                Map.Destroy();
            }
            if (SolidCollision != null)
            {
                SolidCollision.Visible = false;
            }
            if (CloudCollision != null)
            {
                CloudCollision.Visible = false;
            }
            PigletList.MakeTwoWay();
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public override void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            PigletInstanceVsSolidCollision.CollisionOccurred += OnPigletInstanceVsSolidCollisionCollisionOccurred;
            PigletInstanceVsSolidCollision.CollisionOccurred += OnPigletInstanceVsSolidCollisionCollisionOccurredTunnel;
            base.PostInitialize();
            PigletList.Add(PigletInstance);
            PigletInstance.GroundMovement = Entities.Piglet.PlatformerValuesStatic["Ground"];
            if (PigletInstance.Parent == null)
            {
                PigletInstance.X = 160f;
            }
            else
            {
                PigletInstance.RelativeX = 160f;
            }
            if (PigletInstance.Parent == null)
            {
                PigletInstance.Y = -160f;
            }
            else
            {
                PigletInstance.RelativeY = -160f;
            }
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public override void AddToManagersBottomUp () 
        {
            base.AddToManagersBottomUp();
        }
        public override void RemoveFromManagers () 
        {
            base.RemoveFromManagers();
            Level1Gum.RemoveFromManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged -= RefreshLayoutInternal;
            Level1Map.Destroy();
            if (Map != null)
            {
                Map.Destroy();
            }
            if (SolidCollision != null)
            {
                SolidCollision.Visible = false;
            }
            if (CloudCollision != null)
            {
                CloudCollision.Visible = false;
            }
        }
        public override void AssignCustomVariables (bool callOnContainedElements) 
        {
            base.AssignCustomVariables(callOnContainedElements);
            if (callOnContainedElements)
            {
                PigletInstance.AssignCustomVariables(true);
            }
            PigletInstance.GroundMovement = Entities.Piglet.PlatformerValuesStatic["Ground"];
            if (PigletInstance.Parent == null)
            {
                PigletInstance.X = 160f;
            }
            else
            {
                PigletInstance.RelativeX = 160f;
            }
            if (PigletInstance.Parent == null)
            {
                PigletInstance.Y = -160f;
            }
            else
            {
                PigletInstance.RelativeY = -160f;
            }
        }
        public override void ConvertToManuallyUpdated () 
        {
            base.ConvertToManuallyUpdated();
        }
        public static new void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            ArkMethorst.Screens.GameScreen.LoadStaticContent(contentManagerName);
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
            if(Level1Gum == null) Level1Gum = (ArkMethorst.GumRuntimes.Level1GumRuntime)GumRuntime.ElementSaveExtensions.CreateGueForElement(Gum.Managers.ObjectFinder.Self.GetScreen("Level1Gum"), true);
            Level1Map = FlatRedBall.TileGraphics.LayeredTileMap.FromTiledMapSave("content/screens/level1/level1map.tmx", contentManagerName);
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
        public static new object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "Level1Gum":
                    return Level1Gum;
                case  "Level1Map":
                    return Level1Map;
            }
            return null;
        }
        public static new object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "Level1Gum":
                    return Level1Gum;
                case  "Level1Map":
                    return Level1Map;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "Level1Gum":
                    return Level1Gum;
                case  "Level1Map":
                    return Level1Map;
            }
            return null;
        }
        private void RefreshLayoutInternal (object sender, EventArgs e) 
        {
            Level1Gum.UpdateLayout();
        }
    }
}
