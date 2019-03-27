using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_SceneChange : MonoBehaviour
{
    public bool isUnloader = false;
    public string scene = "sce_Main";
    public AnimationClip transitionAnimation;
    private AudioSource audioClip;

    void Start()
    {
        audioClip = gameObject.GetComponent<AudioSource>();
        if (isUnloader)
            gameObject.GetComponent<Button>().onClick.AddListener(Unload);
        else
            gameObject.GetComponent<Button>().onClick.AddListener(SceneTransition);
    }

    void SceneTransition()
    {
        audioClip.Play();
        if (transitionAnimation)
        {
            scr_SceneDirector.animator.Play(transitionAnimation.name);
            StartCoroutine(TransitionScene(transitionAnimation));
        }
        else
        {
            if (scene == "sce_EmailPanel")
            {
                scr_EventManager.eventManager.setIsNotified(false);
                scr_MasterController.masterController.setCurrentScene(scr_MasterController.Scenes.EMAIL);
            }
            else if (scene == "sce_ComPanel")
                scr_MasterController.masterController.setCurrentScene(scr_MasterController.Scenes.COMMS);

            if (!scr_MasterController.masterController.getIsSceneLoaded())
            {
                SceneManager.LoadScene(scene, LoadSceneMode.Additive);
                scr_MasterController.masterController.setIsSceneLoaded(true);
            }
        }
    }

    void Unload()
    {
        if (transitionAnimation)
        {
            scr_SceneDirector.animator.Play(transitionAnimation.name);
            StartCoroutine(TransitionScene(transitionAnimation));
        }
        else
        {
            scr_MasterController.masterController.setCurrentScene(scr_MasterController.Scenes.MAIN);
            scr_MasterController.masterController.setIsSceneLoaded(false);
            scr_EventManager.eventManager.resetScrollUPindex();
            scr_EventManager.eventManager.resetScrollDOWNindex();
            SceneManager.UnloadSceneAsync(scene);
        }
    }

    private IEnumerator TransitionScene(AnimationClip animation)
    {
        yield return new WaitForSeconds(transitionAnimation.length);
        if (isUnloader)
        {
            scr_MasterController.masterController.setCurrentScene(scr_MasterController.Scenes.MAIN);
            scr_MasterController.masterController.setIsSceneLoaded(false);
            scr_EventManager.eventManager.resetScrollUPindex();
            scr_EventManager.eventManager.resetScrollDOWNindex();
            SceneManager.UnloadSceneAsync(scene);
        }
        else
        {
            if (scene == "sce_EmailPanel")
            {
                scr_EventManager.eventManager.setIsNotified(false);
                scr_MasterController.masterController.setCurrentScene(scr_MasterController.Scenes.EMAIL);
            }
            else if (scene == "sce_ComPanel")
                scr_MasterController.masterController.setCurrentScene(scr_MasterController.Scenes.COMMS);

            if (!scr_MasterController.masterController.getIsSceneLoaded())
            {
                SceneManager.LoadScene(scene, LoadSceneMode.Additive);
                scr_MasterController.masterController.setIsSceneLoaded(true);
            }
        }
    }
}
