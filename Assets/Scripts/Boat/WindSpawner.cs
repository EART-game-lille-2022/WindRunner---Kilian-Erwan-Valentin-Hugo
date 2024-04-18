using UnityEngine;

public class WindSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform refPosRot;
    public Transform _spawnPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 forward = refPosRot.forward;
            forward.y = 0;
            Instantiate(prefab, _spawnPosition.position, Quaternion.LookRotation(forward));
        }
    }
}