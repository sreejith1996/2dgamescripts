using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

	private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();
	}
	
	public void LeftArrow(){
		thePlayer.Move(-1);
	}

	public void RightArrow(){
		thePlayer.Move (1);
	}
	public void UnpressedArrow(){
		thePlayer.Move(0);
	}

	public void Jump(){
		thePlayer.Jump();
	}		

	public void RocketUp(){
		thePlayer.RocketJumpButtonUp();
	}	
	public void RocketDown(){
		thePlayer.RocketJumpButtonDown();
	}

	public void Fire(){
		thePlayer.fireRocket();
	}
}
