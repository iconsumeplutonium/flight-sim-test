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
    public RectTransform attitudeIndicatorPosition;
    public GameObject[] pitchAttitudes;

    public GameObject horizon;

    public float hypotenuse;
    public bool testmovement;

    public float offset;

    private void Start() {
        //aircraft = GameObject.FindGameObjectWithTag("Frederick");
        Debug.Log(attitudeIndicatorPosition.transform.position.y);
    }

    private void Update() {
        //Altimeter
        altimeter.value = Mathf.Max(Mathf.Min(aircraft.transform.position.y, altimeter.maxValue), altimeter.minValue);
        altitudeText.text = Mathf.RoundToInt(aircraft.transform.position.y * 50) + " feet";

        //Rotate attitude indicator
        float zRot = aircraft.transform.eulerAngles.z;
        Vector3 angles = aircraftSymbol.transform.localEulerAngles;
        angles.z = -zRot;
        aircraftSymbol.transform.localEulerAngles = angles;

        if (testmovement) {
            
            Vector3 pos = Camera.main.transform.TransformDirection(Vector3.forward * 300f);
            pos = Camera.main.WorldToScreenPoint(new Vector3(Screen.width / 2, 31f, pos.z));

            attitudeIndicatorPosition.transform.position = pos;

        }



    }

}
