using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiTerrestre : Ennemi
{
    private int indicePointsDePassage;
    
    // Start is called before the first frame update
    void Start()
    {
        //les PdV augmente avec la vague
        pointsDeVie += Mathf.Pow(gestionVagues.Instance.GetIndVague(),1.2f);

        destination = pointsDePassage.points[0];
        destination.Set(destination.x, transform.localScale.y/2+0.1f, destination.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(DonneesJoueur.Instance.fin == true)
        {
            return;
        }
        Vector3 direction = destination - transform.position;
        transform.position += direction.normalized * vitesse * Time.deltaTime;
        if(Vector3.Distance(transform.position, destination) <= 0.03f * vitesse)
        {
            if(indicePointsDePassage >= pointsDePassage.points.Length - 1){
                ObjectifAtteint();
            }
            else{
                indicePointsDePassage++;
                //on cible la cible suivante
                destination = pointsDePassage.points[indicePointsDePassage];
                destination.Set(destination.x, transform.position.y, destination.z);
            }
        }
    }
}
