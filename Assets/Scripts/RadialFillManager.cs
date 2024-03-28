using UnityEngine;
using UnityEngine.UI;

public class RadialFillManager : MonoBehaviour
{
    [SerializeField] private float _fillSpeed;
    private Image _image;
    private bool _isFillingUp;

    private void Start()
    {
        _image = GetComponentInChildren<Image>();

        _isFillingUp = false;
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
        if (_isFillingUp == false)
        {
            _image.fillAmount -= _fillSpeed * Time.deltaTime;
        }
    }

    public void UpdateFill()
    {
        _isFillingUp = true;
        _image.fillAmount += _image.fillAmount + _fillSpeed * Time.deltaTime;
    }

    public void ReleaseFill()
    {
        _isFillingUp = false;
    }
}
