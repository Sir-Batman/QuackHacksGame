using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    Slider healthbar;
    GameObject player;
    int ran;
    float check;

    void Start()
    {
        healthbar = GetComponentInChildren<Slider>();
        ran = 0;
        check = 0;
    }

    void Update()
    {
        if(ran == 0)
        {
            ran = 1;
            player = GameObject.FindGameObjectWithTag("player");
        }
        healthbar.value = player.GetComponent<pScript>().health;
        if (healthbar.value <= 20)
            healthbar.GetComponentInChildren<Image>().color = Color.red;
        else if (healthbar.value <= 80)
            healthbar.GetComponentInChildren<Image>().color = Color.yellow;
        else
            healthbar.GetComponentInChildren<Image>().color = Color.green;

    }



}
