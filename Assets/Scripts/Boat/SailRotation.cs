using DG.Tweening;
using UnityEngine;

public class SailRotation : MonoBehaviour
{
    [SerializeField][Range(0.1f, 30f)] private float _rotationSpeed;
    public float currentAngle;
    private bool _isMirrored;

    public void RotareSail(float value)
    {
        currentAngle = value;
        if (_isMirrored)
        {
            transform.DORotate(new Vector3(0, value + (90 - value), 0), 0.5f);
        } else
        {
            transform.DORotate(new Vector3(0, value, 0), 0.5f);
        }
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