using UnityEngine;
using System.Collections;

public class CannonScript : MonoBehaviour {

	public float fireRate;
	float nextFire = 0f;
	public GameObject bullet;
	public bool facingRight;
	public Transform cannonTip;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		fireCannon();

	}

	void fireCannon(){

		if(Time.time > nextFire){
			nextFire = Time.time + fireRate;
			if(facingRight){
				Instantiate(bullet, cannonTip.position, Quaternion.EulerAngles(new Vector3(0,0,0)));
			}else if(!facingRight){
				Instantiate(bullet, cannonTip.position, Quaternion.EulerAngles(new Vector3(0,0,180)));
			}
		}

	}
}
