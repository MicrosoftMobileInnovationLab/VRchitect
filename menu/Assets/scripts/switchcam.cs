using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchcam : MonoBehaviour {


    public Camera Cam1;
    public Camera Cam2;
    public GameObject dude;


    
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("m"))
        {
            if (dude.activeSelf)
            {
                Cam2.enabled = true;
                Cam1.enabled = false;
                dude.SetActive(false);
            }
            else
            {
                dude.SetActive(true);
                Cam2.enabled = false;
                Cam1.enabled = true;
                
            }
        }
    }
}
