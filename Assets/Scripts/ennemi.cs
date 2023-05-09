using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ennemi : MonoBehaviour
{
    public float vitesse;
    public float pointsDeVie;
    public Vector3 destination;

    public GameObject particuleImpact;

    public void Touche(float degats)
    {
        GameObject particules = Instantiate(particuleImpact, transform.position, transform.rotation);
        Destroy(particules, 2f);
        pointsDeVie -= degats;
        if(pointsDeVie <= 0)
        {
            Destroy(gameObject);
        }
    }

    public Vector3 GetVelocite()
    {
        Vector3 direction = destination - transform.position;
        return direction.normalized * vitesse;
    }
}
