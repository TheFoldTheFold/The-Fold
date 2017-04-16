using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine;

public class RadioBuzz : MonoBehaviour {

	public AudioClip otherClip;
	public GameObject cam;
    AudioSource audio;
    bool check;
    float wait;

	// Use this for initialization
	void Start () {

		 audio = this.GetComponent<AudioSource>();
		 cam.GetComponent<NoiseAndScratches>().enabled = false;
		 wait = otherClip.length;
		 check = true;


	}
	
	// Update is called once per frame
	void Update () {

		        if (check){

		        	wait-=Time.deltaTime;
		        	cam.GetComponent<NoiseAndScratches>().enabled = true;	

		        }
		        if(wait<0f){

		        	cam.GetComponent<NoiseAndScratches>().enabled = false;
		        	check = false;	
		        }

		
	}
}
