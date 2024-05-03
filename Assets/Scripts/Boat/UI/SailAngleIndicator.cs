using UnityEngine;
using DG.Tweening;

public class SailAngleIndicator : MonoBehaviour
{
    [SerializeField] private AllureManager _allureManager;
    [SerializeField][Range(-400, 400)] float _indicatorPosition;
    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void ShowOptimalAngle(float angle)
    {
        _rectTransform.localEulerAngles = new Vector3(0, 0, angle);
    } 
}
