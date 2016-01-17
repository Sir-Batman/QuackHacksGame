using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class leadToFire : MonoBehaviour {

    GameObject player;
    Slider bar;
    bool ran = false;

    void Update()
    {
        if (!ran)
        {
            ran = true;
            player = GameObject.FindGameObjectWithTag("player");
            bar = GetComponent<Slider>();
        }
        bar.value = (player.GetComponent<pScript>().attackTimer)*2f;
    }
}
