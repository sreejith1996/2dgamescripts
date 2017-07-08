using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

	public float fullHealth;
	public AudioClip playerHurt;

	float currentHealth;

	PlayerController controlMovement;

	//HUD variables

	public Slider healthSlider;

	public Image damageScreen;
	bool damaged = false;
	Color damagedColor = new Color (0f,0f,0f,0.5f);
	float smoothColor = 5f;
	AudioSource playerAS;

	public LevelManager forrespawning;

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;

		controlMovement = GetComponent<PlayerController> ();

		forrespawning = FindObjectOfType<LevelManager> ();
	
		playerAS = GetComponent<AudioSource>();
		//HUD initialization

		healthSlider.maxValue = fullHealth;
		healthSlider.value = fullHealth;
		damaged = false;
	}	
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			damageScreen.color = damagedColor;
		} else {
			damageScreen.color = Color.Lerp (damageScreen.color, Color.clear, smoothColor*Time.deltaTime);
		}

		damaged = false;
	}



	public void addDamage(float damage){
		if (damage <= 0)
			return;
		currentHealth -= damage;
		playerAS.clip = playerHurt;
		playerAS.PlayOneShot(playerHurt);

		healthSlider.value = currentHealth;
		damaged = true;

		if (currentHealth <= 0) {
			forrespawning.RespawnPlayer();
		}
	}

	public void makeHealthFull(){
		currentHealth = fullHealth;
		healthSlider.value = fullHealth;
	}

	public void makeHealthZero(){
		currentHealth = 0;
		healthSlider.value = currentHealth;
	}

}
