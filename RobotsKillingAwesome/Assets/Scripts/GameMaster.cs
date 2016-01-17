using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public GUIText hudScore;
	private float timerScore;
	public int scoreMultiplier = 1;
	// Use this for initialization
	void Start () {
		timerScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timerScore += Time.deltaTime * scoreMultiplier;
		hudScore.text = "Score: " + timerScore;
	}
}
