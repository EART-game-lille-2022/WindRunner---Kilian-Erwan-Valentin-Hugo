using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SailOpeningSelector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Serializable]
    private struct Crans
    {
        public float selectorAngle;
        public float openingPercent;
    }

    [SerializeField] private float _moveDelay;
    [SerializeField] private List<Crans> _positions;
    [SerializeField] private UnityEvent<float> _onValueChange;
    private float _mouseDelta;
    private int _currentIndex;
    private bool _isPressed;
    private bool _canMove;

    private void Start()
    {
        _currentIndex = 0;
        _isPressed = false;
        _canMove = true;
    }

    private void Update()
    {
        if (_isPressed == true)
        {
            if (_mouseDelta > 0)
            {
                StartCoroutine(MoveSelector(-1));
            }
            if (_mouseDelta < 0)
            {
                StartCoroutine(MoveSelector(1));
            }
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
            _onValueChange.Invoke(_positions[_currentIndex].openingPercent);
            yield return new WaitForSeconds(_moveDelay);
            _canMove = true;
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
        }
        else
        {
            _isPressed = false;
        }
    }
}