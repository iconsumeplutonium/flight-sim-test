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


            //for (int i = 0; i < pitchAttitudes.Length; i++) {
            //    float angle = -40 + (10 * i);
            //    float transformedAngle = TransformAngle(angle, Camera.main.fieldOfView, 1f);
            //    pitchAttitudes[i].transform.position = new Vector3(Screen.width / 2f, (transformedAngle * offset) + Screen.height / 2, 0f);
            //}

            //Vector3 pos = Camera.main.WorldToScreenPoint(aircraft.transform.TransformDirection(aircraft.transform.forward * 292));
            //Vector3 pos1 = aircraft.transform.position;
            //pos1.z += 292;

            //pos.x = 0;
            //pos.y = 31f;
            //pos.z += 292f;

            //Vector3 pos = ProjectPointOnPlane(Vector3.up, Vector3.zero, transform.forward);
            //float pitch = SignedAngle(transform.forward, pos, transform.right);

            //pos = ProjectPointOnPlane(Vector3.up, Vector3.zero, transform.right);
            //float roll = SignedAngle(transform.right, pos * 2, transform.forward);

            //attitudeIndicatorPosition.transform.rotation = Quaternion.AngleAxis(roll, Vector3.forward);
            //attitudeIndicatorPosition.transform.position = new Vector3(attitudeIndicatorPosition.transform.position.x, pitch * -10 * Screen.height / 2, attitudeIndicatorPosition.transform.position.z);

            Vector3 pos = Camera.main.transform.TransformDirection(Vector3.forward * 300f);
            //pos.y = 31;
            //GameObject o = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //o.transform.position = pos;

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

}
