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

    public bool fin;

    // Start is called before the first frame update
    void Awake()
    {
        fin = false;
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
        if(pointsDeVie <= 0)
        {
            pointsDeVie = 0;
            fin = true;
        }
    }

    public int GetArgent()
    {
        return pointsDeVie;
    }

    public void Gain(int montant)
    {
        if(montant > 0) argent += montant;

    }

    public void MiseAJourDescription(int bouton)
    {
        if(bouton == 0)
        {
            uiDescription.text = "Passage a la vague suivante";
        }
        if(bouton == 1)
        {
            uiDescription.text = "Tourelle choisie : basique (cible les ennemis terrestres), prix : 20";
        }
        if(bouton == 2)
        {
            uiDescription.text = "Tourelle choisie : lance-missile (cible les ennemis volants, missiles et explosif), prix : 50";
        }

        if(bouton == 3)
        {
            uiDescription.text = "Tourelle choisie : mortier (cible les ennemis terrestres, explosif), prix : 30";
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
