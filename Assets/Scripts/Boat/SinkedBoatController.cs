using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SinkedBoatController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject _button;
    [SerializeField] private float _minTowDistance;
    [SerializeField] private float _fillSpeed;
    private Rigidbody _body;
    private bool _isFilling;
    private bool _isAttach;
    private float _fillAmount;

    private void Start()
    {
        if (RadialFillManager.instance == null)
        {
            Debug.LogWarning(gameObject.name + " : RadialFillManager does not Exist.");
            enabled = false;
        }
        _body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetJoystickNames().Count() >= 1 && Input.GetJoystickNames()[0] != "")
        {
            ShowButton();
            AttachBoat();
        }

        if (_isFilling)
        {
            _fillAmount += _fillSpeed * Time.deltaTime;
            RadialFillManager.instance.UpdateFill(_fillAmount, _button.transform.position);
            if (_fillAmount >= 1)
            {
                _isFilling = false;
                _fillAmount = 0;
                RadialFillManager.instance.UpdateFill(_fillAmount, _button.transform.position);
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
            RadialFillManager.instance.UpdateFill(_fillAmount, _button.transform.position);
        }
    }

    private void ShowButton()
    {
        float distance = Vector3.Distance(transform.position, TrailerManager.instance.transform.position);
        if (distance < _minTowDistance)
        {
            _button.SetActive(true);
        } else
        {
            _button.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != 0) { return; }
        float distance = Vector3.Distance(transform.position, TrailerManager.instance.transform.position);
        if (distance > _minTowDistance)
        {
            return;
        }
        _isFilling = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isFilling = false;
    }

    private void AttachBoat()
    {
        if (Input.GetKey(KeyCode.JoystickButton0))
        {
            float distance = Vector3.Distance(transform.position, TrailerManager.instance.transform.position);
            if (distance <= _minTowDistance) 
            {  
                _isFilling = true;
            }
        } else
        {
             _isFilling = false;
        }
    }
}