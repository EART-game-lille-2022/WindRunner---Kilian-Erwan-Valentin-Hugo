using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RadialFillManager : MonoBehaviour
{
    public static RadialFillManager instance;
    private Image _image;
    private Vector3 _screenPos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _image = GetComponentInChildren<Image>();
    }

    private void Update()
    {
        if (Input.GetJoystickNames().Count() == 1 && Input.GetJoystickNames()[0] != "")
        {
            transform.position = _screenPos;
        } else
        {
            transform.position = Input.mousePosition;
        }
    }

    public void UpdateFill(float amount, Vector3 transform)
    {
        _image.fillAmount = amount;
        _screenPos = Camera.main.WorldToScreenPoint(transform);
    }
}
