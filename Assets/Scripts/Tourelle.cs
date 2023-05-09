using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tourelle : MonoBehaviour
{
    public GameObject cible;

    public float portee;

    public string ennemiTag;

    public Transform partiePivotante;
    public float vitesseDeRotation;

    public float cadenceDeTir;
    protected float separTir;

    public GameObject projectile;
    public Transform spawnProjectile;

    abstract protected void UpdateCible();

    abstract protected void Rotation(Vector3 direction);

    abstract protected void Tir();
}
