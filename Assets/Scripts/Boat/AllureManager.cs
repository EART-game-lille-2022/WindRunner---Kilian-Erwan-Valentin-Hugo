using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class AllureManager : MonoBehaviour
{
    [System.Serializable]
    public struct WindAllure
    {
        public string name;
        public float minWindAngle, targetSailsAngle, velocity, optimalAngle;
    }

    [SerializeField] private TMP_Text _allureText;
    [SerializeField] private SailRotation _sail;
    [SerializeField] private WindAllure[] allures;
    [SerializeField] private UnityEvent<float> _onCurrentAllureChange;
    [SerializeField] private UnityEvent _onMirrorSail;

    public WindAllure current;
    private WindIndicator _indicator;
    private float _multiplier;
    public float intensity;

    private void Start()
    {
        _indicator = GetComponentInChildren<WindIndicator>();
        current = allures[0];
        CheckSailOrientation();
    }

    public float GetBoatSpeed(Transform objectTransform)
    {
        GetBoatAllure(objectTransform);
        CheckSailOrientation();
        return GetBoatMoveSpeed();
    }

    public void GetBoatAllure(Transform objectTransform)
    {
        Vector3 direction = objectTransform.transform.forward;
        direction.y = 0;
        float boatAngle = Vector3.Angle(direction, GetWindForward(objectTransform));
        if (Vector3.Cross(direction, GetWindForward(objectTransform)).y > 0)
        {
            _sail.MirrorSail(true);
        } else
        {
            _sail.MirrorSail(false);
        }

        for (int i = 0; i < allures.Length; i++)
        {
            if (boatAngle < 180 - allures[i].minWindAngle)
            {
                if (_allureText != null) { _allureText.text = allures[i].name; }
                ChangeAllure(i);
                return;
            }
        }
    }

    private Vector3 GetWindForward(Transform objectTransform)
    {
        WindPoint.GetWeightAt(objectTransform.position, out intensity, out Vector3 windForward);
        windForward.y = 0;
        _indicator.RotateIndicator(windForward);

        return windForward;
    }

    private void CheckSailOrientation()
    {
        float sailAngle = _sail.currentAngle;
        if (sailAngle > 90)
            sailAngle = 180 - _sail.currentAngle;

        if (sailAngle > current.targetSailsAngle)
        {
            float inRangeAngle = sailAngle - current.targetSailsAngle;
            float maxRange = 90 - current.targetSailsAngle;
            _multiplier = inRangeAngle / maxRange;
            _multiplier = 1 - _multiplier;
            if (_multiplier <= 0) { _multiplier = 0.01f; }
        }
        else
        {
            _multiplier = sailAngle / current.targetSailsAngle;
        }
    }

    private float GetBoatMoveSpeed()
    {
        float moveSpeed = current.velocity * _multiplier;
        return moveSpeed;
    }

    public WindAllure GetCurrentAllure()
    {
        return current;
    }

    private void ChangeAllure(int i)
    {
        if (current.name == allures[i].name) { return; }
        current = allures[i];
        _onCurrentAllureChange?.Invoke(current.optimalAngle);
    }
}