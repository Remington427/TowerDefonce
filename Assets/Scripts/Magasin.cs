using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magasin : MonoBehaviour
{
    //tourelle a construire
    public GameObject tourelleBasique;
    public GameObject tourelleLanceMissile;
    public GameObject tourelleMortier;

    //classe singleton
    public static Magasin Instance;

    //contruction associe
    private Construction construction;

    void Start()
    {
        Instance = this;
        construction = Construction.singleton;
    }

    public void AchatTourelleBasique()
    {
        //construction;
        construction.setTourelleAConstruire(tourelleBasique);
        //on met a jour la description de la tourelle choisie
        DonneesJoueur.Instance.MiseAJourDescription(1);
    }

    public void AchatLanceMissile()
    {
        //construction;
        construction.setTourelleAConstruire(tourelleLanceMissile);
        //on met a jour la description de la tourelle choisie
        DonneesJoueur.Instance.MiseAJourDescription(2);
    }

    public void AchatMortier()
    {
        //construction;
        construction.setTourelleAConstruire(tourelleMortier);
        //on met a jour la description de la tourelle choisie
        DonneesJoueur.Instance.MiseAJourDescription(3);
    }

    public void PasserVague()
    {
        DonneesJoueur.Instance.MiseAJourDescription(0);
        gestionVagues.Instance.PasserVague();
    }
}
