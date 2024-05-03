using UnityEngine;

public class CompassController : MonoBehaviour
{
    [SerializeField] private Transform _boatPivot;
    private Vector3 _direction;

    private void Start()
    {
        if (_boatPivot == null)
        {
            Debug.LogWarning(gameObject.name + " : BoatPivot reference is not set");
            enabled = false;
        }
    }

    private void Update()
    {
        _direction.z = _boatPivot.eulerAngles.y;
        transform.localEulerAngles = _direction;
    }
}