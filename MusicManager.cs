using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour 
{
	public AudioClip laserSoundClip;
	public float laserSoundVolume;

	public AudioClip hitByLaserClip;
	public float hitByLaserVolume;

	public AudioClip enemyDestroyedClip;
	public float enemyDestroyedVolume;




	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void PlayLaserSound()
	{
		AudioSource.PlayClipAtPoint (laserSoundClip,transform.position);
	}

	public void PlayHitByLaserSound()
	{
		AudioSource.PlayClipAtPoint (hitByLaserClip,transform.position);
	}

	public void PlayEnemyDestroyedSound()
	{
		AudioSource.PlayClipAtPoint (enemyDestroyedClip,transform.position);
	}


}
