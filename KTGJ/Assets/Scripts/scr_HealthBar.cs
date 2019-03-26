using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class scr_HealthBar : MonoBehaviour
{
    private scr_Resource resource; 

    [SerializeField]
    private Button button;
    [SerializeField]
    private Sprite fullHealth;
    [SerializeField]
    private Sprite halfHealth;
    [SerializeField]
    private Sprite blank; 
    [SerializeField]
    private Image[] healthBar = new Image[3];

    private float percentage = 0.0f; 

    private void Start()
    {
        // Find resource class refenece 
        resource = this.GetComponent<scr_Resource>();
        healthBar[0] = GameObject.Find("Health1").GetComponent<Image>(); 
        healthBar[1] = GameObject.Find("Health2").GetComponent<Image>();
        healthBar[2] = GameObject.Find("Health3").GetComponent<Image>();

        button.onClick.AddListener(OnClick);

        //Testing values 
        resource.setResourceScale(100.0f);
        resource.setDecayModifier(5.0f);
        resource.setRescourceValue(16.6f);
        resource.setDelay(5.0f);

        percentage = resource.getResourceScale() / (healthBar.Length * 2);
    }

    private void Update()
    {
        resource.UpdateValues();
        UpdateHealth();
        //Debug.Log(resource.getResouceScale());
    }

    private void OnClick()
    {
        // Delay stops the player from spawning the button to bring gus to full health/pressure/etc.
        if (resource.getDelay() <= 0.0f)
        {
            resource.AddResourceValue();
        }
    }

    // Update health bar 
    private void UpdateHealth()
    {
        // Need to change from hardcoded (temp)
        if (resource.getResourceScale() >= (percentage * 5) && resource.getResourceScale() <= (percentage * 6))
        {
            healthBar[2].sprite = fullHealth;
        }
        else if (resource.getResourceScale() >= (percentage * 4) && resource.getResourceScale() <= (percentage * 5))
        {
            healthBar[2].sprite = halfHealth; 
        }
        else if (resource.getResourceScale() >= (percentage * 3) && resource.getResourceScale() <= (percentage * 4))
        {
            healthBar[2].sprite = blank;
            healthBar[1].sprite = fullHealth;
        }
        else if (resource.getResourceScale() >= (percentage * 2) && resource.getResourceScale() <= (percentage * 3))
        {
            healthBar[1].sprite = halfHealth;
        }
        else if (resource.getResourceScale() >= (percentage) && resource.getResourceScale() <= (percentage * 2))
        {
            healthBar[1].sprite = blank;
            healthBar[0].sprite = fullHealth;
        }
        else if (resource.getResourceScale() >= 0.0f && resource.getResourceScale() <= (percentage))
        {
            healthBar[0].sprite = halfHealth; 
        }
        else if (resource.getResourceScale() <= 0.0f)
        {
            healthBar[0].sprite = blank;
        }
    }
}
