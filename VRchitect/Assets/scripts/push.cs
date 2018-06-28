using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour {

    public float speedFactor = 2.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.forward*Time.deltaTime*speedFactor);
	}
}
