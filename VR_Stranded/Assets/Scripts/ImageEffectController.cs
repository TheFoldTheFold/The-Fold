using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine;

public class ImageEffectController : MonoBehaviour {

	public GameObject cam; 

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

		cam.GetComponent<BlurOptimized>().enabled = true;
	if(cam.GetComponent<BlurOptimized>().blurSize < 3.5f)
	{
		cam.GetComponent<BlurOptimized>().blurSize += 0.3f * Time.deltaTime;
	}
	 else if(cam.GetComponent<BlurOptimized>().blurSize > 3.5f)
	 {
		cam.GetComponent<BlurOptimized>().blurSize -= 0.3f * Time.deltaTime;
	}
		
}
}
