using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Keyboard : MonoBehaviour
{
    private Button[] key = new Button[26];

    private void Awake()
    {
        key = gameObject.GetComponentsInChildren<Button>();
        
        for (int i = 0; i < 26; i++)
        {
            key[i].onClick.AddListener(getButton);
        }
    }

    public void getButton()
    {
    }
}
