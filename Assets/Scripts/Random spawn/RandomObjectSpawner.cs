using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] myObjects;
    public int maxSpawnCount = 3; // Nombre maximum d'objets à créer

    private int spawnCount = 0; // Nombre d'objets déjà créés

    void Update()
    {
        // Vérifier si le nombre maximum d'objets a été atteint
        if (spawnCount < maxSpawnCount)
        {
            int randomIndex = Random.Range(0, myObjects.Length);

            // Obtenir les limites de la boîte englobante de cet objet
            Bounds bounds = GetComponent<Renderer>().bounds;

            // Générer une position aléatoire à l'intérieur des limites de la boîte englobante
            Vector3 randomSpawnPosition = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
            );

            Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);

            spawnCount++; // Incrémenter le compteur d'objets créés
        }
    }
}
