using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	/*
	private pScript pStats;


	
	void Update ()
	{
		//If the player is alive
		if (pStats.health > 0)
		{
			//On escape press
			if (Input.GetKeyDown("escape"))
			{
				//If playing, pause
				if (Time.timeScale != 0)
				{
					Time.timeScale = 0;
					gameObject.GetComponent<retryButton>().enabled = true;
					gameObject.GetComponent<resumeButton>().enabled = true;
					gameObject.GetComponent<exitButton>().enabled = true;
				}
				
				//If paused, play
				else
				{
					Time.timeScale = 1;
					gameObject.GetComponent<retryButton>().enabled = false;
					gameObject.GetComponent<resumeButton>().enabled = false;
					gameObject.GetComponent<exitButton>().enabled = false;
				}
				
			}
		}
		
		//If the player is dead, wait x seconds, then open menu
		else
		{
			yield WaitForSeconds (1);
			gameObject.GetComponent<retryButton>().enabled = true;
			gameObject.GetComponent<exitButton>().enabled = true;
		}
	}
	*/
}