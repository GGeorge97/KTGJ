using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class scr_PressureBar : MonoBehaviour
{
    private scr_Resource resource;

    [SerializeField]
    private Button button;
    [SerializeField]
    private Image pressureNeedle;

    private float start = 45.0f;
    private float end = -135.0f; 
    private float scale;

    private void Start()
    {
        resource = this.GetComponent<scr_Resource>();

        button.onClick.AddListener(OnClick);

        resource.setResourceScale(100.0f);
        resource.setDecayModifier(5.0f);
        resource.setRescourceValue(25.0f);
        resource.setDelay(2.5f);
    }

    private void Update()
    {
        // speed of needle over duration (Need to slightly fix a bit)
        scale = 180 / resource.getResouceScale();
        resource.UpdateValues();
        UpdatePressure();
        //Debug.Log(resource.getResourceScale());
    }

    private void OnClick()
    {
        if (resource.getDelay() <= 0.0f)
        {
            resource.AddResourceValue();
            if (resource.getResourceValue() + resource.getResouceScale() >= 100.0f)
            {
                pressureNeedle.transform.rotation = Quaternion.AngleAxis(45.0f, new Vector3(0.0f, 0.0f, 45.0f));
            }
            else
            {
                pressureNeedle.transform.Rotate(0.0f, 0.0f, resource.getResourceValue());
            }
        }
    }

    private void UpdatePressure()
    {
        if (resource.getResouceScale() >= 0.0f)
        {
            pressureNeedle.transform.Rotate(0.0f, 0.0f, -scale * Time.deltaTime);
        }
    }
}

