using UnityEngine;

public class WindManager : MonoBehaviour
{
    public static WindManager instance;
    [SerializeField] private Transform _cameraPivot;

    private float _windIntensity = 2;
    private Vector3 _windDirection;

    public float WindIntensity { get => _windIntensity; }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localEulerAngles = _cameraPivot.localEulerAngles;
            _windDirection = _cameraPivot.localEulerAngles;

            if (_windIntensity <= 0)
                _windIntensity += 20;
            else
                _windIntensity += 1f / _windIntensity;
        }

        _windIntensity -= Time.deltaTime * 1;
        _windIntensity = Mathf.Max(_windIntensity, 0);
    }
}