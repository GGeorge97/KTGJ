using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_CloseEmail : MonoBehaviour
{
    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(CloseEmail);
    }

    private void CloseEmail()
    {
        Destroy(transform.parent.gameObject);
    }
}
