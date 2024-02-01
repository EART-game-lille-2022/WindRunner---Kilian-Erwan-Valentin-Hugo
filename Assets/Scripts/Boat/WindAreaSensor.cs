using UnityEngine;

public class WindAreaSensor : MonoBehaviour
{
    [SerializeField] private WindManager _windManager;
    [SerializeField] private WindWeigth _windWeight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WindZone"))
        {
            _windWeight.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WindZone"))
        {
            _windWeight.enabled = false;
        }
    }
}
