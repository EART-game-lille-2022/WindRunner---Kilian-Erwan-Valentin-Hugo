using UnityEngine;

public class SailRotation : MonoBehaviour
{
    [SerializeField][Range(0.1f, 30f)] private float _rotationSpeed;
    public float currentAngle;

    public void RotareSail(float value)
    {
        float angle = value.Remap(0, 1, 32, 90);
        angle = Mathf.Clamp(angle, 33, 89);
        currentAngle = angle;
        transform.localEulerAngles = new Vector3(0, currentAngle, 0);
    }
}