using UnityEngine;
using System.Collections;

public class shotScript : MonoBehaviour {
	
	float	bulletSpeed = 4000f;
	int bulletHealth = 1;
	int bulletDmg = 10;
	
	void start ()
	{
		//Add force in the direction the bullet is facing
		GetComponent<RigidBody2D>().AddRelativeForce (new Vector3(0f, 1f, 0f) * bulletSpeed);
	}
	
	void onTriggerEnter2D(Collider2D other)
	{
		//If this shot is a pShot and hits an enemy
		if (gameObject.tag == "pShot" && other.gameObject.tag == "enemy")
			other.GetComponent<eScript>().health -= bulletDmg;
		
		//If this shot is an eShot and hits a player
		else if (gameObject.tag == "eShot" && other.gameObject.tag == "player")
			other.GetComponent<pScript>().health -= bulletDmg;
		
		//If this shot hits a wall
		else if (other.gameObject.tag == "wall")
			bulletHealth = 0;
		
		//If this bullet hits anything, always decrement its health
		bulletHealth--;
		
		//If the bullet has no health, destroy it
		if (bulletHealth <= 0) Destroy (gameObject);
	}
}