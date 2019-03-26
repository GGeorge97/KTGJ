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

    private float maxVal;
    private float speed;

    private void Start()
    {
        resource = this.GetComponent<scr_Resource>();

        button.onClick.AddListener(OnClick);

        maxVal = 100.0f;
        resource.setResourceScale(maxVal);
        resource.setRescourceValue(25.0f);
        resource.setDelay(2.5f);

        // Get the speed of the needle based of 180 degrees over the time/scale of the pressure bar
        speed = 180 / resource.getResourceScale();
    }

    private void Update()
    { 
        resource.UpdateValues();
        UpdatePressure();
    }

    private void OnClick()
    {
        // Check if the cooldown of the lever is ready
        if (resource.getDelay() <= 0.0f)
        {
            // Add the resource value to the time/scale of the pressure bar
            resource.AddResourceValue();
            if (resource.getResourceScale() >= maxVal)
            {
                // Clamp to max value if greater 
                // Also clamp the needle to the max pressure value 
                resource.setResourceScale(maxVal);
                pressureNeedle.transform.rotation = Quaternion.AngleAxis(0.0f, new Vector3(0.0f, 0.0f, 1.0f));
            }
            else
            {
                // Calculate the precentage of the added time/scale over 180 
                // Then rotate the needle to the correct added value
                float percentage = ((180 * resource.getResourceScale()) / 100);
                pressureNeedle.transform.eulerAngles = new Vector3(0.0f, 0.0f, (percentage - 180));
            }
        }
    }

    private void UpdatePressure()
    {
        // Keep the pressure needle rotating until -180
        if (pressureNeedle.transform.rotation != Quaternion.Euler(0.0f, 0.0f, -180.0f))
        {
            pressureNeedle.transform.Rotate(0.0f, 0.0f, -speed * Time.deltaTime);
        }
    }
}

