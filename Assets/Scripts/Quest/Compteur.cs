using UnityEngine;


public class compteur : MonoBehaviour
{
	    public QuestManager questManager;


	private void OnTriggerEnter(Collider collision)
	{
		if (collision.CompareTag ("Player"))
		{
			
            questManager.NextQuest();
        
		}
	}
}