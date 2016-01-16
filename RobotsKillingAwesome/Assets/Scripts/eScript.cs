using UnityEngine;
using System.Collections;

public class eScript : MonoBehaviour {

    public float speed = 5f;
    float attackTimer = 0;
    float attackRate = 0.5f;
    public float health = 100;
    public float shotSpeed = 20f;
    public GameObject shot;
    GameObject player;
    bool movementState = true;
    int range;


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
        Debug.Log("PEW");
        Vector3 direction = player.transform.position - transform.position;
        Vector2 dir = new Vector2(direction.x, direction.y);
        GameObject shotX = (GameObject)Instantiate(shot, transform.position, Quaternion.identity);
        shotX.GetComponent<Rigidbody2D>().velocity = dir * shotSpeed;
    }

    bool inRange()
    {
        Vector3 position = transform.position;
        Vector2 pos = new Vector2(position.x, position.y);
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
