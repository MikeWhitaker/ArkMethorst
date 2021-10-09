using System.Linq;

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

			initializePlayer();

			initializeCages();
		}

		private void initializePlayer()
		{
			var checkpoint = CheckpointList.First(item => item.Name == LastCheckpointName);
			Player1.Position = checkpoint.Position;
			Player1.Y -= 8;
			CameraControllingEntityInstance.ApplyTarget(CameraControllingEntityInstance.GetTarget(), lerpSmooth: false);
		}

		private void initializeCages()
		{
			var mapChickenCage = Map.MapLayers.First(s => s.Name == "GameplayObjectLayer");

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
