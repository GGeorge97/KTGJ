using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_PlayAgain : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(PlayAgain);
    }

    void PlayAgain()
    {
        Destroy(GameObject.FindGameObjectWithTag("MasterController"));
        SceneManager.LoadScene("sce_Intro");
    }
}
