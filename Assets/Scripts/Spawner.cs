using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	public GameObject[] spawnees;
	public int[] spawnAmount;
	public string[] spawnParent;
	public Vector3[] spawnBoundsA;
	public Vector3[] spawnBoundsB;
	public Vector3 position;
	int randomInt;


	// Update is called once per frame
	void Start()
	{
		int spawned = 0;
		int numToSpawn = spawnAmount.Sum();
		int posx;
		int posz;
		int maxHeight = 500;
		int layerMask = LayerMask.GetMask("Ground");
		Debug.Log(numToSpawn);
		randomInt = 0;

		while (spawned < numToSpawn)
		{
			Debug.Log(spawnees.Length);
			Debug.Log(numToSpawn);
			while (spawnAmount[randomInt] == 0)
			{
				randomInt = Random.Range(0, spawnees.Length);
			}
			//posx = Random.Range(0, 2000);
			//posz = Random.Range(0, 2000);
			Vector3 randomCoord = new Vector3(Random.Range(spawnBoundsA[randomInt].x, spawnBoundsB[randomInt].x), maxHeight, Random.Range(spawnBoundsA[randomInt].z, spawnBoundsB[randomInt].z));
			RaycastHit hit;
			Ray ray = new Ray(randomCoord, Vector3.down);
			if (Physics.Raycast(ray, out hit, maxHeight, layerMask))
			{
				//position = new Vector3(Random.Range(5, 200), 70, Random.Range(5, 300));
				Instantiate(spawnees[randomInt], hit.point + new Vector3(0, 2, 0), Quaternion.identity, GameObject.Find(spawnParent[randomInt]).GetComponent<Transform>());
				spawnAmount[randomInt]--;
				spawned++;
			}
		}
	}
}