using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Math.Geometry;

namespace ArkMethorst.Entities
{
    public partial class Piglet
    {
        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        private void CustomInitialize()
        {
            this.InitializePlatformerInput(new PigletPlatformerInput());

        }

        private void CustomActivity()
        {
            

        }

        private void CustomDestroy()
        {


        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
    }

	public class PigletPlatformerInput : InputDeviceBase
    {
        private Direction desiredDirection;

		public PigletPlatformerInput()
		{
            desiredDirection = Direction.Left;
        }

		public Direction DesiredDirection { get => desiredDirection; set => desiredDirection = value; }

		protected override float GetHorizontalValue()
        {
            if (DesiredDirection == Direction.Left)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        protected override bool GetPrimaryActionPressed()
        {
            //if (false)
            //{
            //    return true;
            //}
            return false;
        }
    }

    public enum Direction
    {
        Left,
        Right
    } 
}
