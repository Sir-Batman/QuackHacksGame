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
    bool needsPath = true;
	public float range;
	private Vector3 direction;
	private Vector2 dir;
	private Vector2 objPosition2D;
    List<Node> path;

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
                needsPath = false;
                path.Clear();
            }
            attackTimer = attackRate;
        }
        if (needsPath)
        {
			Debug.Log ("Recalculating...");
            Vector2 pPos = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 ePos = new Vector2(transform.position.x, transform.position.y);
            path = GameObject.FindGameObjectWithTag("mapMaker").GetComponent<Map1>().generatePath(pPos, ePos);
            needsPath = false;
        }
        else
        {
            if(path == null)
            {
                needsPath = true;
            }
            else
            {
                Vector2 curGoal = new Vector2(path[0].xPos, path[0].yPos);
                if(transform.position == new Vector3(curGoal.x, curGoal.y, 0))
                {
                    path.RemoveAt(0);
                }
                else
                {
					Debug.Log ("Lerping...");
                    /*Vector3 dir = new Vector3(curGoal.x, curGoal.y, 0) - transform.position;
                    transform.position += dir * speed;*/
					transform.position = Vector3.Lerp(transform.position, new Vector3(curGoal.x, curGoal.y, 0), (0.01f * speed));

                }
            }
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
