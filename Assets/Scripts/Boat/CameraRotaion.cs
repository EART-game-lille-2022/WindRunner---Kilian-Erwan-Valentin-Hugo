using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotaion : MonoBehaviour
{
    [SerializeField] private Transform _mainCameraPivot;
    [SerializeField] [Range(10f, 100f)] private float _cameraRotationSpeed; 
    private Vector2 _rotationAxis;

    private void Update()
    {
        if (_rotationAxis != Vector2.zero && Input.GetKey(KeyCode.Mouse0))
        {
            _mainCameraPivot.Rotate(new Vector3(0, _rotationAxis.x * _cameraRotationSpeed * Time.deltaTime, 0));
        }
    }

    public void OnCameraRotation(InputAction.CallbackContext callback)
    {
        _rotationAxis = callback.ReadValue<Vector2>();
    }
}
