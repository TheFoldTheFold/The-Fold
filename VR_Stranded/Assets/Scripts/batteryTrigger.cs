using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryTrigger : MonoBehaviour
{

    public GameObject cam;
    public AudioClip audioC;
    private AudioSource audio;
    private bool hasPlayed = false;
    public static bool loadEnd = false;
    private bool triggerEffect = false;
    float lengt;


    void Start()
    {
        audio = GetComponent<AudioSource>();
        hasPlayed = false;
        lengt = audioC.length;
        triggerEffect = false;
    }

    void Update()
    {

        if (triggerEffect == true)
        {

            lengt -= Time.deltaTime;

            if (lengt > 0f)
            {

                cam.GetComponent<fadeoutend>().enabled = true;
            }

            else if (lengt < 0f)
            {
                cam.GetComponent<fadeoutend>().enabled = false;
                triggerEffect = false;

            }

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && FPSController.itemCount == 3)
        {
            if (!hasPlayed)
            {
                audio.Play();
                hasPlayed = true;
                triggerEffect = true;
                loadEnd = true;
            }
        }
    }
}