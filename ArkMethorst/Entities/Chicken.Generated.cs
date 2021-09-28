#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall.Graphics;
using FlatRedBall.Math;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
using ArkMethorst.DataTypes;
using FlatRedBall.IO.Csv;
namespace ArkMethorst.Entities
{
    public partial class Chicken : ArkMethorst.Entities.Animal, FlatRedBall.Graphics.IDestroyable
    {
        // This is made static so that static lazy-loaded content can access it.
        public static new string ContentManagerName
        {
            get
            {
                return ArkMethorst.Entities.Animal.ContentManagerName;
            }
            set
            {
                ArkMethorst.Entities.Animal.ContentManagerName = value;
            }
        }
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        static object mLockObject = new object();
        static System.Collections.Generic.List<string> mRegisteredUnloads = new System.Collections.Generic.List<string>();
        static System.Collections.Generic.List<string> LoadedContentManagers = new System.Collections.Generic.List<string>();
        public static System.Collections.Generic.Dictionary<System.String, ArkMethorst.DataTypes.PlatformerValues> PlatformerValuesStatic;
        protected static FlatRedBall.Graphics.Animation.AnimationChainList ChickenAnimation;
        
        public override ArkMethorst.DataTypes.PlatformerValues AfterDoubleJump
        {
            set
            {
                base.AfterDoubleJump = value;
            }
            get
            {
                return base.AfterDoubleJump;
            }
        }
        public override ArkMethorst.DataTypes.PlatformerValues GroundMovement
        {
            set
            {
                base.GroundMovement = value;
            }
            get
            {
                return base.GroundMovement;
            }
        }
        public override ArkMethorst.DataTypes.PlatformerValues AirMovement
        {
            set
            {
                base.AirMovement = value;
            }
            get
            {
                return base.AirMovement;
            }
        }
        public Chicken () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public Chicken (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public Chicken (string contentManagerName, bool addToManagers) 
        	: base(contentManagerName, addToManagers)
        {
            ContentManagerName = contentManagerName;
        }
        protected override void InitializeEntity (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            SpriteInstance = new FlatRedBall.Sprite();
            SpriteInstance.Name = "SpriteInstance";
            mAxisAlignedRectangleInstance = new FlatRedBall.Math.Geometry.AxisAlignedRectangle();
            mAxisAlignedRectangleInstance.Name = "mAxisAlignedRectangleInstance";
            
            base.InitializeEntity(addToManagers);
        }
        public override void ReAddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            base.ReAddToManagers(layerToAddTo);
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mAxisAlignedRectangleInstance, LayerProvidedByContainer);
        }
        public override void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mAxisAlignedRectangleInstance, LayerProvidedByContainer);
            CurrentMovementType = MovementType.Ground;
            base.AddToManagers(layerToAddTo);
            CustomInitialize();
        }
        public override void Activity () 
        {
            base.Activity();
            
            CustomActivity();
        }
        public override void Destroy () 
        {
            base.Destroy();
            
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSprite(SpriteInstance);
            }
            if (AxisAlignedRectangleInstance != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.Remove(AxisAlignedRectangleInstance);
            }
            CustomDestroy();
        }
        public override void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            base.PostInitialize();
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.CopyAbsoluteToRelative();
                SpriteInstance.AttachTo(this, false);
            }
            if (SpriteInstance.Parent == null)
            {
                base.SpriteInstance.X = 0f;
            }
            else
            {
                base.SpriteInstance.RelativeX = 0f;
            }
            if (SpriteInstance.Parent == null)
            {
                base.SpriteInstance.Y = 0f;
            }
            else
            {
                base.SpriteInstance.RelativeY = 0f;
            }
            base.SpriteInstance.TextureAddressMode = Microsoft.Xna.Framework.Graphics.TextureAddressMode.Clamp;
            base.SpriteInstance.TextureScale = 1f;
            base.SpriteInstance.UseAnimationRelativePosition = false;
            base.SpriteInstance.AnimationChains = ChickenAnimation;
            base.SpriteInstance.CurrentChainName = "ChickenWalk";
            base.SpriteInstance.IgnoreAnimationChainTextureFlip = true;
            if (mAxisAlignedRectangleInstance.Parent == null)
            {
                mAxisAlignedRectangleInstance.CopyAbsoluteToRelative();
                mAxisAlignedRectangleInstance.AttachTo(this, false);
            }
            base.AxisAlignedRectangleInstance.Width = 16f;
            base.AxisAlignedRectangleInstance.Height = 14f;
            base.AxisAlignedRectangleInstance.Visible = false;
            base.AxisAlignedRectangleInstance.Color = Microsoft.Xna.Framework.Color.White;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public override void AddToManagersBottomUp (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            base.AddToManagersBottomUp(layerToAddTo);
        }
        public override void RemoveFromManagers () 
        {
            base.RemoveFromManagers();
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(SpriteInstance);
            }
            if (AxisAlignedRectangleInstance != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(AxisAlignedRectangleInstance);
            }
        }
        public override void AssignCustomVariables (bool callOnContainedElements) 
        {
            base.AssignCustomVariables(callOnContainedElements);
            if (callOnContainedElements)
            {
            }
            if (SpriteInstance.Parent == null)
            {
                base.SpriteInstance.X = 0f;
            }
            else
            {
                base.SpriteInstance.RelativeX = 0f;
            }
            if (SpriteInstance.Parent == null)
            {
                base.SpriteInstance.Y = 0f;
            }
            else
            {
                base.SpriteInstance.RelativeY = 0f;
            }
            base.SpriteInstance.TextureAddressMode = Microsoft.Xna.Framework.Graphics.TextureAddressMode.Clamp;
            base.SpriteInstance.TextureScale = 1f;
            base.SpriteInstance.UseAnimationRelativePosition = false;
            base.SpriteInstance.AnimationChains = ChickenAnimation;
            base.SpriteInstance.CurrentChainName = "ChickenWalk";
            base.SpriteInstance.IgnoreAnimationChainTextureFlip = true;
            base.AxisAlignedRectangleInstance.Width = 16f;
            base.AxisAlignedRectangleInstance.Height = 14f;
            base.AxisAlignedRectangleInstance.Visible = false;
            base.AxisAlignedRectangleInstance.Color = Microsoft.Xna.Framework.Color.White;
            SpriteInstanceFlipHorizontal = false;
            GroundMovement = Entities.Chicken.PlatformerValuesStatic["Ground"];
            AirMovement = Entities.Chicken.PlatformerValuesStatic["Air"];
        }
        public override void ConvertToManuallyUpdated () 
        {
            base.ConvertToManuallyUpdated();
            this.ForceUpdateDependenciesDeep();
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(SpriteInstance);
        }
        public static new void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            ContentManagerName = contentManagerName;
            ArkMethorst.Entities.Animal.LoadStaticContent(contentManagerName);
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
            bool registerUnload = false;
            if (LoadedContentManagers.Contains(contentManagerName) == false)
            {
                LoadedContentManagers.Add(contentManagerName);
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("ChickenStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
                if (PlatformerValuesStatic == null)
                {
                    {
                        // We put the { and } to limit the scope of oldDelimiter
                        char oldDelimiter = FlatRedBall.IO.Csv.CsvFileManager.Delimiter;
                        FlatRedBall.IO.Csv.CsvFileManager.Delimiter = ',';
                        System.Collections.Generic.Dictionary<System.String, ArkMethorst.DataTypes.PlatformerValues> temporaryCsvObject = new System.Collections.Generic.Dictionary<System.String, ArkMethorst.DataTypes.PlatformerValues>();
                        foreach (var kvp in Entities.Animal.PlatformerValuesStatic)
                        {
                            temporaryCsvObject.Add(kvp.Key, kvp.Value);
                        }
                        FlatRedBall.IO.Csv.CsvFileManager.CsvDeserializeDictionary<System.String, ArkMethorst.DataTypes.PlatformerValues>("content/entities/chicken/platformervaluesstatic.csv", temporaryCsvObject, FlatRedBall.IO.Csv.DuplicateDictionaryEntryBehavior.Replace);
                        FlatRedBall.IO.Csv.CsvFileManager.Delimiter = oldDelimiter;
                        PlatformerValuesStatic = temporaryCsvObject;
                    }
                }
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/entities/chicken/chickenanimation.achx", ContentManagerName))
                {
                    registerUnload = true;
                }
                ChickenAnimation = FlatRedBall.FlatRedBallServices.Load<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/entities/chicken/chickenanimation.achx", ContentManagerName);
            }
            if (registerUnload && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("ChickenStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
            }
            CustomLoadStaticContent(contentManagerName);
        }
        public static new void UnloadStaticContent () 
        {
            if (LoadedContentManagers.Count != 0)
            {
                LoadedContentManagers.RemoveAt(0);
                mRegisteredUnloads.RemoveAt(0);
            }
            if (LoadedContentManagers.Count == 0)
            {
                if (PlatformerValuesStatic != null)
                {
                    PlatformerValuesStatic= null;
                }
                if (ChickenAnimation != null)
                {
                    ChickenAnimation= null;
                }
            }
        }
        [System.Obsolete("Use GetFile instead")]
        public static new object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "PlatformerValuesStatic":
                    return PlatformerValuesStatic;
                case  "ChickenAnimation":
                    return ChickenAnimation;
            }
            return null;
        }
        public static new object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "PlatformerValuesStatic":
                    return PlatformerValuesStatic;
                case  "ChickenAnimation":
                    return ChickenAnimation;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "ChickenAnimation":
                    return ChickenAnimation;
            }
            return null;
        }
        public override void SetToIgnorePausing () 
        {
            base.SetToIgnorePausing();
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(SpriteInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(AxisAlignedRectangleInstance);
        }
        public override void MoveToLayer (FlatRedBall.Graphics.Layer layerToMoveTo) 
        {
            var layerToRemoveFrom = LayerProvidedByContainer; // assign before calling base so removal is not impacted by base call
            base.MoveToLayer(layerToMoveTo);
        }
    }
}
