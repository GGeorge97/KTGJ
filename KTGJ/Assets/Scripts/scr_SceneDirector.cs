using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_SceneDirector : MonoBehaviour
{
    // Static references
    public static Animator animator;

    void Start()
    {
        //TrackCurrentScene();

        if (!animator)
            animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {

        if (!animator)
            animator = gameObject.GetComponent<Animator>();

        if (scr_MasterController.masterController.getGameOver())
            SceneManager.LoadScene("sce_End", LoadSceneMode.Single);
        //TrackCurrentScene();
    }

    private void TrackCurrentScene()
    {
        bool loadState = scr_MasterController.masterController.getIsSceneLoaded();
        if (!loadState)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("sce_Main"));
            animator = gameObject.GetComponent<Animator>();
        }
        else
        {
            switch (scr_MasterController.masterController.getCurrentScene())
            {
                case (scr_MasterController.Scenes.EMAIL):
                    if (loadState)
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName("sce_EmailPanel"));
                    animator = gameObject.GetComponent<Animator>();
                    break;

                case (scr_MasterController.Scenes.COMMS):
                    if (loadState)
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName("sce_ComPanel"));
                    animator = gameObject.GetComponent<Animator>();
                    break;

                default:
                    break;
            }
        }
    }
}
