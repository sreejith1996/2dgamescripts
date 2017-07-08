using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public int keyadding;

	public ParticleSystem KeyEffect;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Pig"){
			if (other.GetComponent<PlayerController> () == null)
				return;

			KeyManager.AddKeys(keyadding);
			Instantiate(KeyEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}

}
