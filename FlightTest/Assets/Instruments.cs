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

    float lowest, highest;

    private void Start() {
        lowest = int.MaxValue;
        highest = int.MinValue;
    }

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

        var pos = ProjectPointOnPlane(Vector3.up, Vector3.zero, aircraft.transform.forward);
        float pitch = SignedAngle(transform.forward, pos, transform.right);

        float xRot = aircraft.transform.eulerAngles.x;
        Vector3 angles1 = attitudeNeedle.transform.localEulerAngles;

        angles1.z = xRot;//(-xRot + 90f) * 2f;//NormalizeAngle(xRot, 0f, 360f);
        if (xRot < lowest)
            lowest = xRot;

        if (xRot > highest)
            highest = xRot;

        angles1.z += xRot;

        angles1.z = angles1.z % 360;

        if (angles1.z < 0) {
            angles1.z += 360 + 180;
        }


        attitudeNeedle.transform.localEulerAngles = angles1;

        Debug.Log("lowest: " + lowest + ", highest: " + highest + ", current: " + angles1.z);
    }

    /*
     * line that moves with horizon code shit
     * 
     *             Vector3 pos = Camera.main.transform.TransformDirection(Vector3.forward * 300f);
            pos = Camera.main.WorldToScreenPoint(new Vector3(Screen.width / 2, 31f, pos.z));

    apply pos to the rectransform
     * 
     */


    public float SignedAngle(Vector3 v1, Vector3 v2, Vector3 normal) {
        var perp = Vector3.Cross(normal, v1);
        var angle = Vector3.Angle(v1, v2);
        angle *= Mathf.Sign(Vector3.Dot(perp, v2));
        return angle;
    }

    public Vector3 ProjectPointOnPlane(Vector3 planeNormal, Vector3 planePoint, Vector3 point) {
        planeNormal.Normalize();
        var distance = -Vector3.Dot(planeNormal.normalized, (point - planePoint));
        return point + planeNormal * distance;
    }
    private static float UnwrapAngle(float angle) {
        if (angle >= 0)
            return angle;

        angle = -angle % 360;

        return 360 - angle;
    }

    float NormalizeAngle(float value, float start, float end) 
    {
      float width = end - start;   // 
      float offsetValue = value - start;   // value relative to 0

      return (offsetValue - (Mathf.Floor(offsetValue / width ) * width ) ) + start ;
      // + start to reset back to start of original range
    }


}
