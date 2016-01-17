using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeTracker : MonoBehaviour {

    bool trackTime;
    int score = 0;
    private float time = 0;
	public float timeToScore = 1;
	Text timer;
    public int scoreModifier = 1;

    void Start()
    {
        timer = transform.GetComponentInChildren<Text>();
    }

    void Update()
    {
        time += Time.deltaTime;
		if(time >= timeToScore)
        {
            score += 10 * scoreModifier;
            time = 0;
        }
        timer.text = score.ToString();
    }    
}
