using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;


public class FlightController : MonoBehaviour {
    //public float minSpeed = 0;
    //public float maxSpeed = 1;
    //public float currentSpeed;

    Vector2 mousePos;
    Vector2 movement;

    public CharacterController charController;

    //public Vector2 turnSpeed;
    public GameObject center;

    //public float turnThreshold;
    //public float rotationSpeed;

    public Slider speedometer;
    //public float speedIncreaseStep;

    public FlightProfile[] profiles;
    public int profileIndex;

    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

    private void Start() {
        Debug.Log("w: " + Screen.width + ", h: " + Screen.height);
        //Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update() {
        //flight speed
        charController.Move(transform.forward * (profiles[profileIndex].currentSpeed / 5));

        //mouse X rotation
        float deltaX = (mousePos.x - (Screen.width / 2)) / profiles[profileIndex].turnThreshold;
        float deltaY = (mousePos.y - (Screen.height / 2)) / profiles[profileIndex].turnThreshold;
        Vector2 mouseDelta = new Vector2(deltaX, deltaY);

        //if (mouseDelta.magnitude > 5) {
        //    //mouseDelta = Vector2.ClampMagnitude(mouseDelta, turnThreshold);
        //    //Debug.Log(mouseDelta);
        //    Vector2 clampedPos = PositionOnCircleClamp(mouseDelta, 5f);
        //    //Debug.Log(clampedPos);
        //    SetCursorPos((int)clampedPos.x + (Screen.width / 2), (int)clampedPos.y + (Screen.height / 2));

        //    Debug.Log((int)clampedPos.x + (Screen.width / 2) + ", " + (int)clampedPos.y + (Screen.height / 2));
        //}
        transform.Rotate(Vector3.up, mouseDelta.x * profiles[profileIndex].turnSpeed.x * Time.deltaTime);

        //mouse Y rotation
        //Vector3 targetRotation = transform.eulerAngles;
        //targetRotation.x -= deltaY;
        //targetRotation.z = rotationSpeed * movement.x;
        //transform.eulerAngles = targetRotation;

        transform.Rotate(Vector3.left, mouseDelta.y * profiles[profileIndex].turnSpeed.y * Time.deltaTime);

        //WASD
        //A and D to rotate the plane
        transform.Rotate(Vector3.forward, profiles[profileIndex].rotationSpeed * movement.x * -1);

        //W and S to change speed
        if (movement.y != 0) {
            profiles[profileIndex].currentSpeed = (movement.y > 0) ? Mathf.Min(profiles[profileIndex].currentSpeed + profiles[profileIndex].speedIncreaseStep, profiles[profileIndex].maxSpeed) : Mathf.Max(profiles[profileIndex].currentSpeed - profiles[profileIndex].speedIncreaseStep, profiles[profileIndex].minSpeed);
            speedometer.value = profiles[profileIndex].currentSpeed / profiles[profileIndex].maxSpeed;
        }

    }

    public void OnMouseMove(Vector2 vec) {
        Vector2 temp = vec;
        //convert it into a delta from the center of the screen
        temp.x -= center.transform.position.x / 2;
        temp.y -= center.transform.position.y / 2;

        mousePos = vec;
    }

    public void OnWASD(Vector2 input) {
        movement = input;
    }

    private Vector2 PositionOnCircleClamp(Vector2 mouseDelta, float magnitude) {
        float angle = Mathf.Atan(mouseDelta.y / mouseDelta.x);

        float x = magnitude * Mathf.Cos(angle);
        float y = magnitude * Mathf.Sin(angle);

        return new Vector2(x, y);

    }
}
