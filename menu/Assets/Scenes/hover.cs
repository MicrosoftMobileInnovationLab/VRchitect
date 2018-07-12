using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

public class hover : MonoBehaviour
{

    public GameObject menu_parent;
    public Camera menu_cam;
    RaycastHit btn;


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

                if (Input.GetKeyDown("x"))
                {
                    ExecuteEvents.Execute(btn.collider.gameObject, pointer, ExecuteEvents.submitHandler);

                    Debug.Log("click");

                }
            }


        }


    }
}

   