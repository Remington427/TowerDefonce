using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform cible;

    public GameObject particuleImpact;

    public float vitesse = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void recherche(Transform _cible)
    {
        cible = _cible;
    }

    // Update is called once per frame
    void Update()
    {
        if(cible == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = cible.position - transform.position;
        float distance = vitesse * Time.deltaTime;
        
        if(direction.magnitude <= distance)
        {
            CibleTouchee();
            return;
        }

        transform.Translate(direction.normalized * distance, Space.World);

        
    }

    void CibleTouchee()
    {
        GameObject particules = Instantiate(particuleImpact, transform.position, transform.rotation);
        Destroy(particules, 2f);
        Destroy(gameObject);
    }
}
