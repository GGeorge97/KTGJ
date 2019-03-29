using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class scr_Emoji : MonoBehaviour
{
    private Image[] imagePanels = new Image[3];

    private void Awake()
    {
        imagePanels = gameObject.GetComponentsInChildren<Image>();
    }

    public void setEmojis(Sprite emoji1, Sprite emoji2, Sprite emoji3)
    {
        //Debug.Log("Emoji Changed");
        imagePanels[0].sprite = emoji1;
        imagePanels[1].sprite = emoji2;
        imagePanels[2].sprite = emoji3;
    }
}
