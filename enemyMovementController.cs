using UnityEngine;
using System.Collections;

public class enemyMovementController : MonoBehaviour {

	Animator enemyAnimator;

	//facing
	public GameObject enemyGraphic;
	bool canFlip = true;
	bool facingRight = false;
	float flipTime = 5f;
	float nextFlipChance = 0f;

	//shooting 
	public float shootTime;
	float startShootTime;
	bool shooting;
	Rigidbody2D enemyRB;
	public float enemySpeed;

	// Use this for initialization
	void Start () {
		enemyAnimator = GetComponentInChildren<Animator>();
		enemyRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFlipChance) {
			if (Random.Range (0, 10) >= 5) flipFacing ();
			nextFlipChance = Time.time + flipTime;
		} 

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Pig") {
			if(facingRight && other.transform.position.x < transform.position.x) {
				flipFacing ();
			}
			if(!facingRight && other.transform.position.x > transform.position.x){
				flipFacing();
			}
			canFlip = false;
			shooting = true;

			startShootTime = Time.time + shootTime;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Pig") {
			if(startShootTime < Time.time){
				if(!facingRight){
					enemyRB.AddForce(new Vector2(-1,0)*enemySpeed);
				}else{
					enemyRB.AddForce(new Vector2(1,0)*enemySpeed);
				}
				enemyAnimator.SetBool("isShooting",shooting);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Pig"){
			canFlip = true;
			shooting = false;
			enemyRB.velocity = new Vector2(0f,0f);
			enemyAnimator.SetBool("isShooting",shooting);
		}
	}

	void flipFacing(){
		if(!canFlip){
			return;
		}
		float facingX = enemyGraphic.transform.localScale.x;
		enemyGraphic.transform.localScale = new Vector3(-facingX, enemyGraphic.transform.localScale.y,enemyGraphic.transform.localScale.z);
		facingRight = !facingRight;
	}
}
