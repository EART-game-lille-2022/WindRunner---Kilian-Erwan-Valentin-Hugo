using UnityEngine;

public class SailRotation : MonoBehaviour
{
    [SerializeField][Range(0.1f, 30f)] private float _rotationSpeed;
    public float currentAngle;

    public void RotareSail(float value)
    {
        float angle = value.Remap(0, 1, 0, 180);
        angle = Mathf.Clamp(angle, 1, 179);
        currentAngle = angle;
        transform.localEulerAngles = new Vector3(0, currentAngle, 0);
    }
}