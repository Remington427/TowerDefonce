using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe abstraite de tourelle
public abstract class Tourelle : MonoBehaviour
{
    public GameObject cible;

    public float portee;

    public int prix;

    //type d'ennemi a cible
    public string ennemiTag;

    public float cadenceDeTir;
    //permet calcul temps entre tir
    protected float separTir;

    //type de projectile
    public GameObject projectile;
    //point d'apparition du projectile
    public Transform spawnProjectile;

    abstract protected void UpdateCible();

    abstract protected void Tir();

    //Debug, permet de voir la portee dans la scene
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, portee);
    }
}
