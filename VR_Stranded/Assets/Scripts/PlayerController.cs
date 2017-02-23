using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody rig;

    // Use this for initialization
    void Start(){
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Walking
        float hAxis = Input.GetAxis("LHorizontal"); // left stick horizontal axis
        float vAxis = Input.GetAxis("LVertical");   // left stick vertical axis

        float khAxis = Input.GetAxis("Horizontal"); // keyboard horizontal axis
        float kvAxis = Input.GetAxis("Vertical");   // keyboard vertical axis

        //print(hAxis);
        //print(vAxis);

        // ---------------------------------------------

        float dPadX = Input.GetAxis("DPadX");   // left = -1; right = 1;
        float dPadY = Input.GetAxis("DPadY");   // down = -1; up = 1;

        float triggerAxis = Input.GetAxis("Triggers");  // left trigger = -1; right trigger = 1;
        print(triggerAxis);

        if (dPadX != 0) {
            print("DPad Horizontal Value: " + dPadX);
        }
        if (dPadY != 0) {
            print("DPad Vertical Value: " + dPadY);
        }
        if (triggerAxis != 0) {
            print("Trigger Value: " + triggerAxis);
        }
        if (Input.GetButtonDown("LBumper")) {
            print("Left Bumper");
        }
        if (Input.GetButtonDown("RBumper")) {
            print("Right Bumper");
        }
        if (Input.GetButtonDown("A Button")) {  // jump
            print("A Button");
        }
        if (Input.GetButtonDown("B Button")) {  // interact
            print("B Button");
        }
        if (Input.GetButtonDown("X Button")) {
            print("X Button");
        }
        if (Input.GetButtonDown("Y Button")) {
            print("Y Button");
        }
        if (Input.GetButtonDown("Back")) {
            print("Back Button");
        }
        if (Input.GetButtonDown("Start")) {
            print("Start Button");
        }
    }
}