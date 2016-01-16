using UnityEngine;
using System.Collections.Generic;

public class SEMIWORKING : MonoBehaviour {

    public float speed = 5f;
    float attackTimer = 0;
    float attackRate = 0.5f;
    public float health = 100;
    public float shotSpeed = 20f;
    public GameObject shot;
    GameObject player;
    bool movementState = true;
    public int range;
    List<Node> path;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        if(movementState == true)
        {
            movementState = false;
            Vector3 playerPos = player.transform.position;
            Vector2 pPos = new Vector2(playerPos.x, playerPos.y);
            Vector2 ePos = new Vector2(transform.position.x, transform.position.y);
            path = GameObject.FindGameObjectWithTag("mapMaker").GetComponent<Map1>().generatePath(pPos, ePos);
        
            //CHANGE ABOVE COMPONENT FOR DIFFERENT LEVELS

        }
        else
        {
            if (path == null)
                movementState = true;
            else
            {
                Node current = path[0];
                if(transform.position == new Vector3(current.xPos, current.yPos, 0))
                {
                    path.RemoveAt(0);
                }
                else
                {
                    Vector3 dir = transform.position - new Vector3(current.xPos, current.yPos, 0);
                    transform.position += dir * speed;
                }

            }
        }
    }    

    void attack()
    {
        Vector3 direction = player.transform.position - transform.position;
        Vector2 dir = new Vector2(direction.x, direction.y);
        GameObject shotX = (GameObject)Instantiate(shot, transform.position, Quaternion.identity);
        shotX.GetComponent<Rigidbody2D>().velocity = dir * shotSpeed;
    }

    bool inRange()
    {
        movementState = false;
        path.Clear();
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
