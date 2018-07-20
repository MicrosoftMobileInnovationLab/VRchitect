using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolmanager : MonoBehaviour {

    public GameObject dude;
    public GameObject menu;
    public Camera cam1;
    public Camera cam2;
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;
    public void func1()
    {

        dude.SetActive(true);
        cam1.enabled = true;
        menu.SetActive(false);

        a1.SetActive(true);
    }
    public void func2()
    {
        dude.SetActive(true);
        cam1.enabled = true;
        menu.SetActive(false);
        a2.SetActive(true);
        
    }
    public void func3()
    {
        dude.SetActive(true);
        cam1.enabled = true;
        menu.SetActive(false);

        a3.SetActive(true);
    }
}
