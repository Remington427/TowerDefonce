using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourelleMortier : Tourelle
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

    protected override void Tir()
    {
        GameObject mortierObj = Instantiate(projectile, spawnProjectile.position, spawnProjectile.rotation);
        ProjectileMortier mortier = mortierObj.GetComponent<ProjectileMortier>();
        //tire vers le sol la ou etait l'ennemi
        Vector3 coordonnees = cible.transform.position;
        coordonnees.Set(coordonnees.x, 0.0f, coordonnees.z);
        mortier.recherche(coordonnees);
    }
}
