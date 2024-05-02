using UnityEngine;
using UnityEngine.Events;

public class BoatCollidionDetection : MonoBehaviour
{
    [SerializeField] private UnityEvent _onCollision;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision");
            _onCollision.Invoke();
        }
    }
}
