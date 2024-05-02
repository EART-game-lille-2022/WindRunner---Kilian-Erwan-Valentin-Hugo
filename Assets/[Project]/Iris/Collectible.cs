// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Collectible : MonoBehaviour
// {
//     public static List<Collectible> collectibles = new List<Collectible>(); //Creation d'une liste public, static->une seule instance de la variable partagé avec toute les instances
    
//     public string objectID; //Nom du collectible

//     void Awake() 
//     {
//         collectibles.Add(this); //Ajouter l'objet sur lequel est le script a la liste
//         gameObject.SetActive(false); //Rendre cet objet inactif
//     }

//     void OnDestroy() 
//     {
//         collectibles.Remove(this);
//     }
//     void Update()
//     { 
//         // distance avec le joueur -> finish
//     }
// }
