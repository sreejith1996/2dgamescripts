using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public GameObject currentCheckpoint;
	public GameObject deathParticle;
	public GameObject respawnParticle;
	public float respawnDelay;
	public GameObject playerPieces;
	public ParticleSystem Dust;
	playerHealth forHealthFull;

	private FollowCamera camera;

	private float gravityStore;

	private PlayerController player;

	public string levelToLoad;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

		camera = FindObjectOfType<FollowCamera> ();

		forHealthFull = FindObjectOfType<playerHealth> ();


	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void RespawnPlayer(){
		Dust.GetComponent<ParticleSystem> ().enableEmission = false;
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		camera.isFollowing = false;
		forHealthFull.makeHealthZero ();
		player.GetComponent<Collider2D>().enabled = false;
		player.isFlying = false;
		//gravityStore = player.GetComponent<Rigidbody2D> ().gravityScale;
		//player.GetComponent<Rigidbody2D>().gravityScale = 0f;
		//player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

		GameObject.Find ("Pig").transform.localScale = new Vector3(0, 0, 0);
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds (respawnDelay);
		//player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
		Application.LoadLevel(levelToLoad);
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
		player.transform.position = currentCheckpoint.transform.position;
		player.GetComponent<Collider2D>().enabled = true;
		player.enabled = true;
		Dust.GetComponent<ParticleSystem> ().enableEmission = false;
		GameObject.Find ("Pig").transform.localScale = new Vector3(0.2f, 0.2f, 1);
		camera.isFollowing = true;
		forHealthFull.makeHealthFull ();
	}
}
