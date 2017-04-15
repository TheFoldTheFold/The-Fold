#pragma strict

public var myText : GameObject;

function Start () {
	
     yield WaitForSeconds (1);
     myText.SetActive( true );
     Debug.Log("Done"); 
}

function Update () {
	
}
