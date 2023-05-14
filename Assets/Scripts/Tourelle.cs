using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tourelle : MonoBehaviour
{
    public GameObject cible;

    public float portee;

    public int prix;

    public string ennemiTag;

    public float cadenceDeTir;
    protected float separTir;

    public GameObject projectile;
    public Transform spawnProjectile;

    abstract protected void UpdateCible();

    abstract protected void Tir();

    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, portee);
    }
}
