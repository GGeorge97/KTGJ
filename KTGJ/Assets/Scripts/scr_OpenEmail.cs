using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_OpenEmail : MonoBehaviour
{
    private Text[] textContainers;

    void Awake()
    {
        textContainers = gameObject.GetComponentsInChildren<Text>();
    }

    public void setEmailContents(string in_sender, string in_subject, string in_recieved, string in_message)
    {
        textContainers[0].text = in_sender;
        textContainers[1].text = in_subject;
        textContainers[2].text = in_recieved;
        textContainers[3].text = in_message;
    }
}
