using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_MasterController : MonoBehaviour
{
    // Static reference
    public static scr_MasterController masterController;

    //=Scene tracking=//
    public enum Scenes
    {
        MAIN, EMAIL, COMMS
    }

    private bool isSceneLoaded;
    public bool getIsSceneLoaded() { return isSceneLoaded; }
    public void setIsSceneLoaded(bool setVal) { isSceneLoaded = setVal; }

    private Scenes currentScene;
    public Scenes getCurrentScene() { return currentScene; }
    public void setCurrentScene(Scenes setVal) { currentScene = setVal; }
    //================//

    //=Persistent Data=//
    private float elapsedTime;                  // Global timer
    public float getElapsedTime() { return elapsedTime; }
    public void changeElapsedTime(float setVal) { elapsedTime += setVal; }

    private const float endgameTime = 180.0f;  // End of game time value, 180 = 3 mins
    public float getEndgameTime() { return endgameTime; }

    private bool timerWarning = false;      // Two minutes until game over
    public bool getTimerWarning() { return timerWarning; }
    public void setTimerWarning(bool setVal) { timerWarning = setVal; }

    private bool gameOver = false;             // Game Over flag
    public bool getGameOver() { return gameOver; }
    public void setGameOver(bool setVal) { gameOver = setVal; }

    private bool healthUp = false;             // Health upgrade flag
    public bool getHealthUp() { return healthUp; }
    public void setHealthUp(bool setVal) { healthUp = setVal; }

    private int funds = 10;                          // Player money count
    public int getFunds() { return funds; }
    public void setFunds(int setVal) { funds = setVal; }
    public void changeFunds(int setVal) { funds += setVal; }

    private int gusMood;                        // Alien mood
    public int getGusMood() { return gusMood; }
    public void setGusMood(int setVal) { gusMood = setVal; }
    public void changeGusMood(int setVal)
    {
        gusMood += setVal;
        if (gusMood < -100)
            gusMood = -100;
        if (gusMood > 100)
            gusMood = 100;
    }

    private int gusHealth;                      // Alien health status
    public int getGusHealth() { return gusHealth; }
    public void setGusHealth(int setVal) { gusHealth = setVal; }
    public void changeGusHealth(int setVal)
    {
        gusHealth += setVal;
        if (gusHealth < -100)
            gusHealth = -100;
        if (gusHealth > 100)
            gusHealth = 100;
    }
    //=================//

    private void Awake()
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

    private float warningThreshhold = endgameTime - 60.0f;
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        //Debug.Log("Timer = " + elapsedTime);

        if (elapsedTime >= warningThreshhold)
            timerWarning = true;

        if (elapsedTime >= endgameTime)
            gameOver = true;
    }
}