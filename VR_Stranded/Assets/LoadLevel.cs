using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {

	public int level;
	void Start(){
		StartCoroutine(Load());
	}
	IEnumerator Load()
	{
		yield return new WaitForSeconds(25);
		//var a = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(level);
		Application.LoadLevel(level);
	}
}
