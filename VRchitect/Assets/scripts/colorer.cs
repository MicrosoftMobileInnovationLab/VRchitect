using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorer : MonoBehaviour {

    public Camera cam;
    public Material[] pallete;
    
    private RaycastHit Vision;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out Vision, 20))

            {
                if (Vision.collider.gameObject.tag == "ddlc")
                {

                   Renderer r= Vision.collider.gameObject.GetComponent<Renderer>();
                    r.material = pallete[colorpicker.colornum];
                 }

                if (Vision.collider.gameObject.tag == "wall")
                {

                    Material[] mats =Vision.collider.gameObject.GetComponent<Renderer>().materials;
                    mats[1]=pallete[colorpicker.colornum];

                    Vision.collider.gameObject.GetComponent<Renderer>().materials = mats;
               
                }
                if (Vision.collider.gameObject.tag == "floor")
                {

                    Renderer r = Vision.collider.gameObject.GetComponent<Renderer>();
                    r.material = pallete[colorpicker.colornum];
                }


            }
        }



    }
}
