using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour 
{
	public MusicManager musicManager;
	public LevelManager levelManager;
	//moving the ship
	public float shipSpeed;
	float shipMovingRightAndLeft;
	public float rightBounds;
	public float leftBounds;

	//Damaged Ship Sprites
	public SpriteRenderer shipSpriteRenderer;
	public Sprite shipSprite_0;
	public Sprite shipSprite_1;
	public Sprite shipSprite_2;
	public Sprite shipSprite_3;


	public GameObject laserPrefab;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
		ShipSpriteManager ();


			shipMovingRightAndLeft = Mathf.Clamp (transform.position.x,leftBounds,rightBounds);
			
			transform.position = new Vector3 (shipMovingRightAndLeft,transform.position.y,transform.position.z);
			
			
			if (Input.GetKey(KeyCode.RightArrow)) 
			{
				transform.position += new Vector3(shipSpeed * Time.deltaTime,0,0); 	
			}
			
			if (Input.GetKey(KeyCode.LeftArrow)) 
			{
				transform.position -= new Vector3(shipSpeed * Time.deltaTime,0,0);
			}
			
			if (Input.GetKeyDown(KeyCode.Space)) 
				
			{

			Instantiate(laserPrefab,transform.position,transform.rotation);	
			musicManager.PlayLaserSound();
		
			}
		}
	

	void OnTriggerEnter2D(Collider2D playerTrigColl) 
	{

		if (playerTrigColl.gameObject.tag == "EnemyLaser" || playerTrigColl.gameObject.tag == "Enemy") 
		{
			PlayerGotHit ();
		}

	}

	void ShipSpriteManager ()
	{
		if (GameManager.playerHealth >= 800.0f) 
		{
			shipSpriteRenderer.sprite = shipSprite_0;
		}
		if (GameManager.playerHealth <= 799.0f) 
		{
			shipSpriteRenderer.sprite = shipSprite_1;
		}

		if (GameManager.playerHealth <= 599.0f) 
		{
			shipSpriteRenderer.sprite = shipSprite_2;
		}

		if (GameManager.playerHealth <= 499.0f) 
		{
			shipSpriteRenderer.sprite = shipSprite_3;
		}
	}
	
	
	void PlayerGotHit()
	{
		musicManager.PlayHitByLaserSound ();
		GameManager.playerHealth -= 50;
		shipSpriteRenderer.color = Color.red;
		Invoke("ShipDefaultColor", 0.05f);
	}


	void ShipDefaultColor()
	{
		shipSpriteRenderer.color = Color.white;
	}
}