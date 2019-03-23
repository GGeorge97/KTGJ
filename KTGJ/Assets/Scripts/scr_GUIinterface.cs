using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_GUIinterface : MonoBehaviour
{
    private void Start()
    {
        switch (scr_MasterController.masterController.getCurrentScene())
        {
            case (scr_MasterController.Scenes.MAIN):
                break;

            case (scr_MasterController.Scenes.EMAIL):
                float spawnPoint = 0.0f;
                for (int i = 0; i < scr_EventManager.eventList.Count; i++)
                {
                    emailEvent email;
                    if (scr_EventManager.eventList[i].GetType() == typeof(emailEvent))
                    {
                        email = (emailEvent)scr_EventManager.eventList[i];
                        if (email.getStatus() == scr_Event.Status.ACTIVE)
                        {
                            GameObject emailObject = Instantiate(scr_EventManager.eventManager.emailPrefab, GameObject.FindGameObjectWithTag("ScreenSpace").gameObject.transform);
                            emailObject.transform.position = new Vector3(emailObject.transform.position.x, emailObject.transform.position.y - spawnPoint, emailObject.transform.position.z);
                            emailObject.GetComponentInChildren<scr_Email>().setEmailContents(i, email.getSender(), email.getSubject(), email.getTimeRecieved());
                            spawnPoint += 80.0f;
                        }
                    }
                }
                scr_EventManager.eventManager.setNewEmailEventAdded(false);
                break;

            case (scr_MasterController.Scenes.COMMS):
                break;

            default:
                break;
        }
    }

    void Update()
    {
        switch (scr_MasterController.masterController.getCurrentScene())
        {
            case (scr_MasterController.Scenes.MAIN):
                break;

            case (scr_MasterController.Scenes.EMAIL):
                if (scr_EventManager.eventManager.getNewEmailEventAdded())
                {
                    foreach (Transform childObject in GameObject.FindGameObjectWithTag("ScreenSpace").gameObject.transform)
                    {
                        if (childObject.gameObject.name == "Email(Clone)")
                            childObject.transform.position = new Vector3(childObject.transform.position.x, childObject.transform.position.y - 80.0f, childObject.transform.position.z);
                    }
                    emailEvent email;
                    int lastItem = scr_EventManager.eventList.Count;
                    if (scr_EventManager.eventList[lastItem - 1].GetType() == typeof(emailEvent))
                    {
                        email = (emailEvent)scr_EventManager.eventList[lastItem - 1];
                        if (email.getStatus() == scr_Event.Status.ACTIVE)
                        {
                            GameObject emailObject = Instantiate(scr_EventManager.eventManager.emailPrefab, GameObject.FindGameObjectWithTag("ScreenSpace").gameObject.transform);
                            emailObject.transform.position = new Vector3(emailObject.transform.position.x, emailObject.transform.position.y, emailObject.transform.position.z);
                            emailObject.GetComponentInChildren<scr_Email>().setEmailContents(scr_EventManager.eventList.Count, email.getSender(), email.getSubject(), email.getTimeRecieved());
                        }
                    }
                    scr_EventManager.eventManager.setNewEmailEventAdded(false);
                }
                break;

            case (scr_MasterController.Scenes.COMMS):
                break;

            default:
                break;
        }
    }
}
