using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

[CreateAssetMenu(fileName = "Mission_", menuName = "Data/Mission", order = 1)]
public class S_Mission : ScriptableObject
{
    public string missionName; //Nomer la mission en public
    public bool isUnlocked = false; //De base, la mission n'est pas debloqué
   // public ScriptableDialogue dialogue;

    public S_Mission[] unlockedOnFinish; //Quete debloqué lors de complition de cette quete

    public S_MissionObjective[] objectifList;   //Entré du scriptable object qui comprend les objet a recuperer pour la quete

    public void StartMission() {
        Debug.Log("Start Mission");
  //      DialogueManager.instance.PlayDialogue(dialogue);
        foreach(S_MissionObjective objectif in objectifList) {
            objectif.Start();
        }
    }
    public bool CheckFinish() {
        foreach(S_MissionObjective objectif in objectifList) {
            if(!objectif.CheckFinish()) return false;
        }
        return true;
    }
}
