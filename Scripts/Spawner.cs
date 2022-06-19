using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	// ------------------Variables------------------
		public float spawnDelay = 0f;
		public GameObject objeto;
		float nextTimeToSpawn = 0f;


	// ------------------Updates------------------
		void Update()
		{
			if (nextTimeToSpawn <= Time.time)
			{
				SpawnCar();
				nextTimeToSpawn = Time.time + spawnDelay;
			}
		}


	// ------------------Spawn------------------
		void SpawnCar()
		{
			Instantiate(objeto);
		}
}