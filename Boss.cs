using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour 
{
	public float bossHealth = 150;
	public GameObject enemyLaserPrefab;
	public float bossLaserSpeed = -5.0f;
	public float shotsPerSecond = 0.5f;
	
	
	private float randomEnemySpeed; 
	
	public MusicManager musicManager;
	
	public SpriteRenderer bossSpriteRenderer;

	public LevelManager levelManager;

	
	
	// Use this for initialization
	void Start () 
	{
		randomEnemySpeed = bossLaserSpeed - 10;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		

		
		
		float probability = Time.deltaTime * shotsPerSecond;
		
		if (Random.value < probability) 
			
		{
			Fire ();
			
		}
		
	}
	
	void Fire ()
	{
		GameObject thisEnemyLaser = Instantiate (enemyLaserPrefab, this.transform.position, Quaternion.identity) as GameObject;
		thisEnemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, Random.Range (bossLaserSpeed, randomEnemySpeed), 0);
		Destroy(thisEnemyLaser, 2.0f);
	}
	
	
	void OnTriggerEnter2D(Collider2D enemyTriggColl) 
	{
		if (enemyTriggColl.gameObject.tag == "PlayerLaser" || enemyTriggColl.gameObject.tag == "Player") 
		{
			bossSpriteRenderer.color = Color.red;
			Invoke("EnemyDefaultColor", .05f);
			bossHealth = bossHealth - 50;
			
			if (bossHealth <= 0.0f) 
			{
				musicManager.PlayEnemyDestroyedSound ();
				GameManager.score += 20;
				levelManager.LoadNextLevel();
				Destroy (gameObject);
			}
		}
		
		
	}
	
	void EnemyDefaultColor()
	{
		bossSpriteRenderer.color = Color.white;
	}
	
}
