using UnityEngine;
using UnityEngine.InputSystem;

public class BoatMovements : MonoBehaviour
{
    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private Transform _rendererTransform;
    [SerializeField][Range(0.1f, 60f)] private float _rotationSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _isAnchorSet;

    private Vector3 _rotationAxis;
    private AllureManager _allureManager;
    private float _moveIntensity;
    private float _speedMultiplier;

    private void Start()
    {
        _allureManager = GetComponent<AllureManager>();
    }

    private void Update()
    {
        // Rotation
        _rendererTransform.localEulerAngles += new Vector3(0, _rotationAxis.x * _rotationSpeed * Time.deltaTime, 0);

        // Move
        SetMoveSpeed();
        _moveIntensity = _allureManager.intensity;
        _speedMultiplier = _allureManager.GetBoatSpeed(_rendererTransform);
        transform.position += _moveIntensity * _moveSpeed * _speedMultiplier * Time.deltaTime * _rendererTransform.forward;
    }

    public void RotateBoat(InputAction.CallbackContext callback)
    {
        _rotationAxis = callback.ReadValue<Vector2>();
    }

    private void SetMoveSpeed()
    {
        if (_isAnchorSet)
            _moveSpeed -= Time.deltaTime;
        else
            _moveSpeed += Time.deltaTime;
        _moveSpeed = Mathf.Clamp(_moveSpeed, 0, 1); 
    }

    public void ReverseAnchor() => _isAnchorSet = !_isAnchorSet;
}