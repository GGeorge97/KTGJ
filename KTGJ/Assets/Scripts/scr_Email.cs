using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Email : MonoBehaviour
{
    private Image icon;
    private AudioSource audioClip;
    private Text[] textContainers;
    private int ID;

    private void Awake()
    {
        icon = transform.GetChild(0).gameObject.GetComponent<Image>();
        textContainers = gameObject.GetComponentsInChildren<Text>();
        audioClip = gameObject.GetComponent<AudioSource>();
        gameObject.GetComponent<Button>().onClick.AddListener(OpenEmail);
    }

    public void setEmailContents(int in_ID, Sprite in_icon, string in_sender, string in_subject, string in_recieved)
    {
        ID = in_ID;
        icon.sprite = in_icon;
        textContainers[0].text = in_sender;
        textContainers[1].text = in_subject;
        textContainers[2].text = in_recieved;
    }

    public void setEmailContents(int in_ID, Sprite in_icon, string in_sender, string in_subject, string in_recieved, string in_message)
    {
        ID = in_ID;
        icon.sprite = in_icon;
        textContainers[0].text = in_sender;
        textContainers[1].text = in_subject;
        textContainers[2].text = in_recieved;
        textContainers[3].text = in_message;
    }

    private void OpenEmail()
    {
        audioClip.Play();
        ColorBlock colours = gameObject.GetComponent<Button>().colors;
        Color32 colour = new Color32(74, 159, 140, 225);
        colours.normalColor = colour;
        gameObject.GetComponent<Button>().colors = colours;
        scr_EventManager.eventManager.RunEvent(ID);
    }
}
