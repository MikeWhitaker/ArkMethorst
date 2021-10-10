using System;
using System.Collections.Generic;
using System.Linq;

namespace ArkMethorst.Screens
{
	public partial class GameScreen
	{
		static string LastCheckpointName = "LevelStart";
		private Random rngShuffle = new Random();

		void CustomInitialize()
		{
			var mapPitCollision = Map.ShapeCollections.FirstOrDefault(item => item.Name == "PitCollision");
			if (mapPitCollision != null)
			{
				PitCollision.AddToThis(mapPitCollision);
			}

			initializePlayer();

			initializeAnimals();
		}

		private void initializeAnimals()
		{
			// Shuffle the list of anmialSpawnPointes	
			Shuffle(AnimalSpawnPointList);

			int animalCounter = 0;
			foreach (var animal in AnimalList)
			{
				var nextAnimalSpawnPoint = AnimalSpawnPointList.Skip(animalCounter).FirstOrDefault();
				animal.Position = nextAnimalSpawnPoint.Position;

				animalCounter++;
			}
		}

		private void initializePlayer()
		{
			var checkpoint = CheckpointList.First(item => item.Name == LastCheckpointName);
			Player1.Position = checkpoint.Position;
			Player1.Y -= 8;
			CameraControllingEntityInstance.ApplyTarget(CameraControllingEntityInstance.GetTarget(), lerpSmooth: false);
		}

		private void Shuffle(IList<Entities.AnimalSpawnPoint> list)
		{
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = rngShuffle.Next(n + 1);
				Entities.AnimalSpawnPoint value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
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
