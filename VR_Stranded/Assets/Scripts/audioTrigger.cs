using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine;

public class audioTrigger : MonoBehaviour {

	 //Use this for initialization
	public GameObject cam;
	public AudioClip audioC;
	private AudioSource audio;
	private bool hasPlayed = false;
	private bool triggerEffect = false;
	float lengt;
	Image img;

	void Start () {
		img = GameObject.Find("Radio UI").GetComponent<Image>();
		audio = GetComponent<AudioSource>();
		hasPlayed = false;
		lengt = audioC.length;	
		triggerEffect = false;	

	}

	void Update (){

		if(triggerEffect == true){

			lengt -= Time.deltaTime;

			if(lengt > 0f){

				img.enabled = true;
				cam.GetComponent<NoiseAndScratches>().enabled = true;
			}

			else if(lengt<0f){
				img.enabled = false;
				cam.GetComponent<NoiseAndScratches>().enabled = false;
				triggerEffect = false;

			}

		}

	}

	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player"){
			if (!hasPlayed) {
				audio.Play ();
				triggerEffect = true;
				hasPlayed = true;

			}
		}
	}

}
