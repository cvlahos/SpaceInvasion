using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public GameObject enemyPrefab;
	public GameObject bossPrefab;

	public float timeBeforeFirstSpawn;
	public float spawnRepeatRate;

	Vector3 spawnerLocation;


	// Use this for initialization
	void Start () 
	{

		InvokeRepeating ("Spawn",timeBeforeFirstSpawn,spawnRepeatRate);
	}
	
	// Update is called once per frame
	void Update () 
	{

		spawnerLocation = transform.position;
		spawnerLocation.x = Random.Range (-4.5f,4.5f);

	}
		

	public void StopSpawn()
	{
		CancelInvoke ();
	}

	public void SpawnBoss()
	{
		Instantiate(bossPrefab,spawnerLocation,transform.rotation);
	}

	void Spawn()

	{
		Instantiate(enemyPrefab,spawnerLocation,transform.rotation);	
	}

}
