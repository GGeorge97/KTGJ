using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ScreenTabSelect : MonoBehaviour
{
    public GameObject emailScreen;
    public GameObject shopScreen;

    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeTab);
    }

    private void ChangeTab()
    {
        if (gameObject.name == "ShopTab")
            shopScreen.SetActive(true);
        else
            shopScreen.SetActive(false);
    }
}
