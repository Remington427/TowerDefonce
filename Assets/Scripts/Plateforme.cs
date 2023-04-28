using UnityEngine;

public class Plateforme : MonoBehaviour
{
    public Color surbrillance;
    private Color parDefaut;

    private Construction construction;
    private GameObject tourelle;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        construction = Construction.singleton;
        rend = GetComponent<Renderer>();
        parDefaut = rend.material.color;
    }

    private void OnMouseDown()
    {
        if(construction.getTourelleAConstruire() == null || tourelle != null)
        {
            return;
        }
        else
        {
            GameObject tourelleAConstruire = construction.getTourelleAConstruire();
            tourelle = Instantiate(tourelleAConstruire, transform.position, transform.rotation);
        }
    }

    //lorsque la souris passe sur le collider
    private void OnMouseEnter()
    {
        if(construction.getTourelleAConstruire() == null || tourelle != null)
        {
            return;
        }
        
        rend.material.color = surbrillance;
    }

    //lorsque la souris sort du collider
    private void OnMouseExit()
    {
        rend.material.color = parDefaut;
    }
}
