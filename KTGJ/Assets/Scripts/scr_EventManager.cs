using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EventManager : MonoBehaviour
{
    // Static reference
    public static scr_EventManager eventManager;
    public static List<scr_Event> eventList;

    public GameObject emailPrefab;

    private bool newEmailEventAdded;
    public bool getNewEmailEventAdded() { return newEmailEventAdded; }
    public void setNewEmailEventAdded(bool setVal) { newEmailEventAdded = setVal; }

    private bool inputActive;
    public bool getInputActive() { return inputActive; }
    public void setInputActive(bool setVal) { inputActive = setVal; }

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
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("MouseScrollWheel") > 0.0f)
                {
                    for (int i = 0; i < scr_EventManager.eventList.Count; i++)
                    {
                        emailEvent email;
                        email = (emailEvent)scr_EventManager.eventList[i];
                        if (scr_EventManager.eventList[i].GetType() == typeof(emailEvent))
                        {
                            foreach (Transform childObject in GameObject.FindGameObjectWithTag("ScreenSpace").gameObject.transform)
                            {
                                if (childObject.transform.position.y < 0.0f)
                                {
                                    if (childObject.gameObject.name == "Email(Clone)")
                                        childObject.transform.position += new Vector3(0.0f, 80.0f, 0.0f);
                                }
                                else
                                    break;
                            }
                        }
                    }
                }
                if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("MouseScrollWheel") < 0.0f)
                {
                    for (int i = 0; i < scr_EventManager.eventList.Count; i++)
                    {
                        emailEvent email;
                        email = (emailEvent)scr_EventManager.eventList[i];
                        if (scr_EventManager.eventList[i].GetType() == typeof(emailEvent))
                        {
                            if (email.getStatus() == scr_Event.Status.ACTIVE)
                            {
                                foreach (Transform childObject in GameObject.FindGameObjectWithTag("ScreenSpace").gameObject.transform)
                                {
                                    if (childObject.transform.position.y > 80.0f * eventList.Count)
                                    {
                                        if (childObject.gameObject.name == "Email(Clone)")
                                        childObject.transform.position -= new Vector3(0.0f, 80.0f, 0.0f);
                                    }
                                    else
                                        break;
                                }
                            }
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
        eventList.Add(new emailEvent(scr_Event.Status.ACTIVE, scr_MasterController.masterController.getElapsedTime()));
        newEmailEventAdded = true;
    }
}
