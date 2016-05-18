using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
	public float enemyHealth = 150;
	public GameObject enemyLaserPrefab;
	public float enemyLaserSpeed = -5.0f;
	public float shotsPerSecond = 0.5f;


	private float randomEnemySpeed; 

	public MusicManager musicManager;

	public SpriteRenderer enemySpriteRenderer;

	public float enemySpeed;


	// Use this for initialization
	void Start () 
	{
		randomEnemySpeed = enemyLaserSpeed - 10;

	}
	
	// Update is called once per frame
	void Update () 
	{

		transform.Translate (0,enemySpeed * Time.deltaTime,0);


		float probability = Time.deltaTime * shotsPerSecond;

		if (Random.value < probability) 
		
		{
			Fire ();

		}

	}

	void Fire ()
	{
		GameObject thisEnemyLaser = Instantiate (enemyLaserPrefab, this.transform.position, transform.rotation) as GameObject;
		thisEnemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, Random.Range (enemyLaserSpeed, randomEnemySpeed), 0);
		Destroy(thisEnemyLaser, 2.0f);
	}


	void OnTriggerEnter2D(Collider2D enemyTriggColl) 
	{
		if (enemyTriggColl.gameObject.tag == "PlayerLaser" || enemyTriggColl.gameObject.tag == "Player") 
		{
			enemySpriteRenderer.color = Color.red;
			Invoke("EnemyDefaultColor", .05f);
			enemyHealth = enemyHealth - 50;
			
			if (enemyHealth <= 0.0f) 
			{
				musicManager.PlayEnemyDestroyedSound ();
				GameManager.score += 20;
				Destroy (gameObject);
			}
		}

		if (enemyTriggColl.gameObject.tag == "GarbageCollector") 
		{
			Destroy (gameObject);
		}
	}

	void EnemyDefaultColor()
	{
		enemySpriteRenderer.color = Color.white;
	}

}






