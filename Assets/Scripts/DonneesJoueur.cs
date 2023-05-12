using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DonneesJoueur : MonoBehaviour
{
    //classe singleton
    public static DonneesJoueur Instance;

    public gestionVagues gestionnaire;

    public TextMeshProUGUI uiPointDeVie;
    public TextMeshProUGUI uiArgent;
    public TextMeshProUGUI uiDescription;

    public int pointsDeVie;
    public int argent;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        uiPointDeVie.text = "Vie : " + pointsDeVie.ToString();
        uiArgent.text = "Argent : " + argent.ToString();
    }

    public int GetPointDeVie()
    {
        return pointsDeVie;
    }

    public void InfligeDegat(int degats)
    {
        pointsDeVie -= degats;
    }

    public int GetArgent()
    {
        return pointsDeVie;
    }

    public void Gain(int montant)
    {
        argent += montant;

    }

    public void MiseAJourDescription(int tourelle)
    {
        if(tourelle == 1)
        {
            uiDescription.text = "Tourelle choisie : basique (cible les ennemis terrestres)";
        }
        if(tourelle == 2)
        {
            uiDescription.text = "Tourelle choisie : lance-missile (cible les ennemis volants, missiles et explosions)";
        }

    }

    public bool Achat(int montant)
    {
        if(montant > argent)
        {
            return false;
        }
        else
        {
            argent -= montant;
            return true;
        }
    }
}
