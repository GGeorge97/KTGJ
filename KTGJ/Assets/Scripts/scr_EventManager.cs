using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EventManager : MonoBehaviour
{
    // Static reference
    public static scr_EventManager eventManager;
    public static List<scr_Event> eventList;    // <--- This list is just for email events, renaming will take too long

    public GameObject emailPrefab;
    public GameObject openedEmailPrefab;
    public GameObject openedSpamPrefab;
    public GameObject openedTutorialPrefab;

    private bool inputActive;
    public bool getInputActive() { return inputActive; }
    public void setInputActive(bool setVal) { inputActive = setVal; }

    private bool newEmailEventAdded;
    public bool getNewEmailEventAdded() { return newEmailEventAdded; }
    public void setNewEmailEventAdded(bool setVal) { newEmailEventAdded = setVal; }

    private bool refreshRequired;
    public bool getRefreshRequired() { return refreshRequired; }
    public void setRefreshRequired(bool setVal) { refreshRequired = setVal; }

    private bool isNotified;
    public bool getIsNotified() { return isNotified; }
    public void setIsNotified(bool setVal) { isNotified = setVal; }

    private int activeEmailCount;
    public int getActiveEmailCount() { return activeEmailCount; }
    public void decreaseActiveEmailCount() { activeEmailCount--; }

    private int scrollUPindex = 0;
    public void resetScrollUPindex() { scrollUPindex = 0; }
    private int scrollDOWNindex = 0;
    public void resetScrollDOWNindex() { scrollDOWNindex = activeEmailCount; }

    private bool once = false;
    private bool twice = false;

    void Start()
    {
        if (!eventManager)
            eventManager = this;

        eventList = new List<scr_Event>();
    }

    private void Update()
    {
        HandleInput();

        if (scr_MasterController.masterController.getElapsedTime() > 2.0f && !once)
        {
            once = true;
            CreateEmailEvent(scr_Event.EmailType.TUTORIAL);
        }

        if (scr_MasterController.masterController.getElapsedTime() >= 10.0f && !twice)
        {
            twice = true;
            CreateEmailEvent(scr_Event.EmailType.TUTORIAL);
        }
    }

    private void HandleInput()
    {
        switch (scr_MasterController.masterController.getCurrentScene())
        {
            case (scr_MasterController.Scenes.MAIN):
                break;

            case (scr_MasterController.Scenes.EMAIL):
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
        eventList[eventID].RunEvent(eventID);
    }

    public void CreateEmailEvent(scr_Event.EmailType type)
    {
        switch (type)
        {
            case scr_Event.EmailType.CHOICE:
                eventList.Add(new emailEvent(scr_Event.Status.ACTIVE, scr_MasterController.masterController.getElapsedTime(), true));
                break;
            case scr_Event.EmailType.SPAM:
                eventList.Add(new spamEmailEvent(scr_Event.Status.ACTIVE, scr_MasterController.masterController.getElapsedTime(), true));
                break;
            case scr_Event.EmailType.TUTORIAL:
                eventList.Add(new tutorialInformationEvent(scr_Event.Status.ACTIVE, scr_MasterController.masterController.getElapsedTime(), true));
                break;
            default:
                return;
        }
        activeEmailCount++;
        scr_EventManager.eventManager.resetScrollUPindex();
        scr_EventManager.eventManager.resetScrollDOWNindex();
        newEmailEventAdded = true;
    }
}
