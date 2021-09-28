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
        
        private ArkMethorst.Entities.Piglet Piglet1;
        private ArkMethorst.Entities.Chicken Chicken1;
        private ArkMethorst.Entities.Lamb Lamb1;
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
            Piglet1 = new ArkMethorst.Entities.Piglet(ContentManagerName, false);
            Piglet1.Name = "Piglet1";
            Chicken1 = new ArkMethorst.Entities.Chicken(ContentManagerName, false);
            Chicken1.Name = "Chicken1";
            Lamb1 = new ArkMethorst.Entities.Lamb(ContentManagerName, false);
            Lamb1.Name = "Lamb1";
            Forms = new ArkMethorst.FormsControls.Screens.Level1GumForms(Level1Gum);
            
            
            base.Initialize(addToManagers);
        }
        public override void AddToManagers () 
        {
            Level1Gum.AddToManagers();FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += RefreshLayoutInternal;
            Level1Map.AddToManagers(mLayer);
            Piglet1.AddToManagers(mLayer);
            Chicken1.AddToManagers(mLayer);
            Lamb1.AddToManagers(mLayer);
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
            
            AnimalList.MakeOneWay();
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
            AnimalList.MakeTwoWay();
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public override void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            base.PostInitialize();
            AnimalList.Add(Piglet1);
            if (Piglet1.Parent == null)
            {
                Piglet1.X = 160f;
            }
            else
            {
                Piglet1.RelativeX = 160f;
            }
            if (Piglet1.Parent == null)
            {
                Piglet1.Y = -160f;
            }
            else
            {
                Piglet1.RelativeY = -160f;
            }
            AnimalList.Add(Chicken1);
            Chicken1.AirMovement = Entities.Chicken.PlatformerValuesStatic["Air"];
            if (Chicken1.Parent == null)
            {
                Chicken1.X = 120f;
            }
            else
            {
                Chicken1.RelativeX = 120f;
            }
            if (Chicken1.Parent == null)
            {
                Chicken1.Y = -120f;
            }
            else
            {
                Chicken1.RelativeY = -120f;
            }
            AnimalList.Add(Lamb1);
            if (Lamb1.Parent == null)
            {
                Lamb1.X = 100f;
            }
            else
            {
                Lamb1.RelativeX = 100f;
            }
            if (Lamb1.Parent == null)
            {
                Lamb1.Y = -100f;
            }
            else
            {
                Lamb1.RelativeY = -100f;
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
                Piglet1.AssignCustomVariables(true);
                Chicken1.AssignCustomVariables(true);
                Lamb1.AssignCustomVariables(true);
            }
            if (Piglet1.Parent == null)
            {
                Piglet1.X = 160f;
            }
            else
            {
                Piglet1.RelativeX = 160f;
            }
            if (Piglet1.Parent == null)
            {
                Piglet1.Y = -160f;
            }
            else
            {
                Piglet1.RelativeY = -160f;
            }
            Chicken1.AirMovement = Entities.Chicken.PlatformerValuesStatic["Air"];
            if (Chicken1.Parent == null)
            {
                Chicken1.X = 120f;
            }
            else
            {
                Chicken1.RelativeX = 120f;
            }
            if (Chicken1.Parent == null)
            {
                Chicken1.Y = -120f;
            }
            else
            {
                Chicken1.RelativeY = -120f;
            }
            if (Lamb1.Parent == null)
            {
                Lamb1.X = 100f;
            }
            else
            {
                Lamb1.RelativeX = 100f;
            }
            if (Lamb1.Parent == null)
            {
                Lamb1.Y = -100f;
            }
            else
            {
                Lamb1.RelativeY = -100f;
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
