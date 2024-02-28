using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class AllureManager : MonoBehaviour
{
    [System.Serializable]
    public struct WindAllure
    {
        public string name;
        public float minWindAngle, targetSailsAngle, velocity;
    }

    [SerializeField] private TMP_Text _allureText;
    [SerializeField] private TMP_Text _orientationText;
    [SerializeField] private TMP_Text _multiplierText;
    [SerializeField] private SailRotation _sail;
    [SerializeField] private WindAllure[] allures;
    [SerializeField] private UnityEvent _onCurrentAllureChange;

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

        for (int i = 0; i < allures.Length; i++)
        {
            if (boatAngle < 180 - allures[i].minWindAngle)
            {
                _allureText.text = allures[i].name;
                ChangeAllure(i);
                return;
            }
        }
    }

    private Vector3 GetWindForward(Transform objectTransform)
    {
        Vector3 windForward;
        WindPoint.GetWeightAt(objectTransform.position, out intensity, out windForward);
        windForward.y = 0;

        //Debug.DrawRay(objectTransform.position, windForward * intensity * 4, Color.red);
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
        _orientationText.text = sailAngle.ToString() + " ; " + _multiplier.ToString();
    }

    private float GetBoatMoveSpeed()
    {
        float moveSpeed = current.velocity * _multiplier;
        _multiplierText.text = moveSpeed.ToString();
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
        _onCurrentAllureChange.Invoke();
    }
}