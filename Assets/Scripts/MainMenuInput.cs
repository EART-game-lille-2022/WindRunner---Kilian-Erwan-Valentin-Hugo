using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuInput : MonoBehaviour
{
    [SerializeField] private EventSystem _system;
    [SerializeField] private GameObject _firstSelected;

    private void OnEnable()
    {
        if (Input.GetJoystickNames().Count() >= 1 && Input.GetJoystickNames()[0] != "")
            _system.firstSelectedGameObject = _firstSelected;
    }
}
