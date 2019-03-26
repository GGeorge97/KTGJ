using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AlarmFlash : MonoBehaviour
{
    void Update()
    {
        if (scr_MasterController.masterController.getTimerWarning())
            scr_SceneDirector.animator.Play("AlarmFlash");
    }
}
