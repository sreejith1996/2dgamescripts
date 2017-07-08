using UnityEngine;
using System.Collections;

public class CannonHit : MonoBehaviour {

	public float weaponDamage;
	public GameObject explosionEffect;
	CannonProjectile myCP;

	// Use this for initialization
	void Awake () {
		myCP = GetComponentInParent<CannonProjectile>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Platforms") || other.gameObject.layer == LayerMask.NameToLayer ("Player")){
			myCP.removeForce();
			Instantiate(explosionEffect,transform.position,transform.rotation);
			Destroy(gameObject);
			if(other.tag == "Pig"){
				playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth>();
				thePlayerHealth.addDamage(weaponDamage);
			}
		}
	}


	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Platforms") || other.gameObject.layer == LayerMask.NameToLayer ("Player")){
			myCP.removeForce();
			Instantiate(explosionEffect,transform.position,transform.rotation);
			Destroy(gameObject);
			if(other.tag == "Pig"){
				playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth>();
				thePlayerHealth.addDamage(10);
			}
		}
	}
}
