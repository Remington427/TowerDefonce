using System.Collections;
using UnityEngine;

public class gestionVagues : MonoBehaviour
{
    [SerializeField] private Transform ennemiBasique;
    [SerializeField] private Transform portail;
    private float demarrage = 5f;
    private float intervalle = 10f;
    private float intervalleEnnemis = 1f;
    private bool depart = true;
    private int indVague = 0;

    // Update is called once per frame
    void Update()
    {
        if(demarrage <= 0f)
        {
            indVague++;
            StartCoroutine(ApparitionVague());
            demarrage = intervalle + indVague;
        }

        if(depart)
        {
            demarrage -= Time.deltaTime;
        }
    }

    IEnumerator ApparitionVague()
    {
        for(int i = 0; i < indVague; i++)
        {
            Spawn();
            yield return new WaitForSeconds(intervalleEnnemis);
        }

    }

    void Spawn()
    {
        Instantiate(ennemiBasique, portail.position, portail.rotation);
    }
}
