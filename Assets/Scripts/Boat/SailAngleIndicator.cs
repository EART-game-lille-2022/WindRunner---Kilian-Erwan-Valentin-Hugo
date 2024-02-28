using UnityEngine;
using DG.Tweening;

public class SailAngleIndicator : MonoBehaviour
{
    [SerializeField] private AllureManager _allureManager;
    [SerializeField][Range(-400, 400)] float _indicatorPosition;
    private RectTransform _rectTransform;
    private float _sailAngle;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void ShowOptimalAngle()
    {
        _sailAngle = _allureManager.GetCurrentAllure().targetSailsAngle;
        _indicatorPosition = _sailAngle.Remap(1, 179, -400, 400);
        _rectTransform.DOAnchorPosX(_indicatorPosition, 2);
    } 
}
