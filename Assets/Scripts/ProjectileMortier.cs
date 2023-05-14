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
