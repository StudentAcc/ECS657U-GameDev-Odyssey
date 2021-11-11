using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	public GameObject[] spawnees;
	public int[] spawnAmount;
	public Vector3 position;
	int randomInt;


	// Update is called once per frame
	void Start()
	{
		int spawned = 0;
		int numToSpawn = spawnAmount.Sum();

		while (spawned < numToSpawn)
		{
			randomInt = 0;
			while (spawnAmount[randomInt] != 0)
            {
				randomInt = Random.Range(0, spawnees.Length);
			}
			position = new Vector3(Random.Range(5, 200), 70, Random.Range(5, 300));
			Instantiate(spawnees[randomInt], position, Quaternion.identity);
			spawned++;
		}
	}
}