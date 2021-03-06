using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
	// Spawner system for NPCs around the map
	public GameObject[] spawnees;
	public int[] spawnAmount;
	public string[] spawnParent;
	public Vector3[] spawnBoundsA;
	public Vector3[] spawnBoundsB;
	public Vector3 position;
	public bool hideOriginal = true;
	int randomInt;

	// Update is called once per frame
	void Start()
	{

        if (PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            //Debug.Log("Easy");
            spawnAmount[0] = 20;
            spawnAmount[1] = 20;
            spawnAmount[2] = 20;
            spawnAmount[3] = 20;

        }
        else if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            //Debug.Log("Normal");
            spawnAmount[0] = 35;
            spawnAmount[1] = 35;
            spawnAmount[2] = 35;
            spawnAmount[3] = 35;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            //Debug.Log("Hard");
            spawnAmount[0] = 50;
            spawnAmount[1] = 50;
            spawnAmount[2] = 50;
            spawnAmount[3] = 50;
        }
        else
        {
			// Debug.Log(PlayerPrefs.GetString("Difficulty"));
			spawnAmount[0] = 5;
            spawnAmount[1] = 5;
            spawnAmount[2] = 5;
            spawnAmount[3] = 5;
        }

        int spawned = 0;
		int numToSpawn = spawnAmount.Sum();
		int posx;
		int posz;
		int maxHeight = 500;
		int layerMask = LayerMask.GetMask("Ground");
		// Debug.Log(numToSpawn);
		randomInt = 0;

		while (spawned < numToSpawn)
		{
			// Debug.Log(spawnees.Length);
			// Debug.Log(numToSpawn);
			while (spawnAmount[randomInt] == 0)
			{
				randomInt = Random.Range(0, spawnees.Length);
			}
			//posx = Random.Range(0, 2000);
			//posz = Random.Range(0, 2000);
			Vector3 randomCoord = new Vector3(Random.Range(spawnBoundsA[randomInt].x, spawnBoundsB[randomInt].x), maxHeight, Random.Range(spawnBoundsA[randomInt].z, spawnBoundsB[randomInt].z));
			RaycastHit hit2;
			NavMeshHit hit;
			Ray ray = new Ray(randomCoord, Vector3.down);
			if (Physics.Raycast(ray, out hit2, maxHeight, layerMask))
			{
				if (NavMesh.SamplePosition(hit2.point + new Vector3(0, 2, 0), out hit, 2f, NavMesh.AllAreas))
                {
					//position = new Vector3(Random.Range(5, 200), 70, Random.Range(5, 300));
					Instantiate(spawnees[randomInt], hit.position + new Vector3(0, 2, 0), Quaternion.identity, GameObject.Find(spawnParent[randomInt]).GetComponent<Transform>());
					spawnAmount[randomInt]--;
					spawned++;
				}
			}
		}

		if (hideOriginal)
        {
			foreach (GameObject spawnee in spawnees)
			{
				spawnee.SetActive(false);
			}
		}
	}
}