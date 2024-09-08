using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 360f;

    Vector3 targetPos;
    Vector3 prevTargetPos;
    Vector3 targetRotation;

    void Start() {
        targetPos = transform.position;
    }

    void FixedUpdate() {
        Move();
        DrawDebug();
    }

    void Move() {
        if (targetRotation.y > 270f && targetRotation.y < 361f) targetRotation.y = 0f;
        if (targetRotation.y < 0f) targetRotation.y = 270;

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime);
    }

    public void MoveForward() { if (AtRest && !Physics.Raycast(transform.position, transform.forward, 1f)) targetPos += transform.forward; }
    public void MoveBackward() { if (AtRest && !Physics.Raycast(transform.position, transform.forward * -1, 1f)) targetPos -= transform.forward; }
    public void TurnLeft() { if (AtRest) targetRotation -= Vector3.up * 90f; }
    public void TurnRight() { if (AtRest) targetRotation += Vector3.up * 90f; }


    bool AtRest {
        get {
            if ((Vector3.Distance(transform.position, targetPos) < 0.05f) && (Vector3.Distance(transform.eulerAngles, targetRotation) < 0.05f)) return true;
            else return false;
        }
    }

    void DrawDebug()  {
        Color color;
        if (Physics.Raycast(transform.position, transform.forward, 1f)) {
            color = Color.red;
        } else {
            color = Color.green;
        }
        Debug.DrawRay(transform.position, transform.forward, color);

        if (Physics.Raycast(transform.position, transform.forward * -1f, 1f)) {
            color = Color.red;
        } else {
            color = Color.green;
        }
        Debug.DrawRay(transform.position, transform.forward * -1f, color);
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, new Vector3(0.5f,0.5f,0.5f));
        Gizmos.DrawWireCube(transform.position + transform.forward*0.25f, new Vector3(0.2f,0.2f,0.2f));
    }
}
