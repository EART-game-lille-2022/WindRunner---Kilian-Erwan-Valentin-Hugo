using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class WindSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform refPosRot;
    public Transform _spawnPosition;
    [SerializeField, Range(0f, 2f)] private float _spawnDelay;
    private bool _canCreatePoint;
    private bool _isPressed;

    private void Start()
    {
        _canCreatePoint = true;
    }

    private void Update()
    {
        if (_isPressed == true)
        {
            StartCoroutine(CreateWindPoint());
        }
    }

    private IEnumerator CreateWindPoint()
    {
        if (_canCreatePoint == true)
        {
            _canCreatePoint = false;
            Vector3 forward = refPosRot.forward;
            forward.y = 0;
            Instantiate(prefab, _spawnPosition.position, Quaternion.LookRotation(forward));
            yield return new WaitForSeconds(_spawnDelay);
            _canCreatePoint = true;
        }
    }

    public void OnWindGenerate(InputAction.CallbackContext callback)
    {
        if (callback.started)
        {
            _isPressed = true;
        }
        if (callback.canceled)
            _isPressed = false;
    }
}