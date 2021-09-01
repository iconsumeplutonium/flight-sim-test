using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Instruments : MonoBehaviour {

    public GameObject aircraft;

    public Slider altimeter;
    public TMP_Text altitudeText;

    public GameObject attitudeIndicatorRotation;
    public GameObject attitudeIndicatorPosition;
    public GameObject[] pitchAttitudes;

    public GameObject horizon;

    public float hypotenuse;
    public bool testmovement;

    public float offset;

    private void Start() {
        //aircraft = GameObject.FindGameObjectWithTag("Frederick");
    }

    private void Update() {
        //Altimeter
        altimeter.value = Mathf.Max(Mathf.Min(aircraft.transform.position.y, altimeter.maxValue), altimeter.minValue);
        altitudeText.text = Mathf.RoundToInt(aircraft.transform.position.y * 50) + " feet";

        //Rotate attitude indicator
        float zRot = aircraft.transform.eulerAngles.z;
        Vector3 angles = attitudeIndicatorRotation.transform.localEulerAngles;
        angles.z = -zRot;
        attitudeIndicatorRotation.transform.localEulerAngles = angles;

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
            //attitudeIndicatorPosition.transform.position = new Vector3(400, dist1, 0f);
            //Debug.Log(dist);


            //for (int i = 0; i < pitchAttitudes.Length; i++) {
            //    float angle = -40 + (10 * i);
            //    float transformedAngle = TransformAngle(angle, Camera.main.fieldOfView, 1f);
            //    pitchAttitudes[i].transform.position = new Vector3(Screen.width / 2f, (transformedAngle * offset) + Screen.height / 2, 0f);
            //}

            Vector3 pos = Camera.main.WorldToScreenPoint(aircraft.transform.TransformDirection(aircraft.transform.forward * 292));
            //Vector3 pos1 = aircraft.transform.position;
            //pos1.z += 292;

            //pos.x = 0;
            //pos.y = 31f;
            pos.z += 292f;

            pitchAttitudes[4].transform.position = pos;
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

    public float TransformAngle(float angle, float fov, float pixelHeight) {
        return (Mathf.Tan(angle) / Mathf.Tan(fov / 2)) * pixelHeight / 2;
    }

}
