using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject DestroyerPoint; // Define Game object.

    void Start()
    {
        DestroyerPoint = GameObject.Find("DestroyerPoint");
        //When game start, find destroyer point which means tracking lower from the camera.
    }

    void Update()
    {
        if (transform.position.x < DestroyerPoint.transform.position.x)
        // If any platform has a lower vertical value from the lower limit of camera..
        {
            Destroy(gameObject); // Destroy the platform.
        }
    }
}
