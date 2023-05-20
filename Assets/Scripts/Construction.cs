using UnityEngine;

public class Construction : MonoBehaviour
{
    //classe singleton
    public static Construction singleton;
    //tourelle a construire lors du prochain clic sur une case libre
    private GameObject tourelleAConstruire;


    private void Awake()
    {
        //initialise l'instance
        singleton = this;
    }
    
    //getter
    public GameObject getTourelleAConstruire()
    {
        return tourelleAConstruire;
    }

    //setter
    public void setTourelleAConstruire(GameObject tourelle)
    {
        tourelleAConstruire = tourelle;
    }
}
