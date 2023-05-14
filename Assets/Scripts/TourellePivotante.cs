using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TourellePivotante : Tourelle
{
    public Transform partiePivotante;
    public float vitesseDeRotation;
    
    abstract protected void Rotation(Vector3 direction);
}
