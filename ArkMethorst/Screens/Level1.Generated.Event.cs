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
    public partial class Level1
    {
        void OnPigletInstanceVsSolidCollisionCollisionOccurredTunnel (ArkMethorst.Entities.Piglet first, FlatRedBall.TileCollisions.TileShapeCollection second) 
        {
            if (this.PigletInstanceVsSolidCollisionCollisionOccurred != null)
            {
                PigletInstanceVsSolidCollisionCollisionOccurred(first, second);
            }
        }
    }
}
