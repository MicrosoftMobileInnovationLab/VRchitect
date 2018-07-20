using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creator : MonoBehaviour {

    public GameObject[] furniture;
    public Camera cam;
    public static int max = 10;

     void Start()
    {
        max = 10;
    }

    public  void Update()
    {

        if (max > 0)
        {
            if (Input.GetKeyDown("x") || Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                var x = Instantiate(furniture[furnitureswitcher.furniturenum], new Vector3(cam.transform.position.x + 10f * cam.transform.forward.x,2f, cam.transform.position.z + 10f * cam.transform.forward.z), Quaternion.Euler(0, 0, 0));
                //x.transform.position = new Vector3(x.transform.position.x,3f,x.transform.position.z);
                max--;
                if (x.tag != "door" && x.tag!="window")
                {
                    if (x.GetComponent<Rigidbody>() != null)
                    {
                        var y = x.GetComponent<Rigidbody>();
                        y.mass = 10000f;
                    }
                    foreach (Transform child in x.transform)
                    {
                        child.gameObject.GetComponent<Rigidbody>().mass = 1000f;

                    }
                }
                if (x.tag == "door")
                {
                    x.transform.localRotation = Quaternion.Euler(0,90, 90);
                }

                if (x.tag == "window")
                {
                    x.transform.localRotation = Quaternion.Euler(0, 90, 0);
                }


            }
            
        }
    }
}
