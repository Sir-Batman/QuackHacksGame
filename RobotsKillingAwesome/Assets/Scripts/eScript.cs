using UnityEngine;
using System.Collections.Generic;

public class eScript : MonoBehaviour {

    public float speed = 5f;
    float attackTimer = 0;
    float attackRate = 0.5f;
    public float health = 100;
    public float shotSpeed = 20f;
    public GameObject shot;
    GameObject player;
    //bool movementState = true;
	public float range;
	private Vector3 direction;
	private Vector2 dir;
	private Vector2 objPosition2D;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    void Update()
    {
        if (health <= 0)
            Death();
        attackTimer -= Time.deltaTime;
        if(attackTimer <= 0)
        {
            if (inRange())
            {
				attack();
            }
            attackTimer = attackRate;
        }
    }

    void attack()
    {
        direction = player.transform.position - transform.position;
        dir = new Vector2(direction.x, direction.y);
		dir.Normalize();
		objPosition2D = new Vector2 (transform.position.x, transform.position.y);
		GameObject shotX = (GameObject)Instantiate(shot, dir+objPosition2D, Quaternion.identity);
        shotX.GetComponent<Rigidbody2D>().velocity = dir * shotSpeed;
    }

	//determine if object is in range of player to fire
    bool inRange()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        if (Vector2.Distance(player.GetComponent<pScript>().playerPosition2d, pos) < range)
            return true;
        return false;
    }

    void Death()
    {
        //play death animation
        Destroy(this.gameObject);
    }

}
