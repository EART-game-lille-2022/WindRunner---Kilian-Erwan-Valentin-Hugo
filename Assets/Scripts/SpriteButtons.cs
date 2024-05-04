using UnityEngine;

public class SpriteButtons : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        transform.LookAt(target);
    }
}
