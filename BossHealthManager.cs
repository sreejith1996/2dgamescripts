using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossHealthManager : MonoBehaviour {
	
	public float enemyMaxHealth;
	
	public GameObject enemyDeathFX;

	
	float currentHealth;

	public GameObject bossPrefab;

	public float minSize;
	
	// Use this for initialization
	void Start () {
		currentHealth = enemyMaxHealth;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void addDamage(float damage){
		currentHealth -= damage;
		
		if (currentHealth <= 0) {


			if(transform.localScale.y > minSize){
				GameObject clone1 = Instantiate(bossPrefab,new Vector3(transform.position.x+0.5f,transform.position.y,transform.position.z),transform.rotation) as GameObject;
				GameObject clone2 = Instantiate(bossPrefab,new Vector3(transform.position.x-0.5f,transform.position.y,transform.position.z),transform.rotation) as GameObject;

				clone1.transform.localScale = new Vector3(transform.localScale.y * 0.5f,transform.localScale.y * 0.5f,transform.localScale.z);
				clone1.GetComponent<BossHealthManager>().currentHealth =enemyMaxHealth;
				clone2.transform.localScale = new Vector3(transform.localScale.y * 0.5f,transform.localScale.y * 0.5f,transform.localScale.z);
				clone2.GetComponent<BossHealthManager>().currentHealth =enemyMaxHealth;


			}

			makeDead();

		}
	}


	
	void makeDead(){
		Destroy (gameObject);
		Instantiate (enemyDeathFX, transform.position, transform.rotation);
	}
}