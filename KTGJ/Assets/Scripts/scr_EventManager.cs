using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EventManager : MonoBehaviour
{
    // Static reference
    public static scr_EventManager eventManager;

    private List<scr_Event> eventList;
    public List<scr_Event> getList() { return eventList; }

    void Start()
    {
        eventList = new List<scr_Event>();
        eventList.Add(new emailEvent(scr_Event.Status.ACTIVE, scr_MasterController.masterController.getElapsedTime()));
    }

    void Update()
    {
        if (scr_MasterController.masterController.getElapsedTime() > 10.0f)
        {
            eventList.Add(new emailEvent(scr_Event.Status.ACTIVE, scr_MasterController.masterController.getElapsedTime()));
        }

        for (int i = 0; i < eventList.Count; i++)
        {

        }
    }
}
