using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightProfile : MonoBehaviour
{
    public float minSpeed = 0;
    public float maxSpeed = 1;
    public float currentSpeed;

    public Vector2 turnSpeed;

    public float turnThreshold;
    public float rotationSpeed;

    public float speedIncreaseStep;
}
