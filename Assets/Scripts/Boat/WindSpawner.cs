using UnityEngine;

public class WindSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform refPosRot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 forward = refPosRot.forward;
            forward.y = 0;
            Instantiate(prefab, refPosRot.position, Quaternion.LookRotation(forward));
        }
    }
}