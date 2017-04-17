using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {

	public int level;
	public int seconds;
	void Start(){
		StartCoroutine(Load());
	}
	IEnumerator Load()
	{
		//if (batteryTrigger.loadEnd == true) {
			yield return new WaitForSeconds (seconds);
			Application.LoadLevel (level);
		//}
	}
}
