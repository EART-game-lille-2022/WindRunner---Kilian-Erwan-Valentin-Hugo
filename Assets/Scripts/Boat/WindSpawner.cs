using UnityEngine;

public class WindSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform refPosRot;
    public WindPoint _point;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_point != null)
            {
                _point.windIntensity += 1;
                Debug.Log(_point.windIntensity);
            } else
            {
                Vector3 forward = refPosRot.forward;
                forward.y = 0;
                GameObject pointObject = Instantiate(prefab, refPosRot.position, Quaternion.LookRotation(forward), transform);
                _point = pointObject.GetComponent<WindPoint>();
                Debug.Log("Instanciate : WindPoint");
            }
        }
    }
}