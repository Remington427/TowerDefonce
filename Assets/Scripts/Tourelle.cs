using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourelle : MonoBehaviour
{

    public Transform cible;

    public float portee = 5f;

    public string ennemiTag = "Ennemi";

    public Transform partiePivotante;
    public float vitesseDeRotation = 2f;

    public float cadenceDeTir = 5f;
    private float separTir = 1f;

    public GameObject projectile;
    public Transform spawnProjectile;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateCible", 3f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(cible == null)
        {
            return;
        }
        Rotation();
        if(separTir <= 0)
        {
          Tir();
          separTir = 1/cadenceDeTir;
        }
        separTir -= Time.deltaTime;
    }

    void Rotation()
    {
        //direction vers laquelle regarder
        Vector3 direction = cible.position - transform.position;
        Quaternion regard = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partiePivotante.rotation, regard, vitesseDeRotation * Time.deltaTime).eulerAngles;
        partiePivotante.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Tir()
    {
        GameObject balleObj = Instantiate(projectile, spawnProjectile.position, spawnProjectile.rotation);
        Projectile balle = balleObj.GetComponent<Projectile>();
        balle.recherche(cible);


    }

    void UpdateCible()
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
            cible = ennemiLePlusProche.transform;
        }
        else
        {
            cible = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, portee);
    }
}
