using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Controls controls;

    Vector2 mouseInput;
    Vector2 movement;
    public FlightController fc;

    private void Awake() {
        controls = new Controls();
    }

    private void Start() {
        controls.Flight.Enable();

        controls.Flight.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        controls.Flight.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

        controls.Flight.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();
        controls.Flight.Move.canceled += ctx => movement = ctx.ReadValue<Vector2>();
    }

    private void Update() {
        fc.OnMouseMove(mouseInput);
        fc.OnWASD(movement);
    }
}
