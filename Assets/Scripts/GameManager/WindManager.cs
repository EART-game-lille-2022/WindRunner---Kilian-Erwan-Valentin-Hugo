using UnityEngine;
using UnityEngine.Events;

public class WindManager : MonoBehaviour
{
    public static WindManager instance;
    public Vector3 _windAngle;
    [SerializeField] private Transform _cameraPivot;
    [SerializeField] private float _windDuration;
    [SerializeField] private UnityEvent _onWindEnd;

    private float _windTimeLeft;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (_windTimeLeft > 0)
        {
            _windTimeLeft -= Time.deltaTime;
            if (_windTimeLeft <= 0)
            {
                _onWindEnd.Invoke();
            }
        }
    }

    public void GenerateWind()
    {
        _windAngle = _cameraPivot.localEulerAngles;
        _windTimeLeft = _windDuration;
    }
}
