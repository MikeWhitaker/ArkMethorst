using System;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Specialized;
using FlatRedBall.Audio;
using FlatRedBall.Screens;
using ArkMethorst.Entities;
using ArkMethorst.Screens;
namespace ArkMethorst.Screens
{
    public partial class GameScreen
    {
        void OnPlayerListVsPitCollisionCollisionOccurredTunnel (Entities.Player first, FlatRedBall.Math.Geometry.ShapeCollection second) 
        {
            if (this.PlayerListVsPitCollisionCollisionOccurred != null)
            {
                PlayerListVsPitCollisionCollisionOccurred(first, second);
            }
        }
        void OnPlayerListVsCheckpointListCollisionOccurredTunnel (Entities.Player first, Entities.Checkpoint second) 
        {
            if (this.PlayerListVsCheckpointListCollisionOccurred != null)
            {
                PlayerListVsCheckpointListCollisionOccurred(first, second);
            }
        }
        void OnPlayerListVsEndOfLevelListCollisionOccurredTunnel (Entities.Player first, Entities.EndOfLevel second) 
        {
            if (this.PlayerListVsEndOfLevelListCollisionOccurred != null)
            {
                PlayerListVsEndOfLevelListCollisionOccurred(first, second);
            }
        }
        void OnPigletListAxisAlignedRectangleInstanceVsPlayerListAnimalPickupHitBoxRightCollisionOccurredTunnel (Entities.Animal first, Entities.Player second) 
        {
            if (this.PigletListAxisAlignedRectangleInstanceVsPlayerListAnimalPickupHitBoxRightCollisionOccurred != null)
            {
                PigletListAxisAlignedRectangleInstanceVsPlayerListAnimalPickupHitBoxRightCollisionOccurred(first, second);
            }
        }
    }
}
