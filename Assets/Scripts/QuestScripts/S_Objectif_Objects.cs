using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collect_", menuName = "Data/Objectif : Object collect", order = 1)]
public class S_Objectif_Objects : S_MissionObjective
{
    public string objectID;
    [SerializeField] private int countNeeded = 1;
    int countLeft = 1;

    public int AddToCount(int count = 1) {
        if(countLeft >= count) {
            countLeft -= count;
            return 0;
        } else {
            int b = countLeft;
            countLeft = 0;
            return count-countLeft;
        }
    }
    
    public override bool CheckFinish() {
        return countLeft <= 0;
    }
    public override void Start() {
        countLeft = countNeeded;
        foreach(Collectible collectible in Collectible.collectibles) {
            if(collectible.objectID == objectID) {
                collectible.gameObject.SetActive(true);
            }
        }
    }
    
    public override void End() {
    }
}
