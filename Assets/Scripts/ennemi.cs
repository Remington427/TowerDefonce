using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe abstraite
public abstract class Ennemi : MonoBehaviour
{
    public int degats;
    public float vitesse;
    public float pointsDeVie;
    public int recompense;
    public Vector3 destination;

    public GameObject particuleImpact;

    //on soustrait aux PdV les degats d'un projectile
    public void Touche(float degats)
    {
        GameObject particules = Instantiate(particuleImpact, transform.position, transform.rotation);
        Destroy(particules, 2f);
        pointsDeVie -= degats;
        if(pointsDeVie <= 0.0f)
        {
            DonneesJoueur.Instance.Gain(recompense);
            Destroy(gameObject);
        }
    }

    //l'ennemi est arrive a la base
    public void ObjectifAtteint()
    {
        DonneesJoueur.Instance.InfligeDegat(degats);
        Destroy(gameObject);
    }

    //getter
    public Vector3 GetVelocite()
    {
        Vector3 direction = destination - transform.position;
        return direction.normalized * vitesse;
    }
}
