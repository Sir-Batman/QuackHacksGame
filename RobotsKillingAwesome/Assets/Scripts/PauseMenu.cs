using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    public GameObject PauseUI;
    private bool paused = false;
    
    void Start(){
    	PauseUI.SetActive(false); //when game runs menu is diabled
    }

    void Update(){
    	if(Input.GetButtonDown("Pause"))
    		paused = !paused;
    	
    	if(paused){
    		PauseUI.SetActive(true); //open pause menu
    		Time.timeScale = 0; //sets time to 0... game paused
    	}

    	if(!paused){
    		PauseUI.SetActive(false);
    		Time.timeScale = 1; //game back up to speed..if this was .3 itd be slow motion
    	}
    }

	public void Resume(){
		paused = false; //unpause the screen
	}

	public void Restart(){
		Application.LoadLevel (Application.loadedLevel); //load the level, of the current loaded level
	}

	public void MainMenu(){
		Application.LoadLevel (1); //the number is the scene index, you can get to scenes by file -> build settings

	}
	public void Quit(){
		Application.Quit ();

	}
	
	
}
