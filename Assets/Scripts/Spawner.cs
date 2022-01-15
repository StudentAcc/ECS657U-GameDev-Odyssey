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
	public bool hideOriginal = true;
	int randomInt;

	// Update is called once per frame
	void Start()
	{

        if (PlayerPrefs.GetString("Difficulty") == "Easy")
        {
            Debug.Log("Easy");
            spawnAmount[0] = 5;
            spawnAmount[1] = 5;
            spawnAmount[2] = 5;
            spawnAmount[3] = 5;

        }
        else if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            Debug.Log("Normal");
            spawnAmount[0] = 10;
            spawnAmount[1] = 10;
            spawnAmount[2] = 10;
            spawnAmount[3] = 10;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            Debug.Log("Hard");
            spawnAmount[0] = 20;
            spawnAmount[1] = 20;
            spawnAmount[2] = 20;
            spawnAmount[3] = 20;
        }
        else
        {
			Debug.Log(PlayerPrefs.GetString("Difficulty"));
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

		if (hideOriginal)
        {
			foreach (GameObject spawnee in spawnees)
			{
				spawnee.SetActive(false);
			}
		}
	}
}