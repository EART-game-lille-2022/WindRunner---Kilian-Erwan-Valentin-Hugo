using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class SailOpeningController : MonoBehaviour
{
    [SerializeField] private float _tweenDuration = 0.5f;

    public void OpenSail(float percent)
    {
        float newScaleZ = percent.Remap(0, 100, 10, 100);
        float newPosY = percent.Remap(0, 100, 3.5f, -0.25f);

        transform.DOLocalMoveY(newPosY, _tweenDuration);
        transform.DOScaleZ(newScaleZ, _tweenDuration);
    }
}
