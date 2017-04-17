using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInteraction : MonoBehaviour {

    public bool holding;
    public bool inRange;
    public GameObject pu;
    public GameObject plyr;
    // Use this for initialization
    void Start()
    {
        holding = false;
        inRange = false;
        plyr = GameObject.Find("Player");
        pu = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Back") && pu != null && holding == true)
        {
            holding = false;
            inRange = false;
            pu.transform.parent = null;
            pu.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (inRange == true && Input.GetButtonUp("Interact"))
        {
            holding = true;
            pu.transform.parent = this.transform;
            pu.GetComponent<Rigidbody>().isKinematic = true;
            pu.transform.rotation = Quaternion.identity;
            pu.transform.localPosition = Vector3.zero;
            pu.transform.localPosition = new Vector3(0f, 1.2f, 1f);
            pu.transform.localEulerAngles = new Vector3(108f, 0f, 180f);
            
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PickUp")
        {
            inRange = true;
            pu = col.gameObject;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "PickUp")
        {
            inRange = false;
            pu = null;
        }
    }
}
