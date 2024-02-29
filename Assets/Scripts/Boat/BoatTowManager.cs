using UnityEngine;

public class BoatTowManager : MonoBehaviour
{
    private Rigidbody _boatTug;
    private ConfigurableJoint _joint;

    private void Start()
    {
        _boatTug = GetComponent<Rigidbody>();
        _joint = GetComponent<ConfigurableJoint>();

        _joint.connectedBody = null;
        _boatTug.isKinematic = true;
    }

    public void AttachObjectToBoat(Rigidbody bodyToAttach)
    {
        if (bodyToAttach == null || _joint.connectedBody != null) { return; }
        Debug.Log("Attach : " + bodyToAttach.gameObject.name);

        // _joint.connectedAnchor = transform.InverseTransformPoint(bodyToAttach.position);

        // _joint.connectedAnchor = bodyToAttach.transform.InverseTransformPoint(transform.position);
        _joint.connectedBody = bodyToAttach;
        _boatTug.isKinematic = false;
    }

    public void DetachObject()
    {
        if (_joint.connectedBody == null) { return; }

        _joint.connectedBody = null;
        _boatTug.isKinematic = true;
    }
}
