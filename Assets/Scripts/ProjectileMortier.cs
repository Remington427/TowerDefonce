using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMortier : Projectile
{
    public GameObject particuleExplosion;

    public float rayonExplosion = 5f;
    
    void Update()
    {
        if(DonneesJoueur.Instance.fin == true)
        {
            return;
        }
        
        transform.LookAt(direction);
        Vector3 _direction = direction - transform.position;
        float distance = vitesse * Time.deltaTime;

        if (_direction.magnitude <= distance)
        {
            transform.position = direction;
            Explosion();
        }
        else
        {
            transform.Translate(_direction.normalized * distance, Space.World);
        }
    }

    void ParabolicMovement()
    {
        // On calcule la hauteur maximale atteinte par le projectile
        float height = Mathf.Max(direction.y, transform.position.y) + 1f;
 
        // On calcule la distance horizontale entre le projectile et la cible
        float distance = Vector3.Distance(transform.position, direction);
 
        // On calcule la duree du mouvement parabolique
        float duration = distance / vitesse;
 
        // On calcule la vitesse initiale necessaire pour atteindre la cible
        float initialVelocity = distance / duration;
 
        // On calcule les composantes de la vitesse initiale
        float horizontalVelocity = initialVelocity;
        float verticalVelocity = (height - transform.position.y) / duration + 0.5f * Physics.gravity.y * duration;
 
        // On applique la vitesse initiale
        Vector3 velocity = horizontalVelocity * (direction - transform.position).normalized + verticalVelocity * Vector3.up;
        transform.Translate(velocity * Time.deltaTime, Space.World);
 
        // On fait tourner le projectile pour qu'il regarde vers la cible
        transform.rotation = Quaternion.LookRotation(velocity);
    }

    void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, rayonExplosion);
        foreach (Collider collider in colliders)
        {
            if(collider.gameObject.tag == "Ennemi")
            {
                EnnemiTerrestre ennemi = collider.gameObject.GetComponent<EnnemiTerrestre>();

                // calcul de la distance entre le projectile et l'ennemi
                float distance = Vector3.Distance(transform.position, ennemi.transform.position);

                // limitation de la distance a un minimum de 1 et un maximum de rayonExplosion
                float distanceLimitee = Mathf.Clamp(distance, 1, rayonExplosion);

                // calcul des degats proportionnels a la distance
                float degatsProportionnels = degats * (1 - (distanceLimitee / rayonExplosion));

                // appliquer les degats a l'ennemi
                ennemi.Touche(degatsProportionnels);
            }

        }
        GameObject particules = Instantiate(particuleExplosion, transform.position, transform.rotation);
        Destroy(particules, 2f);
        Destroy(gameObject);
    }

    void FinDeVie()
    {
        Explosion();
    }
}
