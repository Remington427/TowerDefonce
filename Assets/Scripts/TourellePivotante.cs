using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe abstraite qui represente les tourelles avec partie pivotante
public abstract class TourellePivotante : Tourelle
{
    public Transform partiePivotante;
    public float vitesseDeRotation;
    
    abstract protected void Rotation(Vector3 direction);
}
