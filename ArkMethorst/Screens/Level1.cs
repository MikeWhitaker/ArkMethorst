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
			if (PigletInstance.IsOnGround)
			{
				var pigletInstanceInput = PigletInstance.InputDevice as PigletPlatformerInput;
				if (pigletInstanceInput.DesiredDirection == Direction.Right)
				{
					var doesRightSideCollide = SolidCollision.CollideAgainst(PigletInstance.RightCornerDetectionRectagle);
					if (!doesRightSideCollide)
					{
						pigletInstanceInput.DesiredDirection = Direction.Left;
						PigletInstance.SpriteInstanceFlipHorizontal = !PigletInstance.SpriteInstanceFlipHorizontal;
					}
				}
				else // moving left
				{
					var doesLeftLeftSideCollide = SolidCollision.CollideAgainst(PigletInstance.LeftCornerDetectionRectagle);
					if (!doesLeftLeftSideCollide)
					{
						pigletInstanceInput.DesiredDirection = Direction.Right;
						PigletInstance.SpriteInstanceFlipHorizontal = !PigletInstance.SpriteInstanceFlipHorizontal;
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
