using UnityEngine;

public class WindIndicator : MonoBehaviour
{
    [SerializeField] private Transform _windManagerTransform;

    public void RotateIndicator(Vector3 windDirection)
    {
        transform.rotation = Quaternion.LookRotation(windDirection);
    }
}
