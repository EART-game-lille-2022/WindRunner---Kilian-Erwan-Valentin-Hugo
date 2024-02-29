using UnityEngine;

public class BoatTowDetection : MonoBehaviour
{
    private BoatTowManager _towManager;

    private void Start()
    {
        _towManager = GetComponentInChildren<BoatTowManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TowableObject"))
        {
            Rigidbody objectToAttach = other.GetComponent<Rigidbody>();
            if (objectToAttach != null)
            {
                _towManager.AttachObjectToBoat(objectToAttach);
            }
        }
    }
}
