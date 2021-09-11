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

	}
}
