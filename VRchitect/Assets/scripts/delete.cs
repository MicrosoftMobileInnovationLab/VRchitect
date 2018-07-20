using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour {


    public Camera cam1;

    private RaycastHit Vision;

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton5))
        {
           if(Physics.Raycast(cam1.transform.position,cam1.transform.forward, out Vision,20))

            {
                if (Vision.collider.gameObject.tag == "ddlc")
                {
                    Destroy(Vision.collider.gameObject);
                }
                     
            }
        }



    }
}
