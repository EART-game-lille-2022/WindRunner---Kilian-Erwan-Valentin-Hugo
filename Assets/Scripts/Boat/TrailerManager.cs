using UnityEngine;

public class TrailerManager : MonoBehaviour
{
    public static TrailerManager instance;
    [SerializeField] HingeJoint _joint;
    private Transform _connectedTransform;
    [SerializeField] private Transform _towPoint;

    private void Awake()
    {
        if (instance != null) {
            Destroy(gameObject);
        } else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (_connectedTransform != null)
        {
            _connectedTransform.position = Vector3.MoveTowards(_connectedTransform.position, _towPoint.position, 1);
            _connectedTransform.forward = _towPoint.forward;
        }
    }

    public void AttachObject(Transform objectToAttach)
    {
        if (_connectedTransform != null) { return; }
        Debug.Log("Attach : " + objectToAttach.gameObject.name);
        _connectedTransform = objectToAttach;
    }

    public void DetachObject()
    {
        _connectedTransform = null;
    }
}
