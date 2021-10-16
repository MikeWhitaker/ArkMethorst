using ArkMethorst.Entities;

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

		void OnAnimalListVsSolidCollisionCollisionOccurred(Entities.Animal first, FlatRedBall.TileCollisions.TileShapeCollection second)
		{
			var collisionReposition = first.AxisAlignedRectangleInstance.LastMoveCollisionReposition;
			var hasCollidedWithWall = collisionReposition.X != 0;

			if (!hasCollidedWithWall)
			{
				return;
			}

			var animalMovement = first.InputDevice as AnimalPlatformerInput;
			var isWallToTheRight = collisionReposition.X < 0;

			if (isWallToTheRight && animalMovement.DesiredDirection == Direction.Right)
			{
				animalMovement.DesiredDirection = Direction.Left;
				first.SpriteInstanceFlipHorizontal = !first.SpriteInstanceFlipHorizontal;

			}
			else if (!isWallToTheRight && animalMovement.DesiredDirection == Direction.Left)
			{
				animalMovement.DesiredDirection = Direction.Right;
				first.SpriteInstanceFlipHorizontal = !first.SpriteInstanceFlipHorizontal;
			}
		}

		void OnAnimalListAxisAlignedRectangleInstanceVsPlayerListAnimalPickupHitBoxCollisionOccurred(Entities.Animal animal, Entities.Player player)
		{
			if (!player.InputPickup.WasJustPressed)
			{
				return;
			}

			// we want to say to the piglet that it should take its co-ords from the player
			animal.IsPickedUp = true; // signaling the horizontal input should be null
			animal.Player = player; // Setting the player as an attribute on the piglet.
		}
		
		void OnCageBaseListVsAnimalListCollisionOccurred(Entities.Cage.CageBase cage, Entities.Animal animal)
		{
			if (!animal.IsPickedUp)
			{
				return;
			}

			var animalType = animal.GetType().Name.ToLower();
			var cageType = cage.Name.ToLower();

			if(cage.Name.Contains(animalType))
			{
				animal.Destroy();
			}

		}
	}
}
