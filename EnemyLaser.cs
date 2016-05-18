using UnityEngine;
using System.Collections;


public class EnemyLaser : MonoBehaviour 
{

	//public float laserPower = 100.0f;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D enemyLaserTriggColl)
	{
		if (enemyLaserTriggColl.gameObject.tag == "GarbageCollector") 
		{
			Destroy (gameObject);
		}
	}

}
