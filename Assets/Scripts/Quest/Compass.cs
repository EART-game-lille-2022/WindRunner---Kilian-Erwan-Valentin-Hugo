using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab du projectile à tirer
    public Transform firePoint; // Point de départ du tir
    public Transform target; // Cible à viser
    public float projectileSpeed = 10f; // Vitesse du projectile
    public float fireRate = 1f; // Cadence de tir en secondes
    private float nextFireTime = 0f; // Temps du prochain tir

    void Update()
    {
        if (Time.time >= nextFireTime && target != null)
        {
            AimAtTarget();
            Shoot();
            nextFireTime = Time.time + 1f / fireRate; // Calcul du prochain temps de tir
        }
    }

    void AimAtTarget()
    {
        if (target != null && firePoint != null)
        {
            // Faire en sorte que le firePoint regarde la cible
            firePoint.LookAt(target);
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null || firePoint == null)
        {
            Debug.LogError("Veuillez assigner le prefab du projectile et le point de départ du tir.");
            return;
        }

        // Créer une instance du projectile
        GameObject newProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Accéder au Rigidbody du projectile et lui donner une vitesse
        Rigidbody projectileRb = newProjectile.GetComponent<Rigidbody>();
        if (projectileRb != null)
        {
            projectileRb.velocity = firePoint.forward * projectileSpeed;
        }
        else
        {
            Debug.LogError("Le prefab du projectile doit avoir un composant Rigidbody pour être tiré.");
            return;
        }
    }
}