using FlatRedBall;
using FlatRedBall.AI.Pathfinding;
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
	public partial class Checkpoint
	{
		/// <summary>
		/// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
		/// This method is called when the Entity is added to managers. Entities which are instantiated but not
		/// added to managers will not have this method called.
		/// </summary>
		private void CustomInitialize()
		{


		}

		public void MarkAsChecked()
		{
			this.FlagSprite.Visible = true;
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
}
