using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Instruments : MonoBehaviour {

    public GameObject aircraft;

    public Slider altimeter;
    public TMP_Text altitudeText;

    public GameObject attitudeIndicatorRotation;
    public GameObject attitudeIndicatorPosition;
    public GameObject[] pitchAttitudes;

    public float hypotenuse;
    public bool testmovement;

    private void Start() {
        //aircraft = GameObject.FindGameObjectWithTag("Frederick");
    }

    private void Update() {
        //Altimeter
        altimeter.value = Mathf.Max(Mathf.Min(aircraft.transform.position.y, altimeter.maxValue), altimeter.minValue);
        altitudeText.text = Mathf.RoundToInt(aircraft.transform.position.y * 50) + " feet";

        //Rotate attitude indicator
        float zRot = aircraft.transform.eulerAngles.z;
        Vector3 angles = attitudeIndicatorRotation.transform.eulerAngles;
        angles.z = -zRot;
        attitudeIndicatorRotation.transform.eulerAngles = angles;

        if (testmovement) {
            //move attitude indicator up and down
            float xRot = aircraft.transform.eulerAngles.x;
            //Debug.Log(xRot);
            /*
             *  |----------------------
             *  |          ___----[plane]
             *  |    ___---
             *  |_---
             */
            //use the trig and the angle it looks down by to get the distance
            float dist = Mathf.Sin(xRot) * hypotenuse;
            float dist1 = Vector3.Dot(transform.up, aircraft.transform.eulerAngles);
            float asdf = ((xRot / 360f) * 500) + 200;
            attitudeIndicatorPosition.transform.position = new Vector3(400, dist1, 0f);
            //Debug.Log(dist);

            //foreach (var attitude in pitchAttitudes) {
            //    attitude.transform.position += new Vector3(0, dist, 0f);
            //    Debug.Log(new Vector3(0f, xRot, 0f));
            //}
        }

        //enable or disable pitch attitudes
        //foreach (var attitude in pitchAttitudes) {
        //    if (attitude.transform.position.y >= 137.1f || attitude.transform.position.y <= -144f) {
        //        attitude.SetActive(false);
        //    }
        //    else /*if(!gameObject.activeInHierarchy)*/ {
        //        attitude.SetActive(true);
        //    }
        //}
    }

}
