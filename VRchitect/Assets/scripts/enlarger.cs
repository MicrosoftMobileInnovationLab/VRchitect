using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enlarger : MonoBehaviour {
    internal static int max;
    public Camera cam;
    private RaycastHit Vision;
    private RaycastHit Vision2;
    private Transform obj=null;
    private Transform obj2 = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out Vision, 20))

            {
                if (Vision.collider.gameObject.tag == "ddlc" || Vision.collider.gameObject.tag == "wall")
                {
                    obj = Vision.collider.gameObject.transform;
                    Debug.Log("test");

                    if (Vision.collider.gameObject.tag == "wall")
                    {
                        if (Physics.Raycast(obj.transform.position, cam.transform.forward, out Vision2, 3f))
                        {
                            obj2 = Vision2.collider.gameObject.transform;
                        }
                    }


                }

            }
        }
        if (obj!=null && obj.tag == "ddlc")
        {

            if (Input.GetKeyDown("l") || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                float amt = 0.90f;

                obj.localScale *= amt;
            }

            if (Input.GetKeyDown("k") || Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                float amt = 1.10f;

                obj.localScale *= amt;
            }
        }

        if (obj!= null && obj.tag == "wall")
        {
            if (Input.GetKeyDown("l") || Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                

                obj.localScale =new Vector3(.90f * obj.localScale.x, obj.localScale.y, obj.localScale.z);
                obj2.localScale = new Vector3(.90f * obj2.localScale.x, obj2.localScale.y, obj2.localScale.z);

            }

            if (Input.GetKeyDown("k") || Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                obj.localScale = new Vector3(1.10f * obj.localScale.x, obj.localScale.y, obj.localScale.z);
                obj2.localScale = new Vector3(1.10f * obj2.localScale.x, obj2.localScale.y, obj2.localScale.z);
            }
        }
    }
}
