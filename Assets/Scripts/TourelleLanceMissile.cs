using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourelleLanceMissile : MonoBehaviour
{

    public GameObject cible;

    public float portee = 10f;

    public string ennemiTag = "Ennemi";

    public Transform partiePivotante;
    public float vitesseDeRotation = 2f;

    public float cadenceDeTir = 2f;
    private float separTir = 3f;

    public GameObject projectile;
    public Transform spawnProjectile;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateCible", 3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(cible == null)
        {
            return;
        }
        
        Vector3 direction = cible.transform.position - transform.position;
        Rotation(direction);
        // Verif si la tourelle est bien orientee vers la cible
        float angle = Vector3.Angle(direction, partiePivotante.forward);
        if(separTir <= 0 && angle < 30f)
        {
          Tir();
          separTir = 1/cadenceDeTir;
        }
        separTir -= Time.deltaTime;
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
            cible = ennemiLePlusProche;
        }
        else
        {
            cible = null;
        }
    }

    void Rotation(Vector3 direction)
    {
        //direction vers laquelle regarder
        Quaternion regard = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partiePivotante.rotation, regard, vitesseDeRotation * Time.deltaTime).eulerAngles;
        partiePivotante.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Tir()
    {
        GameObject missileObj = Instantiate(projectile, spawnProjectile.position, spawnProjectile.rotation);
        ProjectileGuide missile = missileObj.GetComponent<ProjectileGuide>();
        missile.recherche(cible); 


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, portee);
    }
}
