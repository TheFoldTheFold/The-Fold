using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeController : MonoBehaviour {
    public bool isActive;
    public int[] combo = new int[3];
    public int[] userInput = new int[3];
    public int counter;
    public GameObject dial;
    public GameObject door;
    public bool turning;
    float turnSpeed;
    float currentTurn;
    public int currentNum;
    bool isOpen;
    AudioSource dialTurn;
    AudioSource enterClick;
    AudioSource openSafe;
    AudioSource wrongCombo;
    Animator anim;

    void Start () {
        isActive = false;
        counter = 0;
        currentNum = 12;
        isOpen = false;
        currentTurn = 0.0f;
        AudioSource[] audios = GetComponents<AudioSource>();
        dialTurn = audios[0];
        enterClick = audios[1];
        openSafe = audios[2];
        wrongCombo = audios[3];
        anim = GetComponent<Animator>();
    }
	
	void Update () {
        if (Input.GetButtonDown("Back")) {
            Debug.Log("Exit Interaction");
            counter = 0;
            GameObject player = GameObject.Find("Player");
            FPSController fps = player.GetComponent<FPSController>();
            Debug.Log(fps.move);
            fps.move = true;
            isActive = false;
        }
        if (isActive) {
            if (isOpen == true) {
                if (currentTurn < 110) {
                    door.transform.Rotate(0, 0.6f, 0);
                    currentTurn += Mathf.Abs(turnSpeed);
                }
            }
            else if (isOpen == false) {
                
                if (counter == 3) {
                    
                    comboCheck();
                }
                if (turning == true) {
                    turn();
                }
                else if (Input.GetAxis("DX") < 0) {
                    turnSpeed = 1f;
                    dialTurn.Play();
                    turning = true;
                }
                else if (Input.GetAxis("DX") > 0) {
                    turnSpeed = -1f;
                    dialTurn.Play();
                    turning = true;
                }
                else if (Input.GetButtonDown("Jump")) {
                    anim.SetTrigger("enter");
                    userInput[counter] = currentNum;
                    enterClick.Play();
                    ++counter;
                }
            }
        }
    }
    void turn() {
        if (currentTurn < 30) {
            dial.transform.Rotate(0, turnSpeed, 0);
            currentTurn += Mathf.Abs(turnSpeed);
        }
        else {
            turning = false;
            currentTurn = 0.0f;
            if (turnSpeed > 0) {
                ++currentNum;
            }
            else {
                --currentNum;
            }if (currentNum == 13) {
                currentNum = 1;
            }
            if (currentNum == 0) {
                currentNum = 12;
            }
        }
    }
    void comboCheck() {
        int flag = 1;
        for (int i = 0; i < 3; ++i) {
            Debug.Log(i);
            if (combo[i] != userInput[i]) {
                //Debug.Log("Combo does not match");
                counter = 0;
                flag = 0;
                wrongCombo.Play();
                break;
            }
        }
        if (flag == 1) {
            isOpen = true;
            openSafe.Play();
        }
    }
}
