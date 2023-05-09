using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiVolant : Ennemi
{
    private bool decolle;
    private bool arrive;
    
    // Start is called before the first frame update
    void Start()
    {
        decolle = false;
        arrive = false;
        destination = transform.position;
        destination.Set(destination.x, 5f, destination.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = destination - transform.position;
        transform.position += direction.normalized * vitesse * Time.deltaTime;
        if(Vector3.Distance(transform.position, destination) <= 0.03f * vitesse)
        {
            if(!decolle){
                decolle = true;
                destination = pointsDePassage.points[pointsDePassage.points.Length - 1];
                destination.Set(destination.x, 5f, destination.z);
                return;
            }
            if(!arrive){
                arrive = true;
                destination = pointsDePassage.points[pointsDePassage.points.Length - 1];
                return;
            }
            else{
                Destroy(gameObject);
            }
        }
        else
        {
            //on fait tourner l'objet pour qu'il regarde en direction de la destination
            transform.LookAt(destination);
        }
    }
}
