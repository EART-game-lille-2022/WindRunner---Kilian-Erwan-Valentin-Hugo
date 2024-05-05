using UnityEngine;

public class WindIndicator : MonoBehaviour
{
    [SerializeField] private Transform _windManagerTransform;

    public void RotateIndicator(Vector3 windDirection)
    {
        if (windDirection == Vector3.zero) { return; }
        transform.rotation = Quaternion.LookRotation(windDirection);
    }
}