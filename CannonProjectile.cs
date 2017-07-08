using UnityEngine;
using System.Collections;

public class CannonProjectile : MonoBehaviour {

	public float rocketSpeed;
	Rigidbody2D myRB;
	CannonScript cannonProjectile;



	
	// Use this for initialization
	void Awake () {
		myRB = GetComponent<Rigidbody2D> ();

		cannonProjectile = FindObjectOfType<CannonScript>();
		
		if(!cannonProjectile.facingRight){
			myRB.AddForce (new Vector2 (-1, 0)*rocketSpeed,ForceMode2D.Impulse);
		}else if(cannonProjectile.facingRight){
			myRB.AddForce (new Vector2 (1, 0)*rocketSpeed,ForceMode2D.Impulse);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void removeForce(){
		myRB.velocity = new Vector2 (0, 0);
	}
}
