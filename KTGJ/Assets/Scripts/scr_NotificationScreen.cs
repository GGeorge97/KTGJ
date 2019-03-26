using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_NotificationScreen : MonoBehaviour
{
    void Update()
    {
        if (scr_EventManager.eventManager.getNewEmailEventAdded() && !scr_EventManager.eventManager.getIsNotified())
        {
            scr_SceneDirector.animator.Play("EmailNotification");
            scr_EventManager.eventManager.setIsNotified(true);
        }
    }
}
