using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObResize : MonoBehaviour {

	public GameObject obToResize;

	private Transform obTransform;
	// Use this for initialization
	void Start () 
	{
		obTransform = obToResize.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.JoystickButton5))
		{
			float amt = Input.GetAxisRaw("Vertical");
			amt *= Time.deltaTime;
			amt += 1.0f;
			Debug.Log(amt);
			obTransform.localScale *= amt;
		}
	}
}
