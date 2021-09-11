using FlatRedBall;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.Localization;
using FlatRedBall.Math.Geometry;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArkMethorst.Screens
{
	public partial class GameScreen
	{
		static string LastCheckpointName = "LevelStart";

		void CustomInitialize()
		{
			var mapPitCollision = Map.ShapeCollections.FirstOrDefault(item => item.Name == "PitCollision");
			if (mapPitCollision != null)
			{
				PitCollision.AddToThis(mapPitCollision);
			}

			var checkpoint = CheckpointList.First(item => item.Name == LastCheckpointName);
			Player1.Position = checkpoint.Position;
			Player1.Y -= 8;
			CameraControllingEntityInstance.ApplyTarget(CameraControllingEntityInstance.GetTarget(), lerpSmooth: false);
		}

		void CustomActivity(bool firstTimeCalled)
		{


		}

		void CustomDestroy()
		{


		}

		static void CustomLoadStaticContent(string contentManagerName)
		{


		}

	}
}
