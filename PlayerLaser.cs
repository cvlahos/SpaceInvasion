using UnityEngine;
using System.Collections;

public class PlayerLaser : MonoBehaviour 

{
	public float laserSpeed;

	//public float laserSpeed;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{


		transform.Translate (0,laserSpeed * Time.deltaTime,0);
		Destroy (gameObject, 2.0f);

	
	}
	
	void OnTriggerEnter2D(Collider2D laserTrigColl)
	{
		if (laserTrigColl.gameObject.tag == "Enemy" || laserTrigColl.gameObject.tag == "EnemyLaser") 
		{
			Destroy(gameObject);
		}
	}

}


