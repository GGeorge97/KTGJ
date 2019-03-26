using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_GUIinterface : MonoBehaviour
{
    private void Start()
    {
        switch (scr_MasterController.masterController.getCurrentScene())
        {
            case (scr_MasterController.Scenes.MAIN):
                break;

            case (scr_MasterController.Scenes.EMAIL):
                RefreshEmails();
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
                if (scr_EventManager.eventManager.getNewEmailEventAdded() || scr_EventManager.eventManager.getRefreshRequired())
                {
                    foreach (Transform childObject in GameObject.FindGameObjectWithTag("EmailScreen").gameObject.transform)
                    {
                        if (childObject.gameObject.name == "Email(Clone)")
                            Destroy(childObject.gameObject);
                    }
                    RefreshEmails();
                }
                break;

            case (scr_MasterController.Scenes.COMMS):
                break;

            default:
                break;
        }
    }

    private void RefreshEmails()
    {
        float spawnPoint = 0.0f;
        for (int i = scr_EventManager.eventList.Count - 1; i >= 0; i--)
        {
            scr_Event email;
            email = scr_EventManager.eventList[i];
            if (email.getStatus() == scr_Event.Status.ACTIVE)
            {
                GameObject emailObject = Instantiate(scr_EventManager.eventManager.emailPrefab, GameObject.FindGameObjectWithTag("EmailScreen").gameObject.transform);
                if (email.getReadUnread())
                {
                    ColorBlock colours = emailObject.GetComponentInChildren<Button>().colors;
                    Color32 colour = new Color32(123, 236, 235, 225);
                    colours.normalColor = colour;
                    emailObject.GetComponentInChildren<Button>().colors = colours;
                }
                emailObject.transform.position = new Vector3(emailObject.transform.position.x, emailObject.transform.position.y - spawnPoint, emailObject.transform.position.z);
                emailObject.GetComponentInChildren<scr_Email>().setEmailContents(i, email.getSender(), email.getSubject(), email.getTimeRecieved());
                spawnPoint += 80.0f;
            }
        }
        scr_EventManager.eventManager.setNewEmailEventAdded(false);
        scr_EventManager.eventManager.setRefreshRequired(false);
    }
}
