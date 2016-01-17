using UnityEngine;
using System.Collections;

public class pScript : MonoBehaviour {
	
	public float speed = 6f;				//Movement speed
	public float attackTimer = 0;			//When this is 0, player can attack
	private float attackRate = 0.5f;		//Time delay between attacks
	public float health = 100;				//When this is 0, player dies
	public float shotSpeed = 10f;			//Speed of the shot
	public GameObject shot;
	//private Vector3 playerPosition3d;
	public Vector2 playerPosition2d;
	private Vector2 mousePosition;
	private Vector2 direction;
	
	void Update ()
	{
		//Player movement
		float movex = Input.GetAxis("Horizontal");
		float movey = Input.GetAxis("Vertical");
		GetComponent<Rigidbody2D>().velocity = new Vector2 (movex * speed, movey * speed);
	
		//Check if dead
		if (health <= 0) Death();
	
		//Attack facing
		//playerPosition3d = new Vector3(transform.position.x, transform.position.y, 4);
		playerPosition2d = new Vector2 (transform.position.x, transform.position.y);
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		direction = mousePosition - playerPosition2d;
		direction.Normalize();
		
		//Attack
		attackTimer -= Time.deltaTime;									//Count down the attack Timer
		if (Input.GetMouseButton (0) && attackTimer <= 0) {
			Attack ();		//If holding mouse 1 and can attack, attack
			attackTimer = attackRate;
		}
	}
	
	void Death ()
	{
		//Play death animation
		gameObject.GetComponent<pScript>().enabled = false;
		gameObject.GetComponent<CircleCollider2D>().enabled = false;
	}
	
	void Attack ()
	{
		GameObject shotX = (GameObject)Instantiate(shot, 0.85f*direction+playerPosition2d/*playerPosition2d*/, Quaternion.identity);	//Insantiate shot at player position
		shotX.GetComponent<Rigidbody2D>().velocity = direction * shotSpeed;		//Set velocity in direction of mouse
	}
	
}