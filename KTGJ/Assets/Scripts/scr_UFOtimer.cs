using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_UFOtimer : MonoBehaviour
{
    private Vector3 start;
    private Vector3 end;
    private float time;
    private float t_move;

    void Start()
    {
        start = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        end = new Vector3(gameObject.transform.position.x - 100.0f, gameObject.transform.position.y, gameObject.transform.position.z);
        time = (float)scr_MasterController.masterController.getEndgameTime();
    }

    void Update()
    {
        t_move += Time.deltaTime / time;
        gameObject.transform.position = Vector3.Lerp(start, end, t_move);
    }
}
