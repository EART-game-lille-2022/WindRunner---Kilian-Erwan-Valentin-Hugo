using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    // public RandomObjectSpawner nextSpawn;
    public string nextSpawnID = "";

    public static int FoundObjectQuest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NextQuest()
    {
       print ("ca marche");
       FoundObjectQuest++;

            if (FoundObjectQuest == 3)
        {
            Debug.Log("Gagné !");
            // nextSpawn.NextSpawn();
            GameObject next = ObjectFinder.Find(nextSpawnID);
            if(next != null) {
                RandomObjectSpawner spawner = next.GetComponent<RandomObjectSpawner>();
                spawner.NextSpawn();
            } else Debug.LogError("nextSpawn not in scene");

        }

			// Détruit le questobject au bout de 0.1 seconde.
			Destroy (gameObject, 0.1f);
			
			gameObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
