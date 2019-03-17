using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class scr_MasterController : MonoBehaviour
{
    // Static reference
    public static scr_MasterController masterController;

    //=Persistent Data=
    private const float endgameTime = 5000.0f;
    private float elapsedTime;
    public float getElapsedTime() { return elapsedTime; }
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
    }
}