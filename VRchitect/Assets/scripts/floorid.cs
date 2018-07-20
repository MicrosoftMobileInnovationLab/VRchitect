using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class floorid : MonoBehaviour {

	private static floorid me;

	public int floorNum = 0;

	// Use this for initialization
	void Awake()
	{
		if (me == null) {
			me = this;
			DontDestroyOnLoad(this);
		} else {
			DestroyObject(gameObject);
		}
 	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.JoystickButton0))
		{
			floorNum += 1;
			SceneManager.LoadSceneAsync("scene2");
			Debug.Log(floorNum);
		}
	}
	
}
