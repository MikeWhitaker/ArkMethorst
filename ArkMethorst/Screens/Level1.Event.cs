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
        void OnPigletInstanceVsSolidCollisionCollisionOccurred (ArkMethorst.Entities.Piglet first, FlatRedBall.TileCollisions.TileShapeCollection second) 
        {
            var collisionReposition = first.AxisAlignedRectangleInstance.LastMoveCollisionReposition;
            var hasCollidedWithWall = collisionReposition.X != 0;
            if (hasCollidedWithWall)
            {
                var pigletMovement = first.InputDevice as AnimalPlatformerInput;
                var isWallToTheRight = collisionReposition.X < 0;

                if (isWallToTheRight && pigletMovement.DesiredDirection == Direction.Right)
                {
                    pigletMovement.DesiredDirection = Direction.Left;
                }
                else if (!isWallToTheRight && pigletMovement.DesiredDirection == Direction.Left)
                {
                    pigletMovement.DesiredDirection = Direction.Right;
                }

                first.SpriteInstanceFlipHorizontal = !first.SpriteInstanceFlipHorizontal;
            }
        }
    }
}
