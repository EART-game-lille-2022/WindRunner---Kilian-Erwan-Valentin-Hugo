using UnityEngine;
using UnityEngine.UI;

public class RadialFillManager : MonoBehaviour
{
    private Image _image;

    private void Start()
    {
        _image = GetComponentInChildren<Image>();
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void UpdateFill(float amount)
    {
        _image.fillAmount = amount;
    }
}
