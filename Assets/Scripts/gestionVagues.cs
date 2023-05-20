using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gestionVagues : MonoBehaviour
{
    //classe singleton
    public static gestionVagues Instance;

    //les ennemis a faire spawn
    public Transform ennemiBasique;
    public Transform ennemiCostaud;
    public Transform ennemiVolant;

    //pont de spawn
    public Transform portail;

    //Ui
    public TextMeshProUGUI uiDecompteVague;
    public TextMeshProUGUI uiAffichIndVague;

    //temps avant premiere vague
    public float demarrage = 5f;
    //intervalle entre spawns des ennemis
    private float intervalleEnnemis = 1f;
    private bool depart = false;
    private int indVague = 0;
    private int nbEnnemis = 1;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //si la partie est terminee, affichage du "score"
        if(DonneesJoueur.Instance.fin == true)
        {
            uiAffichIndVague.text = "Fin ! Vague atteinte : " + indVague;
            uiDecompteVague.text = "Fin de la partie";
            return;
        }
        if(demarrage < 0f)
        {
            indVague++;
            nbEnnemis = (int)Mathf.Round(Mathf.Pow(indVague+5,1.25f));
            uiAffichIndVague.text = "Vague " + indVague;
            StartCoroutine(ApparitionVague());
            demarrage = (pointsDePassage.points.Length + nbEnnemis);
        }

        //si partie demarree
        if(depart)
        {
            demarrage -= Time.deltaTime;
            uiDecompteVague.text = "Temps avant prochaine vague : " + Mathf.Round(demarrage).ToString();
        }
        else
        {
            uiDecompteVague.text = "Timer en attente";
            uiAffichIndVague.text = "Appuyez sur la touche 'Entree' pour demarrer";

            //lancement
            if(Input.GetKey(KeyCode.Return))
            {
                depart = true;
                uiAffichIndVague.text = "Démarrage...";
            }

        }
    }

    public void PasserVague()
    {
        if(depart && demarrage < (pointsDePassage.points.Length + nbEnnemis)/1.5)
        {
            DonneesJoueur.Instance.Gain((int)(demarrage) - 15);
            demarrage = 0f;
        }
    }

    public int GetIndVague()
    {
        return indVague;
    }

    IEnumerator ApparitionVague()
    {
        for(int i = 0; i < nbEnnemis; i++)
        {
            if (indVague < 3)
            {
                SpawnBasique();
            }
            else if(indVague%5 == 0)
            {
                SpawnVolant();
            }
            else
            {
                if(i<nbEnnemis/3)
                {
                    SpawnCostaud();
                }
                else
                {
                    SpawnBasique();
                }
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

    void SpawnVolant()
    {
        Instantiate(ennemiVolant, portail.position, portail.rotation);
    }
}
