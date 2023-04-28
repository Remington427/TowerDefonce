using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 direction;

    private float vitesse = 10f;

    private float degats = 2f;

    void Start()
    {
        InvokeRepeating("FinDeVie", 5f, 5f);
    }

    public void recherche(Vector3 _direction)
    {
        direction = _direction;
    }

    // Update is called once per frame
    void Update()
    {

        //direction = (direction - transform.position).normalized;
        float distance = vitesse * Time.deltaTime;
        Collisions(direction, distance);       
        transform.Translate(direction * distance, Space.World);

        
    }

    void Collisions(Vector3 direction, float distance)
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 0.1f, direction, distance);
        foreach(RaycastHit hit in hits)
        {
            GameObject objetTouche = hit.collider.gameObject;
            if(objetTouche.GetComponent<Ennemi>() != null)
            {
                Ennemi ennemi = objetTouche.GetComponent<Ennemi>();
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
