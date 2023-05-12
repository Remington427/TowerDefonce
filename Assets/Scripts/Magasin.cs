using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magasin : MonoBehaviour
{
    public GameObject tourelleBasique;
    public GameObject tourelleLanceMissile;

    public static Magasin Instance;
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
}
