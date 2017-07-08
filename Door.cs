using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public float totalkeytally;
	public string levelToLoad;
	bool playerInZone;


	// Use this for initialization
	void Start () {
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(KeyManager.key == totalkeytally){
			if(Input.GetAxisRaw("Vertical") > 0 && playerInZone){
				Application.LoadLevel(levelToLoad);
			}

		}
	
}
	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "Pig"){
			playerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.name == "Pig"){
			playerInZone = true;
		}
	}
}
