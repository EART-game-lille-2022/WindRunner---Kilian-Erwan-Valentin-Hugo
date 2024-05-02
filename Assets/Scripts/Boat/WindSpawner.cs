using System.Collections;
using UnityEngine;

public class WindSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform refPosRot;
    public Transform _spawnPosition;
    [SerializeField, Range(0f, 2f)] private float _spawnDelay;
    private bool _canCreatePoint;

    private void Start()
    {
        _canCreatePoint = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(CreateWindPoint());
        }
    }

    IEnumerator CreateWindPoint()
    {
        if (_canCreatePoint == true) 
        { 
            _canCreatePoint = false;
            Vector3 forward = refPosRot.forward;
            forward.y = 0;
            Instantiate(prefab, _spawnPosition.position, Quaternion.LookRotation(forward));
            yield return new WaitForSeconds(_spawnDelay);
            _canCreatePoint = true;
        }
    }
}