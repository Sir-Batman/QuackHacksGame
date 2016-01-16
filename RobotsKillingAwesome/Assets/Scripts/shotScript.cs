using UnityEngine;
using System.Collections;

public class shotScript : MonoBehaviour {
	
	public float bulletSpeed = 20f;
	public int bulletHealth = 1;
	public int bulletDmg = 10;
	private Rigidbody2D charRigidbody;

	void Start ()
	{
		transform.position = transform.position + new Vector3 (0, 0, 4f);
	}

	/*void onTriggerEnter2D(Collider2D other)
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
	}*/
}