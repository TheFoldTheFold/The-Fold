using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryTrigger : MonoBehaviour {

	private AudioSource audio;
	private bool hasPlayed = false;
	void Start () {
		audio = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" && FPSController.itemCount == 3){
			if (!hasPlayed) {
				audio.Play ();
				hasPlayed = true;
			}
		}
	}
}
