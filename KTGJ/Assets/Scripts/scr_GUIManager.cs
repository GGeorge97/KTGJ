using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_GUIManager : MonoBehaviour
{
    public Text display1txt;
    public Text display2txt;

    private int eventListSize = 0;

    void Start()
    {
        eventListSize = scr_EventManager.eventList.Count;
    }

    void Update()
    {
        if (scr_EventManager.eventList.Count > eventListSize)
        {
            eventListSize = scr_EventManager.eventList.Count;
        }
    }
}
