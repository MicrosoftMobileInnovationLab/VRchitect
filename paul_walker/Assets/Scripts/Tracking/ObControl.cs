using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObControl : MonoBehaviour {

	public GameObject obToControl;
	public float moveMultiplier = 4.0f;

	public bool isRotating = false;

	private CharacterController controller;

	private Transform camTransform;
	// Use this for initialization
	void Start () 
	{
		controller = obToControl.GetComponent<CharacterController>();

		camTransform = Camera.main.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float horiz = Input.GetAxis("Horizontal");
		float verti = Input.GetAxis("Vertical");

		if(!isRotating)
		{
			Vector3 amtToMove = camTransform.forward*verti + camTransform.right*horiz;
			amtToMove.y = 0;
			controller.SimpleMove(amtToMove * moveMultiplier);
			// controller.transform.localPosition += amtToMove;
		}
		else
		{
			// controller.transform.Rotate(horiz, 0, verti);
			// controller.transform.RotateAround(camTransform.right, verti * Time.deltaTime);
			controller.transform.RotateAround(camTransform.up, -horiz * Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.J))
		{
			isRotating = true;
		}
		else
		{
			isRotating = false;
		}
	}
}
