using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine;

public class fadeoutend : MonoBehaviour {

	public GameObject cam; 

	// Use this for initialization
	void Start () {

				cam.GetComponent<NoiseAndScratches>().enabled = true;
		
	}
	
	// Update is called once per frame
	void Update () {

		cam.GetComponent<NoiseAndScratches>().grainIntensityMin += 0.3f * Time.deltaTime;
		cam.GetComponent<NoiseAndScratches>().grainIntensityMax += 0.3f * Time.deltaTime;
		cam.GetComponent<NoiseAndScratches>().scratchIntensityMin += 0.3f * Time.deltaTime;
		cam.GetComponent<NoiseAndScratches>().scratchIntensityMax += 0.3f * Time.deltaTime;
		cam.GetComponent<NoiseAndScratches>().scratchFPS += 0.3f * Time.deltaTime;
		cam.GetComponent<NoiseAndScratches>().scratchJitter += 0.3f * Time.deltaTime;

}
}
