using UnityEngine;
using UnityEngine.InputSystem;

public class BoatMovements : MonoBehaviour
{
    [SerializeField] [Range(5f, 105f)] private float _moveSpeed;
    [SerializeField] [Range(15f, 30f)] private float _rotationSpeed;

    private Vector2 _rotationAxis;
    private bool _isMoving;

    private void Update()
    {
        transform.localEulerAngles += new Vector3(0, _rotationAxis.x * _rotationSpeed * Time.deltaTime, 0);
        if (_isMoving)
        {
            transform.position += transform.forward * _moveSpeed * Time.deltaTime;
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
