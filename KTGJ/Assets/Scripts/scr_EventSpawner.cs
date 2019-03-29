using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EventSpawner : MonoBehaviour
{
    private float timer;
    private float timeUntilNextEvent = 20.0f;

    private float timerSpam;
    private float timeUntilNextSpam = 25.0f;

    void Update()
    {

        timerSpam += Time.deltaTime;
        if (timerSpam >= timeUntilNextSpam)
        {
            Random.InitState(System.Environment.TickCount);
            int rand = Random.Range(2, 5);
            timerSpam = 0.0f;
            timeUntilNextSpam = 3.0f * rand;
            scr_EventManager.eventManager.CreateEmailEvent(scr_Event.EmailType.SPAM);
        }

        timer += Time.deltaTime;
        if (timer >= timeUntilNextEvent)
        {
            Random.InitState(System.Environment.TickCount);
            int rand = Random.Range(1, 2);
            switch (rand)
            {
                case 1:
                    timer = 0.0f;
                    timeUntilNextEvent = 30.0f;
                    scr_EventManager.eventManager.CreateEmailEvent(scr_Event.EmailType.CHOICE);
                    break;

                case 2:
                    // Comm event
                    break;
            }
        }
    }
}
