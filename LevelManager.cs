using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public GameManager gameManager;

	public void PlayGame()

	{

		GameManager.playerHealth = 1000.0f;
		//GameManager.enemyCount = 0;
		GameManager.score = 0;
		Application.LoadLevel("Game");
	}

	public void LoseGame()
		
	{

		Application.LoadLevel("Lose");
	}

	public void WinGame()
		
	{
		Application.LoadLevel("Win");
	}

	public void LoseChanceAndReset()
	{
		gameManager.detectorsEnabled = false;
		//GameManager.enemyCount = 0;
		GameManager.playerHealth--;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void LoadNextLevel()
	{
		Application.LoadLevel (Application.loadedLevel + 1);
	}

}
