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

    public RectTransform aircraftSymbol;

    public GameObject attitudeNeedle;

    private void Update() {
        //Altimeter
        altimeter.value = Mathf.Max(Mathf.Min(aircraft.transform.position.y, altimeter.maxValue), altimeter.minValue);
        altitudeText.text = Mathf.RoundToInt(aircraft.transform.position.y * 50) + " feet";

        //Rotate attitude indicator (yellow line)
        float zRot = aircraft.transform.eulerAngles.z;
        Vector3 angles = aircraftSymbol.transform.localEulerAngles;
        angles.z = -zRot;
        aircraftSymbol.transform.localEulerAngles = angles;

        //rotate attitude indicator
        //float xRot = aircraft.transform.eulerAngles.x;
        //Vector3 angles1 = attitudeNeedle.transform.eulerAngles;

        //if (xRot < -180)
        //    xRot += 180;

        //angles1.z = xRot;

        float xRot = aircraft.transform.eulerAngles.x;
        Vector3 angles1 = attitudeNeedle.transform.localEulerAngles;

        angles1.z = xRot * 2;


        attitudeNeedle.transform.localEulerAngles = angles1;

    }

    /*
     * line that moves with horizon code
     * 
     *             Vector3 pos = Camera.main.transform.TransformDirection(Vector3.forward * 300f);
            pos = Camera.main.WorldToScreenPoint(new Vector3(Screen.width / 2, 31f, pos.z));

    apply pos to the rectransform
     * 
     */



}
