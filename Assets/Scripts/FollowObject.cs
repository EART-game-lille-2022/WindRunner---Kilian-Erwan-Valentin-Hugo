using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform _objectToFollow;

    private void Update()
    {
        transform.position = _objectToFollow.position;
    }
}