using UnityEngine;
using System.Collections;

public class SpringJump : MonoBehaviour {

	SpriteRenderer mySprite;
	public Sprite secondSprite;
	public Sprite firstSprite;
	public float pushBackForce;
	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer>();
		mySprite.sprite = firstSprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Pig"){
			mySprite.sprite = secondSprite;
			pushBack(other.gameObject.transform);
		}
	}
	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.tag == "Pig"){
			mySprite.sprite = firstSprite;
		}
	}

	void pushBack(Transform pushedObject){
		Vector2 pushDirection = new Vector2 (0, (pushedObject.position.y - transform.position.y)).normalized;
		pushDirection *= pushBackForce;
		Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
		pushRB.velocity = Vector2.zero;
		pushRB.AddForce (pushDirection, ForceMode2D.Impulse);
	}
}
