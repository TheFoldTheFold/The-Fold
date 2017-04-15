using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {

	public int level;

	void Update()
	{
		//var a = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(level);
		Application.LoadLevel(level);
	}
}
