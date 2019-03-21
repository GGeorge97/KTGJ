using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_MasterController : MonoBehaviour
{
    // Static reference
    public static scr_MasterController masterController;

    //=Persistent Data=
    private float elapsedTime;                  // Global timer
    public float getElapsedTime() { return elapsedTime; }

    private string[] gameClock;                 // Simulation clock
    public string getGameClock(int i) { return gameClock[i]; }

    private const float endgameTime = 5000.0f;  // End of game time value
    public float getEndgameTime() { return endgameTime; }

    private int funds;                          // Player money count
    public int getFunds() { return funds; }
    public void setFunds(int setVal) { funds = setVal; }

    private int gusMood;                        // Alien mood
    public int getGusMood() { return gusMood; }
    public void setGusMood(int setVal) { gusMood = setVal; }

    private int gusHealth;                      // Alien health status
    public int getGusHealth() { return gusHealth; }
    public void setGusHealth(int setVal) { gusHealth = setVal; }
    //=================

    void Awake()
    {
        if (masterController == null)
        {
            DontDestroyOnLoad(gameObject);
            masterController = this;
        }
        else if (masterController != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        //Debug.Log("Timer = " + elapsedTime);
    }
}