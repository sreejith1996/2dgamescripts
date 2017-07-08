using UnityEngine;
using System.Collections;

public class projectileController : MonoBehaviour {

	public float rocketSpeed;
	Rigidbody2D myRB;
	public PlayerController player;


	// Use this for initialization
	void Awake () {
		myRB = GetComponent<Rigidbody2D> ();

		player = FindObjectOfType<PlayerController> ();

		if(player.transform.localScale.x<0)
			myRB.AddForce (new Vector2 (-1, 0)*rocketSpeed,ForceMode2D.Impulse);
		else
			myRB.AddForce (new Vector2 (1, 0)*rocketSpeed,ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void removeForce(){
		myRB.velocity = new Vector2 (0, 0);
	}
}
