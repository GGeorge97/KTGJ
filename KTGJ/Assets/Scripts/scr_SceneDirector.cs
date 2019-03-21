using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SceneDirector : MonoBehaviour
{
    // Static references
    public static Animator animator;

    void Awake()
    {
        if(!animator)
            animator = gameObject.GetComponent<Animator>();
    }
}
