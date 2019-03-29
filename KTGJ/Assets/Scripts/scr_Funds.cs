using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Funds : MonoBehaviour
{
    private Text fundsTxt;

    private void Start()
    {
        fundsTxt = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        fundsTxt.text = scr_MasterController.masterController.getFunds().ToString() + " .M";
    }
}
