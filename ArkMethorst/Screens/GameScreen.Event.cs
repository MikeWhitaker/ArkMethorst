using ArkMethorst.Entities;
using ArkMethorst.Screens;
using FlatRedBall;
using FlatRedBall.Audio;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.Screens;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Specialized;

namespace ArkMethorst.Screens
{
	public partial class GameScreen
	{
		void OnPlayerListVsPitCollisionCollisionOccurred(Entities.Player first, FlatRedBall.Math.Geometry.ShapeCollection second)
		{
			this.RestartScreen(reloadContent: false);
		}

		void OnPlayerListVsCheckpointListCollisionOccurred(Entities.Player first, Entities.Checkpoint checkpoint)
		{
			if (checkpoint.Visible)
			{
				// This is a checkpoint that you can actually touch and "turn on"
				checkpoint.MarkAsChecked();

				LastCheckpointName = checkpoint.Name;
			}
		}
		void OnPlayerListVsEndOfLevelListCollisionOccurred(Entities.Player first, Entities.EndOfLevel endOfLevel)
		{
			GameScreen.LastCheckpointName = "LevelStart";
			MoveToScreen(endOfLevel.NextLevel);
		}
		void OnAnimalListAxisAlignedRectangleInstanceVsPlayerListAnimalPickupHitBoxRightCollisionOccurred (Entities.Animal animal, Entities.Player player) 
        {
			if (player.InputPickup.WasJustPressed)
			{
				// we want to say to the piglet that it should take its co-ords from the player
				animal.IsPickedUp = true; // signaling the horizontal input should be null
				animal.Player = player; // Setting the player as an attriuut on the piglet.
			}
        }
        void OnPigletListAxisAlignedRectangleInstanceVsPlayerListAnimalPickupHitBoxRightCollisionOccurred (Entities.Animal first, Entities.Player second) 
        {
            
        }
        void OnAnimalListVsSolidCollisionCollisionOccurred (Entities.Animal first, FlatRedBall.TileCollisions.TileShapeCollection second) 
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
