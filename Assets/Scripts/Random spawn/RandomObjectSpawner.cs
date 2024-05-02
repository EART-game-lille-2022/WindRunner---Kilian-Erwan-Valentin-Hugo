using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomObjectSpawner : MonoBehaviour
{
    // public static List<GameObject> questobjectToSpawn = new List<GameObject>();
    public static List<GameObject> spawned = new List<GameObject>();
    private int currentIndex = 0;
    int index = 1;
    public GameObject[] myObjects;
   
    public int maxSpawnCount = 3; // Nombre maximum d'objets à créer

    private int spawnCount = 0; // Nombre d'objets déjà créés

    // questobjectToSpawn.Add(currentEnemy);

    public void NextSpawn()
    {
        currentIndex++;
    }
    void Update()
    {
        GameObject objectToInstantiate = myObjects[currentIndex];
        
        // Vérifier si le nombre maximum d'objets a été atteint
        if (spawnCount < maxSpawnCount)
        {
            

            // Obtenir les limites de la boîte englobante de cet objet
            Bounds bounds = GetComponent<Renderer>().bounds;

            // Générer une position aléatoire à l'intérieur des limites de la boîte englobante
            Vector3 randomSpawnPosition = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );

            GameObject go = GameObject.Instantiate(objectToInstantiate, randomSpawnPosition, Quaternion.identity);
            spawned.Add(go);

            spawnCount++; // Incrémenter le compteur d'objets créés
        }
    }

    
}
