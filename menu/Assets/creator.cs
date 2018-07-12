using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creator : MonoBehaviour {

    public GameObject[] furniture;

    public void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            var x = Instantiate(furniture[0], 5f * Vector3.forward, Quaternion.Euler(0, 0, 0));
                 
        }
    }
}
