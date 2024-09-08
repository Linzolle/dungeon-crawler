using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public KeyCode forward = KeyCode.UpArrow;
    public KeyCode backward = KeyCode.DownArrow;
    public KeyCode turnLeft = KeyCode.LeftArrow;
    public KeyCode turnRight = KeyCode.RightArrow;

    PlayerController controller;

    void Start() {
        controller = GetComponent<PlayerController>();
    }

    void Update() {
        if (Input.GetKey(forward)) { controller.MoveForward(); }
        if (Input.GetKey(backward)) { controller.MoveBackward(); }
        if (Input.GetKey(turnLeft)) { controller.TurnLeft(); }
        if (Input.GetKey(turnRight)) { controller.TurnRight(); }
    }
}
