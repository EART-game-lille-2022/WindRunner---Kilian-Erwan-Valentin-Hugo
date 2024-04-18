using UnityEngine;


public class compteur : MonoBehaviour
{
	// Le champ est statique, donc commun à toutes les instances de Panel.
	//public static int FoundObjectQuest;
    public QuestManager questManager;


	private void OnTriggerEnter(Collider collision)
	{
		if (collision.CompareTag ("Player"))
		{
			// Met à jour le nombre de panneaux trouvés.
			//FoundObjectQuest++;
            //if (FoundObjectQuest == 3)
       // {
            //Debug.Log("Gagné !");
            questManager.NextQuest();
        //}
			// Détruit le panneau au bout de 0.1 seconde.
			//Destroy (gameObject, 0.1f);
			// Désactive le panneau.
			//gameObject.SetActive (false);
		}
	}
}