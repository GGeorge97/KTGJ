using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Email : MonoBehaviour
{
    private Text[] textContainers;
    private int ID;

    private void Awake()
    {
        textContainers = gameObject.GetComponentsInChildren<Text>();
        gameObject.GetComponent<Button>().onClick.AddListener(OpenEmail);
    }

    public void setEmailContents(int in_ID, string in_sender, string in_subject, string in_recieved)
    {
        ID = in_ID;
        textContainers[0].text = in_sender;
        textContainers[1].text = in_subject;
        textContainers[2].text = in_recieved;
    }

    private void OpenEmail()
    {
        ColorBlock colours = gameObject.GetComponent<Button>().colors;
        Color32 colour = new Color32(74, 159, 140, 225);
        colours.normalColor = colour;
        gameObject.GetComponent<Button>().colors = colours;
        scr_EventManager.eventManager.RunEvent(ID);
    }
}
