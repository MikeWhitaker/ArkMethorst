using ArkMethorst.Entities;



namespace ArkMethorst.Screens
{
	public partial class Level1
	{

		void CustomInitialize()
		{

		}

		void CustomActivity(bool firstTimeCalled)
		{
			foreach (var animal in AnimalList)
			{
				if (animal.IsOnGround)
				{
					var animalInput = animal.InputDevice as AnimalPlatformerInput;
					if (animalInput.DesiredDirection == Direction.Right)
					{
						var doesRightSideCollide = SolidCollision.CollideAgainst(animal.RightCornerDetectionRectagle);
						if (!doesRightSideCollide)
						{
							animalInput.DesiredDirection = Direction.Left;
							animal.SpriteInstanceFlipHorizontal = !animal.SpriteInstanceFlipHorizontal;
						}
					}
					else // moving left
					{
						var doesLeftLeftSideCollide = SolidCollision.CollideAgainst(animal.LeftCornerDetectionRectagle);
						if (!doesLeftLeftSideCollide)
						{
							animalInput.DesiredDirection = Direction.Right;
							animal.SpriteInstanceFlipHorizontal = !animal.SpriteInstanceFlipHorizontal;
						}
					}
				}
			}
		}

		void CustomDestroy()
		{


		}

		static void CustomLoadStaticContent(string contentManagerName)
		{


		}

	}
}
