using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemi : MonoBehaviour
{
    private float vitesse = 3f;

    private Vector3 destination;
    private int indicePointsDePassage;
    
    // Start is called before the first frame update
    void Start()
    {
        destination = pointsDePassage.points[0];
        destination.Set(destination.x, transform.position.y, destination.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = destination - transform.position;
        transform.Translate(direction.normalized * vitesse * Time.deltaTime);

        if(Vector3.Distance(transform.position, destination) <= 0.03f * vitesse)
        {
            if(indicePointsDePassage >= pointsDePassage.points.Length - 1){
                Destroy(gameObject);
            }
            else{
                indicePointsDePassage++;
                destination = pointsDePassage.points[indicePointsDePassage];
                destination.Set(destination.x, transform.position.y, destination.z);
            }
        }
    }
}
