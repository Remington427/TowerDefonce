using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonneesJoueur : MonoBehaviour
{
    public static DonneesJoueur Instance;

    private int pointsDeVie;
    private int argent;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
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
