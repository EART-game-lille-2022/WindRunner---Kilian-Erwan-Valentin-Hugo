using DG.Tweening;
using UnityEngine;

public class SailRotation : MonoBehaviour
{
    public float currentAngle;
    public bool _isMirrored;

    public void RotareSail(float value)
    {
        currentAngle = value;
        if (_isMirrored)
        {
            float newValue = value.Remap(32, 120, 140, 60);
            transform.DORotate(new Vector3(0, newValue, 0), 0.5f);
        } else
        {
            transform.DORotate(new Vector3(0, value, 0), 0.5f);
            Debug.Log(value);
        }
    }

    public void MirrorSail(bool state)
    {
        _isMirrored = state;
        if (_isMirrored == true)
        {
            transform.DOScaleZ(-1, 1);
        } else
        {
            transform .DOScaleZ(1, 1);
        }
        RotareSail(currentAngle);
    }
}