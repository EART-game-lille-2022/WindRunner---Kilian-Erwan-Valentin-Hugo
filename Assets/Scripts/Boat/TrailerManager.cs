using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TrailerManager : MonoBehaviour
{
    public static TrailerManager instance;
    [SerializeField] private Rigidbody _towPoint;
    [SerializeField] private HingeJoint _towedObjectJoint;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void AttachObject(Rigidbody objectToAttach)
    {
        Debug.Log("Attach : " + objectToAttach.gameObject.name);
        Collider collider = objectToAttach.GetComponent<Collider>();
        collider.enabled = false;
        objectToAttach.DOMove(transform.position, 1).OnComplete(() => {
            collider.enabled = true;
            _towedObjectJoint.connectedBody = objectToAttach;
        });
    }

    public void DetachObject()
    {
        _towedObjectJoint.connectedBody = _towPoint;
    }
}
