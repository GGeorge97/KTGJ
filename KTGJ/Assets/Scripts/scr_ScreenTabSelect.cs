using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ScreenTabSelect : MonoBehaviour
{
    public GameObject emailScreen;
    public GameObject shopScreen;
    private AudioSource audioClip;

    void Awake()
    {
        audioClip = gameObject.GetComponent<AudioSource>();
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeTab);
    }

    private void ChangeTab()
    {
        audioClip.Play();
        if (gameObject.name == "ShopTab")
            shopScreen.SetActive(true);
        else
            shopScreen.SetActive(false);
    }
}
