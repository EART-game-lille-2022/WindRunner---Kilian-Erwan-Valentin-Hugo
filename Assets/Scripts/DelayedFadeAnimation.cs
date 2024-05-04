using UnityEngine;
using DG.Tweening;

public class DelayedFadeAnimation : MonoBehaviour
{
    [SerializeField] float _fadeDuration;
    CanvasGroup _group;

    void Start()
    {
        _group = GetComponent<CanvasGroup>();
    }

    public void StartFadeIn(float delay)
    {
        if (_group == null)
        {
            Debug.LogWarning(gameObject.name + " : There is nothing to fade");
            return;
        }
        _group.DOFade(1, _fadeDuration).SetDelay(delay).OnComplete(() => ChangeCanvasGroupPorperty(true));
    }

    public void StartFadeOut(float delay)
    {
        if (_group == null) 
        { 
            Debug.LogWarning(gameObject.name + " : There is nothing to fade");
            return; 
        }
        _group.DOFade(0, _fadeDuration).SetDelay(delay).OnComplete(() => ChangeCanvasGroupPorperty(false));
    }

    void ChangeCanvasGroupPorperty(bool isEnabled)
    {
        if (_group == null) { return; }
        _group.interactable = isEnabled;
        _group.blocksRaycasts = isEnabled;
    }
}
