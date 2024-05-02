using DG.Tweening;
using UnityEngine;

public class SailRotation : MonoBehaviour
{
    [SerializeField][Range(0.1f, 30f)] private float _rotationSpeed;
    public float currentAngle;
    private bool _isMirrored;

    public void RotareSail(float value)
    {
        float angle = value.Remap(0, 1, 32, 130);
        angle = Mathf.Clamp(angle, 33, 129);
        currentAngle = angle;
        transform.localEulerAngles = new Vector3(0, currentAngle, 0);
    }

    public void MirrorSail(bool state)
    {
        if (state != _isMirrored)
        {
            _isMirrored = state;
            if (_isMirrored == true)
            {
                transform.DOScaleZ(-1, 1);
            } else
            {
                transform .DOScaleZ(1, 1);
            }
        }
    }
}