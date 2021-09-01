using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPitchAttitudeActive : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 137.1f || transform.position.y <= -144f) {
            gameObject.SetActive(false);
        } else /*if(!gameObject.activeInHierarchy)*/ {
            gameObject.SetActive(true);
        }
    }
}
