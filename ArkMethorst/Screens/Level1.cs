using ArkMethorst.Entities;
using FlatRedBall;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.Localization;
using FlatRedBall.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ArkMethorst.Screens
{
	public partial class Level1
	{

		void CustomInitialize()
		{

		}

		void CustomActivity(bool firstTimeCalled)
		{
			// 1) itterate over de animal list 
			// 2) do something  for each of the animals in the list

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
