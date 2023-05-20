using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DonneesJoueur : MonoBehaviour
{
    //classe singleton
    public static DonneesJoueur Instance;

    public gestionVagues gestionnaire;

    //affichage des donnees
    public TextMeshProUGUI uiPointDeVie;
    public TextMeshProUGUI uiArgent;
    public TextMeshProUGUI uiDescription;

    //donnees
    public int pointsDeVie;
    public int argent;

    //indique si la partie est terminee
    public bool fin;

    // Start is called before the first frame update
    void Awake()
    {
        //le debut n'est pas la fin
        fin = false;
        //intialise l'instance
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //on met a jour l'UI en "temps reel"
        uiPointDeVie.text = "Vie : " + pointsDeVie.ToString();
        uiArgent.text = "Argent : " + argent.ToString();
    }

    //getter
    public int GetPointDeVie()
    {
        return pointsDeVie;
    }

    //diminue de 'degats' le nombre de PdV, verifie si la partie est perdue
    public void InfligeDegat(int degats)
    {
        pointsDeVie -= degats;
        //si PdV <= 0, partie perdue
        if(pointsDeVie <= 0)
        {
            pointsDeVie = 0;
            //fin de la partie
            fin = true;
        }
    }

    //getter
    public int GetArgent()
    {
        return pointsDeVie;
    }

    //setter
    public void Gain(int montant)
    {
        //verification (il s'agit bien d'un gain)
        if(montant > 0) argent += montant;

    }

    //setter
    public bool Achat(int montant)
    {
        //si pas assez d'argent, achat impossible
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

    //mis a jour de l'UI selon le bouton selectionne
    public void MiseAJourDescription(int bouton)
    {
        if(bouton == 0)
        {
            uiDescription.text = "Passage a la vague suivante...";
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
            uiDescription.text = "Tourelle choisie : mortier (cible les ennemis terrestres, explosif), prix : 35";
        }

    }
}
