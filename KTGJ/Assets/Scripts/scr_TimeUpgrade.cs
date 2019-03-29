using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_TimeUpgrade : MonoBehaviour
{
    private AudioSource audioClip;

    void Start()
    {
        audioClip = gameObject.GetComponent<AudioSource>();
        gameObject.GetComponent<Button>().onClick.AddListener(Buy);
    }

    void Buy()
    {
        if (scr_MasterController.masterController.getFunds() >= 100)
        {
            audioClip.Play();
            Color32 colour = new Color32(74, 159, 140, 225);
            gameObject.GetComponent<Image>().color = colour;
            scr_MasterController.masterController.changeFunds(-100);
            scr_MasterController.masterController.changeElapsedTime(-60.0f);
            gameObject.GetComponent<Button>().enabled = false;
        }
    }
}
