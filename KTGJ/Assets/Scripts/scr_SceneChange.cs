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

    void Start()
    {
        if (isUnloader)
            gameObject.GetComponent<Button>().onClick.AddListener(Unload);
        else
            gameObject.GetComponent<Button>().onClick.AddListener(SceneTransition);
    }

    void SceneTransition()
    {
        if (transitionAnimation)
        {
            scr_SceneDirector.animator.Play(transitionAnimation.name);
            StartCoroutine(TransitionScene(transitionAnimation));
        }
        else
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }

    void Unload()
    {
        if (transitionAnimation)
        {
            scr_SceneDirector.animator.Play(transitionAnimation.name);
            StartCoroutine(TransitionScene(transitionAnimation));
        }
        else
            SceneManager.UnloadSceneAsync(scene);
    }

    private IEnumerator TransitionScene(AnimationClip animation)
    {
        yield return new WaitForSeconds(transitionAnimation.length);
        if(isUnloader)
            SceneManager.UnloadSceneAsync(scene);
        else
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }
}
