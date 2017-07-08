using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {
	
	public ParticleSystem coinEffect;
	public int pointsToAdd;

	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<PlayerController> () == null)
			return;

		ScoreManager.AddPoints (pointsToAdd);
		Instantiate (coinEffect , transform.position, transform.rotation);
		Destroy (gameObject);
	}


	}
