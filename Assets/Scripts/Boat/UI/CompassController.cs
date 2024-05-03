using UnityEngine;

public class CompassController : MonoBehaviour
{
    [SerializeField] private Transform _boatPivot;
    private Vector3 _direction;

    private void Update()
    {
        _direction.z = _boatPivot.eulerAngles.y;
        transform.localEulerAngles = _direction;
    }
}