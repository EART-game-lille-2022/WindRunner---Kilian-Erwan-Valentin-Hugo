using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamRotation : MonoBehaviour
{
    public Transform pivotPoint;

    public float sensivity = 1;

    private float distance = 5, targetDistance = 10, zoomVel;
    public float dampZoom = 1;
    private Vector2 _rotateAxis, _zoomAxis;

    private void Start()
    {
        distance = 5;
    }

    private void Update()
    {
        Vector3 delta = transform.position - pivotPoint.position;
        targetDistance *= 1 + -_zoomAxis.y;
        if (targetDistance < 5) targetDistance = 5;
        if (targetDistance > 30) targetDistance = 30;

        distance = Mathf.SmoothDamp(distance, targetDistance, ref zoomVel, dampZoom);

        if (Input.GetMouseButton(1))
            delta = Quaternion.Euler(0, _rotateAxis.x * sensivity, 0) * delta;
        if (Input.GetJoystickNames().Count() >= 1 && Input.GetAxis("Mouse X") == 0)
            delta = Quaternion.Euler(0, _rotateAxis.x * (sensivity / 2), 0) * delta;

        transform.position = pivotPoint.position + delta.normalized * distance;

        if (Input.GetMouseButton(1))
            transform.RotateAround(pivotPoint.position, transform.right, -_rotateAxis.y * sensivity);
        if (Input.GetJoystickNames().Count() >= 1 && Input.GetAxis("Mouse Y") == 0)
            transform.RotateAround(pivotPoint.position, transform.right, -_rotateAxis.y * (sensivity / 2));

            Vector3 pos = transform.position;
        if (pos.y < 2)
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

    public void OnCameraRotation(InputAction.CallbackContext callback)
    {
        _rotateAxis = callback.ReadValue<Vector2>();
    }

    public void OnCameraZoom(InputAction.CallbackContext callback)
    {
        _zoomAxis = callback.ReadValue<Vector2>();
    }
}