using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Accept : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Accept);
    }

    void Accept()
    {
        scr_Event email = scr_EventManager.eventList[transform.parent.gameObject.GetComponent<scr_OpenEmail>().getEventID()];
        scr_MasterController.masterController.changeFunds(email.getCashReward());
        scr_MasterController.masterController.changeGusMood(email.getMoodImpact());
        email.setStatus(scr_Event.Status.ACCEPTED);
        scr_EventManager.eventManager.decreaseActiveEmailCount();
        scr_EventManager.eventManager.resetScrollUPindex();
        scr_EventManager.eventManager.resetScrollDOWNindex();
        scr_EventManager.eventManager.setRefreshRequired(true);
        Destroy(transform.parent.gameObject.transform.parent.gameObject);
    }
}
