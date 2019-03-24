using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ScreenTabSelect : MonoBehaviour
{
    public GameObject emailScreen;
    public GameObject shopScreen;

    private bool tab = false;
    // false = email
    // true = shop

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeTab);
    }

    private void ChangeTab()
    {
        tab = !tab;
        if (tab)
            shopScreen.SetActive(true);
        else
            shopScreen.SetActive(false);
    }
}
