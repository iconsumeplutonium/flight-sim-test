using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Altimeter : MonoBehaviour {

    GameObject aircraft;
    public Slider altimeter;
    public TMP_Text altitudeText;

    private void Start() {
        aircraft = GameObject.FindGameObjectWithTag("Frederick");
    }

    private void Update() {
        altimeter.value = Mathf.Max(Mathf.Min(aircraft.transform.position.y, altimeter.maxValue), altimeter.minValue);
        altitudeText.text = Mathf.RoundToInt(aircraft.transform.position.y * 50) + " meters";
    }

}
