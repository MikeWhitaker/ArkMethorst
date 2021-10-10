using FlatRedBall;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Debugging;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkMethorst.Entities
{
	public partial class Player
	{
		AnimationController animationController;

		public IPressableInput RunInput { get; set; }
		public IPressableInput InputPickup { get; set; }

		public bool PressedUp => InputDevice.DefaultUpPressable.WasJustPressed;

		public void SetIndex(int index)
		{
			switch (index)
			{
				case 0:
					SpriteInstance.AnimationChains = PlatformerAnimations;
					break;
				case 1:
					SpriteInstance.AnimationChains = p2animations;
					break;
				case 2:
					SpriteInstance.AnimationChains = p3animations;
					break;
				case 3:
					SpriteInstance.AnimationChains = p4animations;
					break;
			}
		}

		private void CustomInitialize()
		{

			animationController = new AnimationController(SpriteInstance);

			var idleLayer = new AnimationLayer();
			idleLayer.EveryFrameAction = () =>
			{
				return "CharacterIdle" + DirectionFacing;
			};
			animationController.Layers.Add(idleLayer);

			var lookUpLayer = new AnimationLayer();
			lookUpLayer.EveryFrameAction = () =>
			{
				if (this.VerticalInput.Value > 0)
				{
					return "CharacterLookUp" + DirectionFacing;
				}
				return null;
			};
			animationController.Layers.Add(lookUpLayer);

			var walkLayer = new AnimationLayer();
			walkLayer.EveryFrameAction = () =>
			{
				if (this.Velocity.X != 0)
				{
					return "CharacterWalk" + DirectionFacing;
				}
				return null;
			};
			animationController.Layers.Add(walkLayer);

			var runLayer = new AnimationLayer();
			runLayer.EveryFrameAction = () =>
			{
				if (this.XVelocity != 0 && RunInput.IsDown)
				{
					return "CharacterRun" + DirectionFacing;
				}
				return null;
			};
			animationController.Layers.Add(runLayer);

			var skidLayer = new AnimationLayer();
			skidLayer.EveryFrameAction = () =>
			{
				if (this.XVelocity != 0 && this.HorizontalInput.Value != 0 &&
					Math.Sign(XVelocity) != Math.Sign(this.HorizontalInput.Value) &&
					this.RunInput.IsDown)
				{
					return "CharacterSkid" + DirectionFacing;
				}
				return null;
			};
			animationController.Layers.Add(skidLayer);

			var duckLayer = new AnimationLayer();
			duckLayer.EveryFrameAction = () =>
			{
				if (this.VerticalInput.Value < 0) { return "CharacterDuck" + DirectionFacing; }
				return null;
			}; animationController.Layers.Add(duckLayer); var fallLayer = new AnimationLayer(); fallLayer.EveryFrameAction = () =>
			{
				if (this.IsOnGround == false)
				{
					return "CharacterFall" + DirectionFacing;
				}
				return null;
			};
			animationController.Layers.Add(fallLayer);

			var jumpLayer = new AnimationLayer();
			jumpLayer.EveryFrameAction = () =>
			{
				if (this.IsOnGround == false && YVelocity > 0)
				{
					return "CharacterJump" + DirectionFacing;
				}
				return null;
			};
			animationController.Layers.Add(jumpLayer);

			var runJump = new AnimationLayer();
			runJump.EveryFrameAction = () =>
			{
				if (this.IsOnGround == false && RunInput.IsDown)
				{
					return "CharacterRunJump" + DirectionFacing;
				}
				return null;
			};
			animationController.Layers.Add(runJump);
		}

		partial void CustomInitializePlatformerInput()
		{
			if (InputDevice is Keyboard asKeyboard)
			{
				RunInput = asKeyboard.GetKey(Microsoft.Xna.Framework.Input.Keys.R);
				InputPickup = asKeyboard.GetKey(Microsoft.Xna.Framework.Input.Keys.E);
			}
			else if (InputDevice is Xbox360GamePad asGamepad)
			{
				RunInput = asGamepad.GetButton(Xbox360GamePad.Button.X);
				InputPickup = asGamepad.GetButton(Xbox360GamePad.Button.B);
			}
		}

		private void CustomActivity()
		{
			animationController.Activity();
			//When the player pressed the b button and the pick up hit box is in a state of collision with an animal then we want to set the coordinats to the
			// same coordinates as the player, even better would be to set the coordinates of the animal to the pick up hit box.



		}

		private bool CheckPickupAnimal()
		{
			if (InputPickup.WasJustPressed)
			{
				// check for collision with a animal object
				//var doesRightSideCollide = SolidCollision.CollideAgainst(PigletInstance.RightCornerDetectionRectagle);

			}

			return false;
		}

		private void CustomDestroy()
		{


		}

		private static void CustomLoadStaticContent(string contentManagerName)
		{


		}
	}
}
