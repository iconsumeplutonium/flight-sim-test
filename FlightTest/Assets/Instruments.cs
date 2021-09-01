using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Instruments : MonoBehaviour {

    public GameObject aircraft;

    public Slider altimeter;
    public TMP_Text altitudeText;

    public GameObject attitudeIndicator;
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
        Vector3 angles = attitudeIndicator.transform.eulerAngles;
        angles.z = -zRot;
        attitudeIndicator.transform.eulerAngles = angles;

        if (testmovement) {
            //move attitude indicator up and down
            float xRot = aircraft.transform.eulerAngles.x;
            /*
             *  |----------------------
             *  |          ___----[plane]
             *  |    ___---
             *  |_---
             */
            //use the trig and the angle it looks down by to get the distance
            float dist = Mathf.Sin(xRot) * hypotenuse;

            foreach (var attitude in pitchAttitudes) {
                attitude.transform.position += new Vector3(0, dist, 0f);
                Debug.Log(new Vector3(0f, xRot, 0f));
            }
        }
    }

}
