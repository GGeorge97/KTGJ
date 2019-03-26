using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_TimerAlarm : MonoBehaviour
{
    void Update()
    {
        if (scr_MasterController.masterController.getTimerWarning())
        {
            Color32 colour = new Color32(255, 255, 255, 255);
            gameObject.GetComponent<Image>().color = colour;
            // alarm sound
        }
    }
}
