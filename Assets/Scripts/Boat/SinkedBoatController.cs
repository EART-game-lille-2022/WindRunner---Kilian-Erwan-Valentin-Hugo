using UnityEngine;
using UnityEngine.EventSystems;

public class SinkedBoatController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float _minTowDistance;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        float distance = Vector3.Distance(transform.position, TrailerManager.instance.transform.position);
        if (distance > _minTowDistance) 
        { 
            Debug.Log("Distance to high : " + distance);
            return; 
        }
        TrailerManager.instance.AttachObject(transform);
    }
}
