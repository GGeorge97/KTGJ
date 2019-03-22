using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class scr_ResourceBar : MonoBehaviour
{
    [SerializeField]
    private Button button;

    // Stat variables 
    private float resourceScale = 1.0f;
    private float delay;
    [SerializeField]
    private float resourceValue = 0.1f;
    private float decayModifier = 0.1f; 

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    private void Update()
    {
        // Decay of resource
        if (resourceScale >= 0.0f)
        {
            resourceScale += Time.deltaTime * -(decayModifier);
            Debug.Log("Resource: " + resourceScale);
        }
        else
        {
            Debug.Log("Gus dead");
        }

        // Cooldown of button
        if (delay >= 0.0f)
        {
            delay -= Time.deltaTime;
        }
    }

    private void OnClick()
    {
        // Delay stops the player from spawning the button to bring gus to full health/pressure/etc.
        if (delay <= 0.0f)
        {
            resourceScale += resourceValue;

            delay = 3.0f; 
        }
    }
}
