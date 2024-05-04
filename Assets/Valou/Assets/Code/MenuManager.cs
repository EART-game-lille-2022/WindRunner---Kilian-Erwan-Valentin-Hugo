using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _MenuPauseGO;

    private bool isPaused;
    private void Start()
    {
        _MenuPauseGO.SetActive(false);
    }
    public void OnPause(InputAction.CallbackContext callback)
    {
        if (isPaused==true)
                Unpause();
            else
                Pause();
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        OpenMenuPause();
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        CloseAllMenus();
    }

    private void OpenMenuPause()
    {
        _MenuPauseGO.SetActive(true);
    }

    private void CloseAllMenus()
    {
        _MenuPauseGO.SetActive(false);
    }
}
