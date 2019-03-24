﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EventManager : MonoBehaviour
{
    // Static reference
    public static scr_EventManager eventManager;
    public static List<scr_Event> eventList;        // <--- This list is just for email events, renaming will take too long

    public GameObject emailPrefab;

    private bool inputActive;
    public bool getInputActive() { return inputActive; }
    public void setInputActive(bool setVal) { inputActive = setVal; }

    private bool newEmailEventAdded;
    public bool getNewEmailEventAdded() { return newEmailEventAdded; }
    public void setNewEmailEventAdded(bool setVal) { newEmailEventAdded = setVal; }

    private int activeEmailCount;
    public int getActiveEmailCount() { return activeEmailCount; }
    public void setActiveEmailCount(int setVal) { activeEmailCount = setVal; }

    private int scrollUPindex = 0;
    public void resetScrollUPindex() { scrollUPindex = 0; }
    private int scrollDOWNindex = 0;
    public void resetScrollDOWNindex() { scrollDOWNindex = eventList.Count; }

    void Start()
    {
        if (!eventManager)
            eventManager = this;

        eventList = new List<scr_Event>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        switch (scr_MasterController.masterController.getCurrentScene())
        {
            case (scr_MasterController.Scenes.MAIN):
                break;

            case (scr_MasterController.Scenes.EMAIL):
                if (Input.GetKeyDown(KeyCode.G))
                    scr_EventManager.eventManager.CreateEmailEvent();
                if (scrollDOWNindex > 5 || scrollUPindex > 0)
                {
                    if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("MouseScrollWheel") < 0.0f)
                    {
                        if (scrollDOWNindex > 5)
                        {
                            for (int i = GameObject.FindGameObjectWithTag("EmailScreen").gameObject.transform.childCount - 1; i >= 0; i--)
                            {
                                Transform childObject = GameObject.FindGameObjectWithTag("EmailScreen").gameObject.transform.GetChild(i);
                                if (childObject.gameObject.name == "Email(Clone)")
                                    childObject.transform.position += new Vector3(0.0f, 80.0f, 0.0f);
                            }
                            scrollDOWNindex--;
                            scrollUPindex++;
                        }
                    }
                    if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("MouseScrollWheel") > 0.0f)
                    {
                        if (scrollUPindex > 0)
                        {
                            for (int i = 0; i <= GameObject.FindGameObjectWithTag("EmailScreen").gameObject.transform.childCount - 1; i++)
                            {
                                Transform childObject = GameObject.FindGameObjectWithTag("EmailScreen").gameObject.transform.GetChild(i);
                                if (childObject.gameObject.name == "Email(Clone)")
                                    childObject.transform.position -= new Vector3(0.0f, 80.0f, 0.0f);
                            }
                            scrollUPindex--;
                            scrollDOWNindex++;
                        }
                    }
                }
                break;

            case (scr_MasterController.Scenes.COMMS):
                break;

            default:
                break;
        }
    }

    public void RunEvent(int eventID)
    {
        eventList[eventID].RunEvent();
    }

    public void CreateEmailEvent()
    {
        eventList.Add(new emailEvent(scr_Event.Status.ACTIVE, scr_MasterController.masterController.getElapsedTime(), true));
        activeEmailCount++;
        scrollUPindex = 0;
        scrollDOWNindex++;
        newEmailEventAdded = true;
    }
}
