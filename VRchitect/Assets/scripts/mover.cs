using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {


    public Camera cam;
    private RaycastHit Vision;
    private Transform obj=null;
     
    CharacterController conp;
    
    public bool isRotating = false;
    public GameObject dude;
    Vector3 offset;
    

    void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            
            
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out Vision, 20))

                {
                    if (Vision.collider.gameObject.tag == "ddlc")
                    {
                        obj = Vision.collider.gameObject.transform;
                    //con = obj.GetComponent<CharacterController>();

                    Debug.Log("test");

                        offset = obj.transform.position - cam.transform.position;
                        

                    }

                }
            
            
        }

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            if (obj != null)
            {
                obj = null;
            }
           
            
        }

        


        float horiz = Input.GetAxis("Horizontal");
		float verti = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("6"))
        {
           horiz = 5;
        }
        if (Input.GetKeyDown("4"))
        {
            horiz = -5;
        }
        if (Input.GetKeyDown("8"))
        {
            verti = 5;
        }
        if (Input.GetKeyDown("5"))
        {
            verti = -5;
        }

        if (!isRotating)
		{
            if (obj != null)
            {
                obj.transform.position = cam.transform.position + offset;
            }
           
		
		}
		else
		{
            if (obj != null)
            {
                obj.transform.RotateAround(new Vector3(0, 1, 0), -horiz * Time.deltaTime);
            }
			
		}

		if(Input.GetKey(KeyCode.JoystickButton1) || Input.GetKey(KeyCode.J))
		{
			isRotating = true;
            conp = dude.transform.GetComponent<CharacterController>();
            conp.enabled = false;
        }
		else
		{
			isRotating = false;
            conp = dude.transform.GetComponent<CharacterController>();
            conp.enabled = true;
        }




    }
}
