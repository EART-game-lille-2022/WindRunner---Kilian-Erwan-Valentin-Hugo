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

    public void ShowOptimalAngle()
    {
        float sailAngle = _allureManager.GetCurrentAllure().targetSailsAngle;
        Debug.Log(sailAngle);
        _indicatorPosition = sailAngle.Remap(0, 90, -400, 400);
        _rectTransform.DOAnchorPosX(_indicatorPosition, 2);
    } 
}
