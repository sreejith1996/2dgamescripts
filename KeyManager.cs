using UnityEngine;
using System.Collections;

public class KeyManager : MonoBehaviour {

	public static int key;

	// Use this for initialization
	void Start () {
		key = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(key < 0){
			key = 0;
		}
	}

	
	public static void AddKeys(int keysToAdd){
		key += keysToAdd;
	}

	public static void Reset(){
		key = 0;
	}
}
