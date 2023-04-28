using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gestionVagues : MonoBehaviour
{
    public Transform ennemiBasique;
    public Transform ennemiCostaud;
    public Transform portail;
    public TextMeshProUGUI uiDecompteVague;
    public TextMeshProUGUI uiAffichIndVague;
    private float demarrage = 15f;
    private float intervalleEnnemis = 1f;
    private bool depart = true;
    private int indVague = 0;
    private int nbEnnemis = 1;

    // Update is called once per frame
    void Update()
    {
        if(demarrage <= 0f)
        {
            indVague++;
            nbEnnemis = (int)Mathf.Round(Mathf.Pow(indVague+5,1.25f));
            uiAffichIndVague.text = "Vague " + indVague;
            StartCoroutine(ApparitionVague());
            demarrage = pointsDePassage.points.Length + nbEnnemis;
        }

        if(depart)
        {
            demarrage -= Time.deltaTime;
            uiDecompteVague.text = "Temps avant prochaine vague : " + Mathf.Round(demarrage).ToString();
        }
    }

    IEnumerator ApparitionVague()
    {
        for(int i = 0; i < nbEnnemis; i++)
        {
            if(indVague >2 && i<nbEnnemis/3){
                SpawnCostaud();
            }
            else
            {
                SpawnBasique();
            }
            
            yield return new WaitForSeconds(intervalleEnnemis);
        }

    }

    void SpawnBasique()
    {
        Instantiate(ennemiBasique, portail.position, portail.rotation);
    }

    void SpawnCostaud()
    {
        Instantiate(ennemiCostaud, portail.position, portail.rotation);
    }
}
