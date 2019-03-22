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
        TrackCurrentScene();

        if (!animator)
            animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        TrackCurrentScene();
    }

    private void TrackCurrentScene()
    {
        bool loadState = scr_MasterController.masterController.getIsSceneLoaded();
        if (!loadState)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("sce_Main"));
        }
        else
        {
            switch (scr_MasterController.masterController.getCurrentScene())
            {
                case (scr_MasterController.Scenes.EMAIL):
                    if (loadState)
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName("sce_EmailPanel"));
                    break;

                case (scr_MasterController.Scenes.COMMS):
                    if (loadState)
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName("sce_ComPanel"));
                    break;

                default:
                    break;
            }
        }
    }
}
