using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EventManager : MonoBehaviour
{
    public static List<scr_Event> eventList;

    void Start()
    {
        eventList = new List<scr_Event>();
        eventList.Add(new emailEvent("WhitehouseUrgent@USA.gov", "Your Mission", "Good day, Sir. /n You must look after this alien blah blah blah."));
    }

    void Update()
    {
        if (scr_MasterController.masterController.getElapsedTime() > 1000.0f)
        {
            eventList.Add(new emailEvent("WhitehouseUrgent@USA.gov", "New Email", "Please try this experiment for us!"));
        }
    }
}
