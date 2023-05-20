using UnityEngine;

public class Plateforme : MonoBehaviour
{
    //couleur lorsque curseur dessus
    public Color surbrillance;
    //couleur de base
    private Color parDefaut;


    private Construction construction;
    private GameObject tourelle;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        construction = Construction.singleton;
        rend = GetComponent<Renderer>();
        parDefaut = rend.material.color;
    }

    //clic souris
    private void OnMouseDown()
    {
        
        if(construction.getTourelleAConstruire() == null || tourelle != null)
        {
            return;
        }
        //si on a une tourelle a construire et que emplacement libre
        else
        {
            GameObject tourelleAConstruire = construction.getTourelleAConstruire();
            //si on peut acheter la tourelle
            if(DonneesJoueur.Instance.Achat(tourelleAConstruire.GetComponent<Tourelle>().prix))
            {
                tourelle = Instantiate(tourelleAConstruire, transform.position, transform.rotation);
            }
        }
    }

    //lorsque la souris passe sur le collider
    private void OnMouseEnter()
    {
        if(construction.getTourelleAConstruire() == null || tourelle != null)
        {
            return;
        }
        //on indique que l'emplacement est disponible si tourelle selectionnee et que pas encore de tourelle
        rend.material.color = surbrillance;
    }

    //lorsque la souris sort du collider
    private void OnMouseExit()
    {
        //on remet couleur par defaut
        rend.material.color = parDefaut;
    }
}
