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

    private string[] gameClock;                 // Simulation clock
    public string getGameClock(int i) { return gameClock[i]; }

    private const float endgameTime = 300.0f;  // End of game time value, 300 = 5 mins
    public float getEndgameTime() { return endgameTime; }

    private bool timerWarning = false;      // Two minutes until game over
    public bool getTimerWarning() { return timerWarning; }
    public void setTimerWarning(bool setVal) { timerWarning = setVal; }

    private bool gameOver = false;             // Game Over flag
    public bool getGameOver() { return gameOver; }
    public void setGameOver(bool setVal) { gameOver = setVal; }

    private int funds;                          // Player money count
    public int getFunds() { return funds; }
    public void setFunds(int setVal) { funds = setVal; }

    private int gusMood;                        // Alien mood
    public int getGusMood() { return gusMood; }
    public void setGusMood(int setVal) { gusMood = setVal; }

    private int gusHealth;                      // Alien health status
    public int getGusHealth() { return gusHealth; }
    public void setGusHealth(int setVal) { gusHealth = setVal; }
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

    private float warningThreshhold = endgameTime - (endgameTime / 25.0f);
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