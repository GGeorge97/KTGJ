using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EventManager : MonoBehaviour
{
    // Static reference
    public static scr_EventManager eventManager;
    public static List<scr_Event> eventList;

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

    void Start()
    {
        if (!eventManager)
            eventManager = this;

        eventList = new List<scr_Event>();
    }

    private void Update()
    {
        //Debug.Log(eventList.Count);
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
                if (eventList.Count > 5)
                {
                    if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("MouseScrollWheel") > 0.0f)
                    {
                        //foreach (Transform childObject in GameObject.FindGameObjectWithTag("ScreenSpace").gameObject.transform)
                        //{
                        //    if (childObject.gameObject.name == "Email(Clone)")
                        //    {
                        //        if (childObject.transform.position.y <= 90.0f)
                        //            childObject.transform.position += new Vector3(0.0f, 80.0f, 0.0f);
                        //    }
                        //}
                        for (int i = 0; i <= GameObject.FindGameObjectWithTag("ScreenSpace").gameObject.transform.childCount + 1; i++)
                        {
                            Transform childObject = GameObject.FindGameObjectWithTag("ScreenSpace").gameObject.transform.GetChild(i);
                            if (childObject.gameObject.name == "Email(Clone)")
                            {
                                if (childObject.transform.position.y <= 90.0f)
                                    childObject.transform.position -= new Vector3(0.0f, 80.0f, 0.0f);
                            }
                        }
                    }
                    if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("MouseScrollWheel") < 0.0f)
                    {
                        //int searchIndex = 0;
                        //foreach (Transform childObjectFirstPass in GameObject.FindGameObjectWithTag("ScreenSpace").gameObject.transform)
                        //{
                        //    if (childObjectFirstPass.gameObject.name == "Email(Clone)")
                        //        searchIndex++;
                        //    if (searchIndex == 5)
                        //    {
                                //Transform bottomEmail = childObjectFirstPass;
                                for(int i = GameObject.FindGameObjectWithTag("ScreenSpace").gameObject.transform.childCount - 1; i >= 0; i--)
                                {
                                    Transform childObject = GameObject.FindGameObjectWithTag("ScreenSpace").gameObject.transform.GetChild(i);
                                    if (childObject.gameObject.name == "Email(Clone)")
                                    {
                                        if (childObject.transform.position.y >= 90.0f - (80.0f * eventList.Count))
                                            childObject.transform.position += new Vector3(0.0f, 80.0f, 0.0f);
                                    }
                                }
                                //foreach (Transform childObjectSecondPass in GameObject.FindGameObjectWithTag("ScreenSpace").gameObject.transform)
                                //{
                                //    if (childObjectSecondPass.gameObject.name == "Email(Clone)")
                                //    {
                                //        if (childObjectFirstPass.transform.position.y >= 90.0f + (80.0f * eventList.Count))
                                //            childObjectSecondPass.transform.position -= new Vector3(0.0f, 80.0f, 0.0f);
                                //    }
                                //}
                                //break;
                            //}
                        //}
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
        Debug.Log(scr_MasterController.masterController.getElapsedTime());
        eventList.Add(new emailEvent(scr_Event.Status.ACTIVE, scr_MasterController.masterController.getElapsedTime()));
        activeEmailCount++;
        newEmailEventAdded = true;
    }
}
