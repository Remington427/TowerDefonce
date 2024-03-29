using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourelleLanceMissile : TourellePivotante
{

    // Start is called before the first frame update
    void Start()
    {
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
        
        Vector3 direction = cible.transform.position - transform.position;
        Rotation(direction);
        // Verif si la tourelle est bien orientee vers la cible
        //float angle = Vector3.Angle(direction, partiePivotante.forward);
        if(separTir <= 0f)
        {
          Tir();
          separTir = 1/cadenceDeTir;
        }
        separTir -= Time.deltaTime;
    }

    protected override void UpdateCible()
    {
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
        GameObject missileObj = Instantiate(projectile, spawnProjectile.position, spawnProjectile.rotation);
        ProjectileGuide missile = missileObj.GetComponent<ProjectileGuide>();
        missile.recherche(cible); 


    }
}
