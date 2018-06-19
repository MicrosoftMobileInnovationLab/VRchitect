using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorscript : MonoBehaviour {
    Animator dooranim;
	// Use this for initialization
	void Start () {
        dooranim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnTriggerEnter(Collider other)
    {
        dooranim.SetTrigger("opendoor");
    }
     void OnTriggerExit(Collider other)
    {
        dooranim.enabled = true;
    }
     void lolpauseEvent()
    {
        dooranim.enabled = false;
    }
}
