using UnityEngine;
using UnityEngine.InputSystem;

public class BoatMovements : MonoBehaviour
{
    [SerializeField] private Transform _rendererTransform;
    [SerializeField][Range(0.1f, 60f)] private float _baseMoveSpeed;
    [Header("Physics Data")]
    [SerializeField][Range(0.1f, 60f)] private float _rotationSpeed;
    [SerializeField] private float _forceMultiplier;

    private Rigidbody _rigidbody;
    private Vector3 _rotationAxis;
    private AllureManager _allureManager;

    private float _speedMultiplier;


    private void Start()
    {
        _allureManager = GetComponent<AllureManager>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _speedMultiplier = _allureManager.GetBoatSpeed(transform);
        float moveSpeed = (_baseMoveSpeed * _speedMultiplier).Abs();

        _rigidbody.AddTorque(0, _rotationAxis.x * _forceMultiplier * _rotationSpeed * Time.fixedDeltaTime, 0);
        _rigidbody.AddForce(_forceMultiplier * moveSpeed * Time.fixedDeltaTime * _rendererTransform.forward);
    }

    public void RotateBoat(InputAction.CallbackContext callback)
    {
        _rotationAxis = callback.ReadValue<Vector2>();
    }
}