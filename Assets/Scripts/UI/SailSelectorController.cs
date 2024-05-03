using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SailSelectorController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Serializable]
    public struct Crans
    {
        public float selectorAngle, sailAngle;
    }

    [SerializeField] private AllureManager _allureManager;
    [SerializeField] private float _moveDelay;
    [SerializeField] private List<Crans> _positions;
    [SerializeField] private UnityEvent<float> _onValueChange;
    private float _mouseDelta;
    private int _currentIndex = 0;
    private bool _isPressed = false;
    private bool _canMove = true;

    private void Update()
    {
        if (_isPressed)
        {
            if (_mouseDelta > 0.1f)
            {
                StartCoroutine(MoveSelector(-1));
            }
            if (_mouseDelta < 0.1f)
            {
                StartCoroutine(MoveSelector(1));
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pressed");
        _isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
    }

    public void OnMouseDelta(InputAction.CallbackContext callback)
    {
        _mouseDelta = callback.ReadValue<Vector2>().y;
    }

    public void OnTrigger(InputAction.CallbackContext callback)
    {
        _mouseDelta = callback.ReadValue<float>();
        if (_mouseDelta != 0)
        {
            _isPressed = true;
        } else
        {
            _isPressed = false;
        }
    }

    private IEnumerator MoveSelector(int sign)
    {
        if (_canMove == true)
        {
            _canMove = false;
            _currentIndex += sign;
            if (_currentIndex >= _positions.Count - 1) { _currentIndex = _positions.Count - 1; }
            if (_currentIndex <= 0) { _currentIndex = 0; }

            transform.localEulerAngles = new Vector3(0, 0, _positions[_currentIndex].selectorAngle);
            _onValueChange.Invoke(_positions[_currentIndex].sailAngle);
            yield return new WaitForSeconds(_moveDelay);
            _canMove = true;
        }
    }
}