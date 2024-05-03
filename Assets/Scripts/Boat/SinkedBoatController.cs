using UnityEngine;
using UnityEngine.EventSystems;

public class SinkedBoatController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RadialFillManager _radialFillManager;
    [SerializeField] private float _minTowDistance;
    [SerializeField] private float _fillSpeed;
    private Rigidbody _body;
    private bool _isFilling;
    private bool _isAttach;
    private float _fillAmount;

    private void Start()
    {
        if (_radialFillManager == null)
        {
            Debug.LogWarning(gameObject.name + " : RadialFillManager is not set.");
            enabled = false;
        }
        _body = GetComponent<Rigidbody>();
    }

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
                    TrailerManager.instance.AttachObject(_body);
                    _isAttach = true;
                }
                else
                {
                    TrailerManager.instance.DetachObject();
                    _isAttach = false;
                }
            }
        }
        else
        {
            if (_fillAmount <= 0) { return; }
            _fillAmount = Mathf.Clamp01(_fillAmount - _fillSpeed * Time.deltaTime);
            _radialFillManager.UpdateFill(_fillAmount);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer down");
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