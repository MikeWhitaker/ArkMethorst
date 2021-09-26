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
    public partial class Piglet : ArkMethorst.Entities.Animal, FlatRedBall.Graphics.IDestroyable
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
        protected static Microsoft.Xna.Framework.Graphics.Texture2D PigletTexture;
        public static System.Collections.Generic.Dictionary<System.String, ArkMethorst.DataTypes.PlatformerValues> PlatformerValuesStatic;
        protected static FlatRedBall.Graphics.Animation.AnimationChainList PigletWalk;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D PigletTextureSecondFrame;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D PigletTextureFirstFrame;
        
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
        public Piglet () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public Piglet (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public Piglet (string contentManagerName, bool addToManagers) 
        	: base(contentManagerName, addToManagers)
        {
            ContentManagerName = contentManagerName;
        }
        protected override void InitializeEntity (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            SpriteInstance = new FlatRedBall.Sprite();
            SpriteInstance.Name = "SpriteInstance";
            
            base.InitializeEntity(addToManagers);
        }
        public override void ReAddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            base.ReAddToManagers(layerToAddTo);
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
        }
        public override void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
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
            base.SpriteInstance.TextureScale = 1f;
            base.SpriteInstance.AnimationChains = PigletWalk;
            base.SpriteInstance.CurrentChainName = "PigletWalk";
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
        }
        public override void AssignCustomVariables (bool callOnContainedElements) 
        {
            base.AssignCustomVariables(callOnContainedElements);
            if (callOnContainedElements)
            {
            }
            base.SpriteInstance.TextureScale = 1f;
            base.SpriteInstance.AnimationChains = PigletWalk;
            base.SpriteInstance.CurrentChainName = "PigletWalk";
            GroundMovement = Entities.Piglet.PlatformerValuesStatic["Ground"];
            AirMovement = Entities.Piglet.PlatformerValuesStatic["Air"];
            SpriteInstanceFlipHorizontal = false;
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
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("PigletStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/piglet/piglettexture.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                PigletTexture = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/piglet/piglettexture.png", ContentManagerName);
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
                        FlatRedBall.IO.Csv.CsvFileManager.CsvDeserializeDictionary<System.String, ArkMethorst.DataTypes.PlatformerValues>("content/entities/piglet/platformervaluesstatic.csv", temporaryCsvObject, FlatRedBall.IO.Csv.DuplicateDictionaryEntryBehavior.Replace);
                        FlatRedBall.IO.Csv.CsvFileManager.Delimiter = oldDelimiter;
                        PlatformerValuesStatic = temporaryCsvObject;
                    }
                }
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/entities/piglet/pigletwalk.achx", ContentManagerName))
                {
                    registerUnload = true;
                }
                PigletWalk = FlatRedBall.FlatRedBallServices.Load<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/entities/piglet/pigletwalk.achx", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/piglet/piglettexturesecondframe.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                PigletTextureSecondFrame = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/piglet/piglettexturesecondframe.png", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/piglet/piglettexturefirstframe.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                PigletTextureFirstFrame = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/piglet/piglettexturefirstframe.png", ContentManagerName);
            }
            if (registerUnload && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("PigletStaticUnload", UnloadStaticContent);
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
                if (PigletTexture != null)
                {
                    PigletTexture= null;
                }
                if (PlatformerValuesStatic != null)
                {
                    PlatformerValuesStatic= null;
                }
                if (PigletWalk != null)
                {
                    PigletWalk= null;
                }
                if (PigletTextureSecondFrame != null)
                {
                    PigletTextureSecondFrame= null;
                }
                if (PigletTextureFirstFrame != null)
                {
                    PigletTextureFirstFrame= null;
                }
            }
        }
        [System.Obsolete("Use GetFile instead")]
        public static new object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "PigletTexture":
                    return PigletTexture;
                case  "PlatformerValuesStatic":
                    return PlatformerValuesStatic;
                case  "PigletWalk":
                    return PigletWalk;
                case  "PigletTextureSecondFrame":
                    return PigletTextureSecondFrame;
                case  "PigletTextureFirstFrame":
                    return PigletTextureFirstFrame;
            }
            return null;
        }
        public static new object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "PigletTexture":
                    return PigletTexture;
                case  "PlatformerValuesStatic":
                    return PlatformerValuesStatic;
                case  "PigletWalk":
                    return PigletWalk;
                case  "PigletTextureSecondFrame":
                    return PigletTextureSecondFrame;
                case  "PigletTextureFirstFrame":
                    return PigletTextureFirstFrame;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "PigletTexture":
                    return PigletTexture;
                case  "PigletWalk":
                    return PigletWalk;
                case  "PigletTextureSecondFrame":
                    return PigletTextureSecondFrame;
                case  "PigletTextureFirstFrame":
                    return PigletTextureFirstFrame;
            }
            return null;
        }
        public override void SetToIgnorePausing () 
        {
            base.SetToIgnorePausing();
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(SpriteInstance);
        }
        public override void MoveToLayer (FlatRedBall.Graphics.Layer layerToMoveTo) 
        {
            var layerToRemoveFrom = LayerProvidedByContainer; // assign before calling base so removal is not impacted by base call
            base.MoveToLayer(layerToMoveTo);
        }
    }
}
