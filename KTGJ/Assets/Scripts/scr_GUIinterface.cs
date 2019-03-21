using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_GUIinterface : MonoBehaviour
{
    // Static Reference
    public static GameObject GUI_interface;

    public GameObject email;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("G"))
            scr_EventManager.eventManager.CreateEmailInstance();
    }
}
