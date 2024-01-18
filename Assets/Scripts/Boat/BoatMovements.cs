using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BoatMovements : MonoBehaviour
{
    [System.Serializable]
    public struct WindAllure
    {
        public string name;
        public float minWindAngle, targetSailsAngle, velocity;
    }

    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private Transform _rendererTransform;
    [SerializeField] [Range(0.1f, 60f)] private float _moveSpeed;
    [SerializeField] [Range(0.1f, 60f)] private float _rotationSpeed;
    [SerializeField] private WindAllure[] allures;
    [SerializeField] private UnityEvent _onMove;

    private Vector3 _rotationAxis;
    private bool _isMoving;
    private float _speedAllure;


    private void Update()
    {
        // Rotation
        _rendererTransform.localEulerAngles += new Vector3(0, _rotationAxis.x * _rotationSpeed * Time.deltaTime, 0);

        // Check Allure
        CheckBoatAllure();

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
            _onMove.Invoke();
    }

    public void CheckBoatAllure()
    {
        float boatAngle = _rendererTransform.localEulerAngles.y - WindManager.instance._windAngle.y;
        for (int i = 0; i < allures.Length; i++)
        {
            if (boatAngle > allures[i].minWindAngle)
            {
                Debug.Log(allures[i].name);
                return;
            }
        }
    }
}
