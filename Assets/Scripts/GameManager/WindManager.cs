using UnityEngine;

public class WindManager : MonoBehaviour
{
    public static WindManager instance;
    [SerializeField] private Transform _cameraPivot;
    public float windIntensity = 2;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            transform.localEulerAngles = _cameraPivot.localEulerAngles;
            if (windIntensity <= 0)
            {
                windIntensity += 20;
            } else
            {
                windIntensity += 1f / windIntensity;
            }
        }
        windIntensity -= Time.deltaTime * 1;
        windIntensity = Mathf.Max(windIntensity, 0);
    }
}
