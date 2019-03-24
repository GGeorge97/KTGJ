using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_Resource : MonoBehaviour
{
    // Variables 
    private float resourceScale = 100.0f;
    public float getResouceScale() { return resourceScale; }
    public void setResourceScale(float setVal) { resourceScale = setVal; }

    private float delay;
    public float getDelay() { return delay; }
    public void setDelay(float setVal) { delay = setVal; }

    private float resourseValue = 1.0f;
    public float getResourceValue() { return resourseValue; }
    public void setRescourceValue(float setVal) { resourseValue = setVal; }

    private float decayModifier = 1.0f;
    public float getDecayModifier() { return decayModifier; }
    public void setDecayModifier(float setVal) { decayModifier = setVal; }

    public void UpdateValues()
    {
        if (resourceScale >= 0.0f)
        {
            resourceScale += Time.deltaTime * -(decayModifier);
            //Debug.Log("Resource: " + resourceScale);
        }
        else
        {
            Debug.Log("Gus mad");
        }

        if (delay >= 0.0f)
        {
            delay -= Time.deltaTime;
        }
    }

    public void AddResourceValue()
    {
        resourceScale += resourseValue;

        delay = 3.0f;
    }
}
