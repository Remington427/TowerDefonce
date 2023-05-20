using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;

    public float vitesse;

    public float degats;

    void Start()
    {
        //on detruit le projectile apres 5s
        InvokeRepeating("FinDeVie", 5f, 5f);
    }

    //initialisation de la direction cible par tourelle
    public void recherche(Vector3 _direction)
    {
        direction = _direction;
    }

    // Update is called once per frame
    void Update()
    {
        if(DonneesJoueur.Instance.fin == true)
        {
            return;
        }

        //direction = (direction - transform.position).normalized;
        float distance = vitesse * Time.deltaTime;
        Collisions(direction, distance);       
        transform.Translate(direction * distance, Space.World);

        
    }

    //verifie si le projectile touche
    void Collisions(Vector3 direction, float distance)
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 0.1f, direction, distance);
        foreach(RaycastHit hit in hits)
        {
            GameObject objetTouche = hit.collider.gameObject;
            if(objetTouche.GetComponent<EnnemiTerrestre>() != null)
            {
                EnnemiTerrestre ennemi = objetTouche.GetComponent<EnnemiTerrestre>();
                ennemi.Touche(degats);
                FinDeVie();
                break;
            }
        }
    }

    void FinDeVie()
    {
        Destroy(gameObject);
    }
}
