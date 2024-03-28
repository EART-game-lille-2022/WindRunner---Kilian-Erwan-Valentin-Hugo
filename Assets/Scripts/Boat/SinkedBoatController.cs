using UnityEngine;
using UnityEngine.EventSystems;

public class SinkedBoatController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RadialFillManager _radialFillManager;
    [SerializeField] private float _minTowDistance;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != 0) { return; }
        float distance = Vector3.Distance(transform.position, TrailerManager.instance.transform.position);
        if (distance > _minTowDistance) 
        { 
            Debug.Log("Distance to high : " + distance);
            return; 
        }
        //_radialFillManager.UpdateFill();
        TrailerManager.instance.AttachObject(transform);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _radialFillManager.ReleaseFill();
    }

    private void AttachToBoat()
    {
        
    }
}
