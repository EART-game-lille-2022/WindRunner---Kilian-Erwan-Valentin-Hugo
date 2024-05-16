using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuInput : MonoBehaviour
{
    [SerializeField] private GameObject _firstSelected;
    [SerializeField] private bool _onEnabled = false;
    [SerializeField] private bool _storeLastButton = false;
    private GameObject _lastSelected;

    private void OnEnable()
    {
        if (_onEnabled == false) { return; }
        if (_storeLastButton == true)
        {
            _lastSelected = EventSystem.current.currentSelectedGameObject;
            //Debug.Log(_lastSelected);
        }
        if (Input.GetJoystickNames().Count() >= 1 && Input.GetJoystickNames()[0] != "")
            EventSystem.current.firstSelectedGameObject = _firstSelected;
    }

    public void SetSelectedObject()
    {
        if (_storeLastButton == true)
        {
            _lastSelected = EventSystem.current.currentSelectedGameObject;
            //Debug.Log(_lastSelected);
        }
        if (Input.GetJoystickNames().Count() >= 1 && Input.GetJoystickNames()[0] != "")
            EventSystem.current.SetSelectedGameObject(_firstSelected);
        //Debug.Log(EventSystem.current.currentSelectedGameObject);
    }

    public void QuitMenu()
    {
        if (_lastSelected == null) { return; }
        if (Input.GetJoystickNames().Count() >= 1 && Input.GetJoystickNames()[0] != "")
            EventSystem.current.SetSelectedGameObject(_lastSelected);
    }
}
