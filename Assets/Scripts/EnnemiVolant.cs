using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiVolant : Ennemi
{
    //phase de vol de l'ennemi volant
    private bool decolle;
    private bool arrive;
    
    // Start is called before the first frame update
    void Start()
    {
        //les PdV augmente avec la vague
        pointsDeVie += Mathf.Pow(gestionVagues.Instance.GetIndVague(),1.5f);

        //le decolage n'est pas termine
        decolle = false;
        //l'ennemi n'est pas arrive au dessus de l'objectif
        arrive = false;
        destination = transform.position;
        //prochaine destination : decollage au dessus du spawn
        destination.Set(destination.x, 5f, destination.z);
    }

    // Update is called once per frame
    void Update()
    {
        //si partie terminee, jeu "en pause"
        if(DonneesJoueur.Instance.fin == true)
        {
            return;
        }
        //calcul de la direction
        Vector3 direction = destination - transform.position;
        transform.position += direction.normalized * vitesse * Time.deltaTime;
        //si le prochain point de passage est atteint
        if(Vector3.Distance(transform.position, destination) <= 0.03f * vitesse)
        {
            //si phase de decollage, passage a la phase de deplacement
            if(!decolle){
                decolle = true;
                destination = pointsDePassage.points[pointsDePassage.points.Length - 1];
                destination.Set(destination.x, 5f, destination.z);
                return;
            }
            //si phase de deplacement, passage a l'atterissage
            if(!arrive){
                arrive = true;
                destination = pointsDePassage.points[pointsDePassage.points.Length - 1];
                return;
            }
            //sinon, c'est l'arrive
            else{
                ObjectifAtteint();
            }
        }
        else
        {
            //on fait tourner l'objet pour qu'il regarde en direction de la destination
            transform.LookAt(destination);
        }
    }
}
