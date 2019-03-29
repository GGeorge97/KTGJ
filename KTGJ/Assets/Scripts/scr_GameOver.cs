using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class scr_GameOver : MonoBehaviour
{
    private Text[] textContainers;
    public GameObject clipNegative;
    public GameObject clipNetural;
    public GameObject clipPositive;

    void Awake()
    {
        textContainers = gameObject.GetComponentsInChildren<Text>();

        if (scr_MasterController.masterController.getGusMood() < -75)
        {
            clipNetural.SetActive(false);
            clipPositive.SetActive(false);
            textContainers[0].text = "Upon arriving to Earth the alien fleet found their friend was highly distressed and angry.\n Because of this, they have torched half of planet Earth.";
        }
        else if (scr_MasterController.masterController.getGusMood() < 50)
        {
            clipNegative.SetActive(false);
            clipPositive.SetActive(false);
            textContainers[0].text = "The aliens landed to rescue their friend and shortly after leaving you weigh the consequences of your decisions.\n Could more people have been saved?";
        }
        else if (scr_MasterController.masterController.getGusMood() >= 50)
        {
            clipNegative.SetActive(false);
            clipNetural.SetActive(false);
            textContainers[0].text = "You have successfully befriended humanities first extra-terrestrial contact.\n The aliens and humans will work together to better each other in a new space age.";
        }

        textContainers[1].text = "You chose to:";
        for (int i = 0; i < scr_EventManager.eventList.Count; i++)
        {
            if(scr_EventManager.eventList[i].getType() == scr_Event.EmailType.CHOICE && scr_EventManager.eventList[i].getStatus() == scr_Event.Status.ACCEPTED)
                textContainers[1].text += scr_EventManager.eventList[i].getResult();
        }
    }
}
