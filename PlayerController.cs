using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public bool characterInQuicksand;


	public float moveSpeed;

	private float moveVelocity;

	public float JumpHeight;
	public float glideSpeed;
	public Transform groundCheck; // point in the space
	public float groundCheckRaduis;
	public LayerMask whatIsGround;
		
	private bool grounded;

	private bool glide;

	private bool doubleJumped;
	
	public ParticleSystem Dust;

	private Animator anim;

	public bool isFlying;

	//facing right and left
	private bool facingRight;

	//Rocket 
	public float rocketFull;
	float currentRocket;
	bool isRocketOn;
	public Slider jetPackSlider;



	//for shooting
	public Transform gunTip;
	public GameObject bullet;
	float fireRate = 1.5f;
	float nextFire = 0f;
	public Slider coolDown;
	bool isCoolDown;

	//for rocket audio
	public AudioClip rocketAudio;
	AudioSource rocketAS;

	public bool OnLadder;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		currentRocket = rocketFull;
		jetPackSlider.maxValue = rocketFull;
		jetPackSlider.value = rocketFull;
		rocketAS = GetComponent<AudioSource>();
		gravityStore = GetComponent<Rigidbody2D> ().gravityScale;
		Dust.GetComponent<ParticleSystem> ().enableEmission = false;
		coolDown.maxValue = fireRate;
		coolDown.value = fireRate;
	}



	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRaduis, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {

		if (grounded) {
			doubleJumped = false;
			glide = false;
		}

		anim.SetBool ("Grounded", grounded);

#if UNITY_STANDALONE || UNITY_WEBPLAYER

		if (Input.GetButtonDown ("Jump") && grounded) {
			//GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x , JumpHeight);
			Jump();
			ParticleOff ();
			}

		if (Input.GetButtonDown ("Jump") && !doubleJumped && !grounded) {

			Jump();  //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x , JumpHeight);
			doubleJumped = true;
			ParticleOff ();
		}

		if(Input.GetButtonDown("Fire1") && !grounded){
			RocketJumpButtonDown();
					
		}
		if (Input.GetButtonUp("Fire1")) {
			RocketJumpButtonUp();
		}

		Move (Input.GetAxisRaw("Horizontal"));
		


#endif
		if(isFlying){
			currentRocket -= Time.deltaTime;
			jetPackSlider.value = currentRocket;
			if(currentRocket < 0 ){
				currentRocket = 0;
				isFlying = false;
				Dust.GetComponent<ParticleSystem> ().enableEmission = false;
			}

			GetComponent<Rigidbody2D> ().velocity = new Vector2(GetComponent<Rigidbody2D> ().velocity.x, glideSpeed);
		}
		else if(currentRocket < rocketFull){
			jetPackSlider.value = currentRocket;
			currentRocket += 0.1f*Time.deltaTime;
		}


		GetComponent<Rigidbody2D>().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		
		/*

		if (doubleJumped) {
			Dust.GetComponent<ParticleSystem> ().enableEmission = true;

		} else {
			Dust.GetComponent<ParticleSystem> ().enableEmission = false;


		}
		*/
		
	//	moveVelocity = 0f;


		//moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");



		if(GetComponent<Rigidbody2D>().velocity.x > 0){
			transform.localScale = new Vector3(0.2f, 0.2f, 1f);
			Dust.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);

		}else if(GetComponent<Rigidbody2D>().velocity.x < 0){
			transform.localScale = new Vector3(-0.2f, 0.2f, 1f);
			Dust.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
		}

#if UNITY_STANDALONE || UNITY_WEBPLAYER
		if (Input.GetButton ("Fire2"))
			fireRocket ();
#endif
		if(OnLadder){
			GetComponent<Rigidbody2D>().gravityScale = 0f;

			climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");

			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,climbVelocity);
		}
		if (!OnLadder) {
			GetComponent<Rigidbody2D>().gravityScale = gravityStore;

		}

		if(jetPackSlider.value == 0){
			rocketAS.Stop();
		}


		if(isCoolDown){
			coolDown.value -= Time.deltaTime;
			if(coolDown.value == 0){
				coolDown.gameObject.SetActive(false);
				coolDown.value = coolDown.maxValue;
				isCoolDown = false;
			}
		}

	}



	public void Move(float moveInput){
		moveVelocity = moveSpeed * moveInput;

	
	}


	public void RocketJumpButtonDown(){
		glide = true;
		Dust.GetComponent<ParticleSystem> ().enableEmission = true;
		isFlying = true;
		rocketAS.clip = rocketAudio;
		rocketAS.PlayOneShot(rocketAudio);
	}

	public void RocketJumpButtonUp(){
		isFlying = false;
		Dust.GetComponent<ParticleSystem> ().enableEmission = false;
		rocketAS.Stop();
	}

	public void Jump(){
		//GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x , JumpHeight);

		if (grounded) {
			//GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x , JumpHeight);
			//Jump();
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x , JumpHeight);
		}
		
		if (!doubleJumped && !grounded) {
			
			//Jump();  //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x , JumpHeight);
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x , JumpHeight);
			doubleJumped = true;
		}
	}

	 void OnCollisionEnter2D(Collision2D other){
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
		}
	}
	void OnCollisionExit2D(Collision2D other){
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}
	
	/*
	public void glideJump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x , glideSpeed);
	}
	*/

	public void fireRocket(){
		if(Time.time > nextFire){
			nextFire = Time.time+fireRate;
			coolDown.gameObject.SetActive(true);
			isCoolDown = true;
			if(facingRight){
				Instantiate(bullet, gunTip.position, Quaternion.EulerAngles(new Vector3(0,0,0)));
			}else if(!facingRight){
				Instantiate(bullet, gunTip.position, Quaternion.EulerAngles(new Vector3(0,0,270)));
			}



		}


	}

	void ParticleOff(){
		Dust.GetComponent<ParticleSystem> ().enableEmission = false;
	}


}
