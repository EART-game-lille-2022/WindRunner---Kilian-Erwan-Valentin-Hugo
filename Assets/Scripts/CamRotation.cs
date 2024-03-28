using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{
    public Transform pivotPoint;

    public float sensivity = 1;

    float distance = 10, targetDistance = 10, zoomVel;
    public float dampZoom = 1;

    // Update is called once per frame
    void Update()
    {
        // if(!Input.GetMouseButton(1)) return;

        // transform.RotateAround(pivotPoint.position, Vector3.up, Input.GetAxis("Mouse X"));

        Vector3 delta = transform.position - pivotPoint.position;
        // delta *= 1+Input.GetAxis("Mouse ScrollWheel");
        //if(delta.magnitude < 5 ) delta = delta.normalized * 5;
        targetDistance *= 1 + Input.GetAxis("Mouse ScrollWheel");
        if(targetDistance < 5) targetDistance = 5;
        if(targetDistance > 30) targetDistance = 30;

        distance = Mathf.SmoothDamp(distance, targetDistance, ref zoomVel, dampZoom);

        if (Input.GetMouseButton(1))
            delta = Quaternion.Euler(0, Input.GetAxis("Mouse X")* sensivity, 0) * delta;

        // delta += transform.up * Input.GetAxis("Mouse Y");

        transform.position = pivotPoint.position + delta.normalized * distance;

        if (Input.GetMouseButton(1))
            transform.RotateAround(pivotPoint.position, transform.right, -Input.GetAxis("Mouse Y") * sensivity);

        Vector3 pos = transform.position;
        if(pos.y < 2)
        {
            pos.y = 2;
            transform.position = pos;
        }
        if (pos.y > 9)
        {
            pos.y = 9;
            transform.position = pos;
        }
    }
}
