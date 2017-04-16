using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getMetal : MonoBehaviour {

	public GameObject townSafe;
	private AudioSource audio;
	private bool hasPlayed = false;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		
		if (SafeController.isOpen == true && townSafe.tag == "TownSafe") {
			
			Debug.Log ("Opened");
			FPSController.itemCount += 1;
			if (!hasPlayed) {
					audio.Play ();
					hasPlayed = true;

				}

		}
	}
}
