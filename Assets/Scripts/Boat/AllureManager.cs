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

    [SerializeField] private SailRotation _matPivot;
    [SerializeField] private WindAllure[] allures;
    [SerializeField] private UnityEvent<float> _onCurrentAllureChange;
    private WindAllure current;
    private WindIndicator _indicator;
    private float _multiplier;

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
            _matPivot.MirrorSail(true);
        }
        else
        {
            _matPivot.MirrorSail(false);
        }

        for (int i = 0; i < allures.Length; i++)
        {
            if (boatAngle < 180 - allures[i].minWindAngle)
            {
                ChangeAllure(i);
                return;
            }
        }
    }

    private Vector3 GetWindForward(Transform objectTransform)
    {
        WindPoint.GetWeightAt(objectTransform.position, out float intensity, out Vector3 windForward);
        windForward.y = 0;
        _indicator.RotateIndicator(windForward);

        return windForward;
    }

    private void CheckSailOrientation()
    {
        float sailAngle = _matPivot.currentAngle;
        if (sailAngle > current.targetSailsAngle)
        {
            sailAngle = current.targetSailsAngle - (sailAngle - current.targetSailsAngle);
        }
        _multiplier = sailAngle / current.targetSailsAngle;
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