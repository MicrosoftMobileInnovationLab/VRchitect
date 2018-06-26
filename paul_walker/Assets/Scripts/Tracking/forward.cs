using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forward : MonoBehaviour {


    //public Camera head;
    public GameObject legleft;
    public GameObject legright;

    int check = 1;

    // Use this for initialization
    void Start () {
            
}
	
	// Update is called once per frame
	void Update () {
        if(check==1)
        {

            
            check = 0;
            GameObject dude = GameObject.Find("FPSController");
            Camera cam = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
            CharacterController m_CharacterController = dude.GetComponent<CharacterController>();
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
            float ly = legleft.transform.localPosition.y;
            float ry = legright.transform.localPosition.y;
            if (ly - ry > 0.15f || ry - ly > 0.15f)
            {
                m_CharacterController.Move(cam.transform.forward * 2 * Time.deltaTime);

            }
            
        }
        check = 1;
    }
}
