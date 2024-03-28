using UnityEngine;
using UnityEngine.EventSystems;

public class SinkedBoatController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RadialFillManager _radialFillManager;
    [SerializeField] private float _minTowDistance;
    [SerializeField] private float _fillSpeed;
    private bool _isFilling;
    private bool _isAttach;
    private float _fillAmount;

    private void Update()
    {
        if (_isFilling)
        {
            _fillAmount += _fillSpeed * Time.deltaTime;
            _radialFillManager.UpdateFill(_fillAmount);
            if (_fillAmount >= 1)
            {
                _isFilling = false;
                _fillAmount = 0;
                _radialFillManager.UpdateFill(_fillAmount);
                if (_isAttach == false)
                {
                    TrailerManager.instance.AttachObject(transform);
                    _isAttach = true;
                } else
                {
                    TrailerManager.instance.DetachObject();
                    _isAttach = false;
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != 0) { return; }
        float distance = Vector3.Distance(transform.position, TrailerManager.instance.transform.position);
        if (distance > _minTowDistance) 
        { 
            Debug.Log("Distance to high : " + distance);
            return; 
        }
        _isFilling = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isFilling = false;
    }
}
