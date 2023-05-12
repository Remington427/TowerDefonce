using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGuide : Projectile
{
    private GameObject cible;

    public GameObject particuleExplosion;

    public float rayonExplosion = 5f;

    public void recherche(GameObject _cible)
    {
        cible = _cible;
    }

    // Update is called once per frame
    void Update()
    {
        if(cible == null)
        {
            Explosion();
            return;
        }
        Vector3 direction = cible.transform.position - transform.position;
        float distance = vitesse * Time.deltaTime;
        if((cible.transform.position - transform.position).magnitude <= distance)
        {
            //
            Explosion();
            return;
        }    
        transform.Translate(direction.normalized * distance, Space.World);
        transform.LookAt(cible.transform);

        
    }

    void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, rayonExplosion);
        foreach (Collider collider in colliders)
        {
            if(collider.gameObject.tag == "EnnemiVolant")
            {
                EnnemiVolant ennemi = collider.gameObject.GetComponent<EnnemiVolant>();

                // calcul de la distance entre le projectile et l'ennemi
                float distance = Vector3.Distance(transform.position, ennemi.transform.position);

                // limitation de la distance a un minimum de 1 et un maximum de rayonExplosion
                float distanceLimitee = Mathf.Clamp(distance, 1, rayonExplosion);

                // calcul des degats proportionnels a la distance
                float degatsProportionnels = degats * (1 - (distanceLimitee / rayonExplosion));

                // appliquer les degats a l'ennemi
                ennemi.Touche(degatsProportionnels);
            }
            /*
            else if(collider.gameObject.tag == "Terrestre")
            {
                EnnemiTerrestre ennemi = collider.gameObject.GetComponent<EnnemiTerrestre>();
                ennemi.Touche(degats);
            }
            */

        }

        FinDeVie();
    }

    void FinDeVie()
    {
        GameObject particules = Instantiate(particuleExplosion, transform.position, transform.rotation);
        Destroy(particules, 2f);
        Destroy(gameObject);
    }
}
