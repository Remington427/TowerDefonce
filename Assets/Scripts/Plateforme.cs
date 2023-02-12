using UnityEngine;

public class Plateforme : MonoBehaviour
{
    public Color surbrillance;
    private Color parDefaut;

    private GameObject tourelle;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        parDefaut = rend.material.color;
    }

    private void OnMouseDown()
    {
        if(tourelle != null)
        {

        }
        else
        {
            GameObject tourelleAConstruire = Construction.singleton.getTourelleAConstruire();
            tourelle = Instantiate(tourelleAConstruire, transform.position, transform.rotation);
        }
    }

    //lorsque la souris passe sur le collider
    private void OnMouseEnter()
    {
        rend.material.color = surbrillance;
    }

    //lorsque la souris sort du collider
    private void OnMouseExit()
    {
        rend.material.color = parDefaut;
    }
}
