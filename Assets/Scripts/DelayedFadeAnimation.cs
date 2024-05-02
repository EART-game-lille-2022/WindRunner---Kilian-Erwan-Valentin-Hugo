using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DelayedFadeAnimation : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _startAlpha;
    [SerializeField] private float _fadeDuration;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void StartFadeInAnimation(float delay)
    {
        if (_image == null) 
        { 
            Debug.LogWarning("No Image Found on Object.");
            return;
        }
        _image.DOFade(1, _fadeDuration).SetDelay(delay);
    }

    public void StartFadeOut(float delay)
    {
        if (_image == null)
        {
            Debug.LogWarning("No Image Found on Object.");
            return;
        }
        _image.DOFade(0, _fadeDuration).SetDelay(delay);
    }
}
