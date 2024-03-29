using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourelleBasique : TourellePivotante
{

    // Start is called before the first frame update
    void Start()
    {
        //on met a jour la cible toutes les 3s
        InvokeRepeating("UpdateCible", 3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //si fin, jeu "en pause"
        if(DonneesJoueur.Instance.fin == true || cible == null)
        {
            return;
        }
        //si la cible s'eloigne, changer de cible
        if(Vector3.Distance(cible.transform.position, transform.position)>portee)
        {
            UpdateCible();
        }
        //calcul direction
        Vector3 direction = cible.transform.position - transform.position;
        //rotation vers direction
        Rotation(direction);
        // Verif si la tourelle est bien orientee vers la cible
        float angle = Vector3.Angle(direction, partiePivotante.forward);
        if(separTir <= 0 && angle < 15f)
        {
          Tir();
          separTir = 1/cadenceDeTir;
        }
        separTir -= Time.deltaTime;
    }

    protected override void UpdateCible()
    {
        if(cible != null)
        {
            return;
        }
        GameObject[] ennemis = GameObject.FindGameObjectsWithTag(ennemiTag);
        float distanceMin = Mathf.Infinity;
        GameObject ennemiLePlusProche = null;
        //on parcourt tous les ennemis de la scene
        foreach (GameObject ennemi in ennemis)
        {
            float distance = Vector3.Distance(transform.position, ennemi.transform.position);
            if(distance < distanceMin)
            {
                distanceMin = distance;
                ennemiLePlusProche = ennemi;
            }
        }

        if(ennemiLePlusProche != null && distanceMin <= portee)
        {
            cible = ennemiLePlusProche;
        }
        else
        {
            cible = null;
        }
    }

    protected override void Rotation(Vector3 direction)
    {
        //direction vers laquelle regarder
        Quaternion regard = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partiePivotante.rotation, regard, vitesseDeRotation * Time.deltaTime).eulerAngles;
        partiePivotante.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    protected override void Tir()
    {
        GameObject balleObj = Instantiate(projectile, spawnProjectile.position, spawnProjectile.rotation);
        Projectile balle = balleObj.GetComponent<Projectile>();
        balle.recherche(CalculBallistique(spawnProjectile.position, cible)); 


    }

    private Vector3 CalculBallistique(Vector3 depart, GameObject cible)
    {
        float distance = Vector3.Distance(depart, cible.transform.position);
        //positionCible - positionDepart
        //return (cible.transform.position - depart).normalized;
        //variante
        EnnemiTerrestre ennemi = cible.GetComponent<EnnemiTerrestre>();
        return (calculPosition(cible.transform.position, spawnProjectile.position, ennemi.GetVelocite(), 10f) - depart).normalized;

    }

    //prediction de la position de la cible
    private Vector3 calculPosition(Vector3 targetPosition, Vector3 shooterPosition, Vector3 targetVelocity, float projectileSpeed)
    {
        Vector3 displacement = targetPosition - shooterPosition;
        float targetMoveAngle = Vector3.Angle(-displacement, targetVelocity) * Mathf.Deg2Rad;
        //if the target is stopping or if it is impossible for the projectile to catch up with the target (Sine Formula)
        if (targetVelocity.magnitude == 0 || targetVelocity.magnitude > projectileSpeed && Mathf.Sin(targetMoveAngle) / projectileSpeed > Mathf.Cos(targetMoveAngle) / targetVelocity.magnitude)
        {
            Debug.Log("Position prediction is not feasible.");
            return targetPosition;
        }
        //also Sine Formula
        float shootAngle = Mathf.Asin(Mathf.Sin(targetMoveAngle) * targetVelocity.magnitude / projectileSpeed);
        return targetPosition + targetVelocity * displacement.magnitude / Mathf.Sin(Mathf.PI - targetMoveAngle - shootAngle) * Mathf.Sin(shootAngle) / targetVelocity.magnitude;
    }
}
