using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_DeclineChoice : MonoBehaviour
{
    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Decline);
    }

    private void Decline()
    {
        emailEvent email;
        email = (emailEvent)scr_EventManager.eventList[transform.parent.gameObject.GetComponent<scr_OpenEmail>().getEventID()];
        email.setStatus(scr_Event.Status.ARCHIVED);
        scr_EventManager.eventManager.decreaseActiveEmailCount();
        scr_EventManager.eventManager.resetScrollUPindex();
        scr_EventManager.eventManager.resetScrollDOWNindex();
        scr_EventManager.eventManager.setRefreshRequired(true);
        Destroy(transform.parent.gameObject.transform.parent.gameObject);
    }
}
