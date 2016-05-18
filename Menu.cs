using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	public LevelManager levelManager;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (Input.GetKeyDown(KeyCode.P)) 
		{
			levelManager.PlayGame();
	
		}


	}
}
