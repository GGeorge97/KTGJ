using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class scr_Intro : MonoBehaviour
{
    private double time;
    private double currentTime;
    private VideoPlayer vP;

    void Start()
    {
        vP = gameObject.GetComponent<VideoPlayer>();
        time = vP.clip.length - 0.1;
    }

    void Update()
    {
        currentTime = vP.time;
        if (currentTime >= time)
        {
            SceneManager.LoadScene("sce_Main", LoadSceneMode.Single);
        }
    }
}
