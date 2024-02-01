using UnityEngine;

public class WindIndicator : MonoBehaviour
{
    [SerializeField] private Transform _windManagerTransform;

    private void Update()
    {
        transform.localEulerAngles = _windManagerTransform.localEulerAngles;
    }
}
