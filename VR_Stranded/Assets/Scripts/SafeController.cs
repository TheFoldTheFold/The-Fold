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

    void Start () {
        isActive = false;
        counter = 0;
        currentNum = 12;
        isOpen = false;
        currentTurn = 0.0f;
    }
	
	void Update () {
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
                else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                    turnSpeed = 0.6f;
                    turning = true;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow)) {
                    turnSpeed = -0.6f;
                    turning = true;
                }
                else if (Input.GetKeyDown(KeyCode.Space)) {
                    userInput[counter] = currentNum;
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
                break;
            }
        }
        if (flag == 1) {
            isOpen = true;
        }
    }
}
