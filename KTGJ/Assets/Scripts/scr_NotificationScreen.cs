using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_NotificationScreen : MonoBehaviour
{
    private AudioSource audioClip;
    private void Start()
    {
        audioClip = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (scr_EventManager.eventManager.getNewEmailEventAdded() && !scr_EventManager.eventManager.getIsNotified())
        {
            audioClip.Play();
            scr_SceneDirector.animator.Play("EmailNotification");
            scr_EventManager.eventManager.setIsNotified(true);
        }
    }
}
