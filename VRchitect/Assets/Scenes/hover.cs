using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;


public class hover : MonoBehaviour
{
    
    public Camera menu_cam;
    RaycastHit btn;
    GameObject butt;

    void Start()
    {

    }

    void Update()
    {
        var pointer = new PointerEventData(EventSystem.current);

        if (Physics.Raycast(menu_cam.transform.position, menu_cam.transform.forward, out btn, 100f))
        {

            if (btn.collider.gameObject.tag == "UI")
            {
                Debug.Log("Hovering...");

                if (Input.GetKeyDown("x") || Input.GetKeyDown(KeyCode.JoystickButton5))
                {
                    
                    ExecuteEvents.Execute(btn.collider.gameObject.transform.GetChild(0).gameObject, pointer, ExecuteEvents.pointerClickHandler);

                  //  Debug.Log("click1");

                }
            }

            if (btn.collider.gameObject.tag == "UI2")
            {
                Debug.Log("Hovering...");

                if (Input.GetKeyDown("x") || Input.GetKeyDown(KeyCode.JoystickButton5))
                {

                    ExecuteEvents.Execute(btn.collider.gameObject, pointer, ExecuteEvents.pointerClickHandler);

                   // Debug.Log("click2");

                }
            }


        }


    }
}

   