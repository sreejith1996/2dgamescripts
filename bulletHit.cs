using UnityEngine;
using System.Collections;

public class bulletHit : MonoBehaviour {

	public float weaponDamage;
	public GameObject explosionEffect;
	projectileController myPC;
	// Use this for initialization
	void Awake () {
		myPC = GetComponentInParent<projectileController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Platforms") || other.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			myPC.removeForce();
			Instantiate(explosionEffect,transform.position,transform.rotation);
			Destroy(gameObject);
			if(other.tag == "Enemy"){
				enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
				hurtEnemy.addDamage(weaponDamage);
			}

			if(other.tag == "Boss"){
				BossHealthManager hurtEnemy = other.gameObject.GetComponent<BossHealthManager>();
				hurtEnemy.addDamage(weaponDamage);

			}
		}

	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Platforms") ||  other.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			myPC.removeForce();
			Instantiate(explosionEffect,transform.position,transform.rotation);
			Destroy(gameObject);
			if(other.tag == "Enemy"){
				enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
				hurtEnemy.addDamage(weaponDamage);
			}

			if(other.tag == "Boss"){
				BossHealthManager hurtEnemy = other.gameObject.GetComponent<BossHealthManager>();
				hurtEnemy.addDamage(weaponDamage);

			}
		}
	}
}

