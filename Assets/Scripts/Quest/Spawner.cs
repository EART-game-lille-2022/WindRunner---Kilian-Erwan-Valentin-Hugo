using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //MARCHE PAS
    // [header("Parametrage")]
    // public GameObject POIs;
    // public float spawnChance;

    // [Header("Raycast Settings")]
    // public float distanceBetweenCheck;
    // public floatheightOfCheck = 10f, rangeOfCheck = 30f;
    // public LayerMask layerMask;
    // public Vector2 positivePosition, negativePosition;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     SpawnPOIs();
    // }

    // // Update is called once per frame
    // void SpawnPOIs()
    // {
    //     for (float x = negativePosition.x; x < positivePosition.x; x += distanceBetweenCheck)
    //     {
    //          for (float z = negativePosition.y; z < positivePosition.y; z += distanceBetweenCheck)
    //     {
    //         RaycastHit hit;
    //         if(Physics.Raycast(new Vector 3(x, heightOfCheck, z), Vector3.down, out hit, rangeOfCheck, layerMask))
    //         {
    //             if(spawnChance > Random.Range(0, 101))
    //             {
    //                 Instantiate(POIs, hit.point, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)), transform);
    //             }
    //         }
    //     }
    //     }
    // }
}
