using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	static public int score;
	//static public int enemyCount;
	static public float playerHealth = 1000.0f;

	public bool detectorsEnabled;


	public LevelManager levelManager;

	public Text scoreText;
	public Text playerHealthText;

	public Spawner spawner;

	public int scoreToBattleBoss;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	


		scoreText.text = score.ToString ();
		playerHealthText.text = "Player Health " + playerHealth.ToString ();




		if (detectorsEnabled == true)
		{
			WinLevelDetector ();
			LoseGameDetector ();
		}



	}

	void WinLevelDetector()
	{
		if (score == scoreToBattleBoss)
		{
			spawner.StopSpawn();
			spawner.SpawnBoss();
			score = score + 100;

		
		}


	}


	void LoseGameDetector()
	{
		if (playerHealth <= 0) 
		{
			levelManager.LoseGame();
		}
	}


}
