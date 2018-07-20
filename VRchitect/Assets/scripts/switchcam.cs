using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class switchcam : MonoBehaviour {

    public GameObject a1;
    public GameObject a2;
    public GameObject a3;
    public GameObject a4;
    public GameObject a5;

    public Button m1;
    public Button m2;
    public Button m3;
    
    
    

    public Camera Cam1;
    public Camera Cam2;
    public GameObject dude;
    public GameObject menu;


    
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("m") || Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            if (dude.activeSelf)
            {
                Cam2.enabled = true;
                Cam1.enabled = false;
                dude.SetActive(false);
                menu.SetActive(true);
                a1.SetActive(false);
                a2.SetActive(false);
                a3.SetActive(false);
                a4.SetActive(false);
                a5.SetActive(false);
                creator.max = 10;

                var pointer = new PointerEventData(EventSystem.current);

                ExecuteEvents.Execute(m1.gameObject, pointer, ExecuteEvents.pointerClickHandler);
                ExecuteEvents.Execute(m2.gameObject, pointer, ExecuteEvents.pointerClickHandler);
                ExecuteEvents.Execute(m3.gameObject, pointer, ExecuteEvents.pointerClickHandler);
            }
            else
            {
                dude.SetActive(true);
                menu.SetActive(false);
                Cam2.enabled = false;
                Cam1.enabled = true;

               
                
            }
        }
    }
}
