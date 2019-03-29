using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Gus : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        float mood = scr_MasterController.masterController.getGusMood();

        if (mood >= 50 && mood <= 100)
        {
            animator.Play("GusHappy");
        }
        if (mood >= -10 && mood < 50)
        {
            animator.Play("GusIdle");
        }
        if (mood >= -25 && mood < -10)
        {
            animator.Play("GusSad");
        }
        if (mood >= -75 && mood < -25)
        {
            animator.Play("GusTired");
        }
        if (mood >= -100 && mood < -75)
        {
            animator.Play("GusAngry");
        }
    }
}
