using UnityEngine;
using System.Collections;

public class InformationHandler : MonoBehaviour {

	public GameObject Information;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Pig"){
			Information.gameObject.SetActive(true);

		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Pig"){
			Information.gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}
}
