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
		bool _isPickedUp;
		Player player = null;
		float initialZValue;
		
		public bool IsPickedUp
		{
			get
			{
				return _isPickedUp;
			}
			set
			{
				_isPickedUp = value;
			}
		}

		public Player Player { get => player; set => player = value; }

		/// <summary>
		/// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
		/// This method is called when the Entity is added to managers. Entities which are instantiated but not
		/// added to managers will not have this method called.
		/// </summary>
		private void CustomInitialize()
		{

		}

		private void CustomActivity()
		{
			if (player != null)
			{
				if (IsPickedUp)
				{
					X = player.AnimalPickupHitBoxRight.X;
					Y = player.AnimalPickupHitBoxRight.Y + 4;
					initialZValue = Z;
					Z = 10;
				}

				if (player.InputPickup.WasJustReleased)
				{
					IsPickedUp = false;
				}
			}
		}

		private void CustomDestroy()
		{


		}

		private static void CustomLoadStaticContent(string contentManagerName)
		{


		}
	}

}
