using UnityEngine;

public class Construction : MonoBehaviour
{
    public static Construction singleton;

    public GameObject tourelleParDefaut;
    private GameObject tourelleAConstruire;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        tourelleAConstruire = tourelleParDefaut;
    }
    
    public GameObject getTourelleAConstruire()
    {
        return tourelleAConstruire;
    }
}
