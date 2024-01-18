using UnityEngine;
using UnityEngine.InputSystem;

public class BoatMovements : MonoBehaviour
{
    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private Transform _rendererTransform;
    [SerializeField] [Range(0.1f, 60f)] private float _moveSpeed;
    [SerializeField] [Range(0.1f, 60f)] private float _rotationSpeed;
    public WindAllure[] allures;

    private Vector3 _rotationAxis;
    private bool _isMoving;

    [System.Serializable]
    public struct WindAllure
    {
        public string name;
        public float minWindAngle, targetSailsAngle, velocity;
    }


    private void Update()
    {
        // Rotation
        _rendererTransform.localEulerAngles += new Vector3(0, _rotationAxis.x * _rotationSpeed * Time.deltaTime, 0);

        // Move
        if (_isMoving)
        {
            transform.position += _rendererTransform.forward * _moveSpeed * Time.deltaTime;
        }
    }

    public void RotateBoat(InputAction.CallbackContext callback)
    {
        _rotationAxis = callback.ReadValue<Vector2>();
    }

    public void MoveBoat(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            _isMoving = true;
        }
        if (callback.canceled)
        {
            _isMoving = false;
        }
    }
}
