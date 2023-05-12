using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlesCam : MonoBehaviour
{
    public float vitesseMouvement = 10f;
    public float vitesseZoom = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mouvements
        if((Input.GetKey(KeyCode.Z) || Input.mousePosition.y >= Screen.height - 10f) && transform.position.z <= 10)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * vitesseMouvement, Space.World);
        }
        else if((Input.GetKey(KeyCode.S) || Input.mousePosition.y <= 10f) && transform.position.z >= -10)
        {
            transform.Translate(Vector3.back * Time.deltaTime * vitesseMouvement, Space.World);
        }
        if((Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - 10f) && transform.position.x <= 10)
        {
            transform.Translate(Vector3.right * Time.deltaTime * vitesseMouvement, Space.World);
        }
        else if((Input.GetKey(KeyCode.Q) || Input.mousePosition.x <= 10f) && transform.position.x >= 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * vitesseMouvement, Space.World);
        }

        //zoom
        if(Input.GetKey(KeyCode.E) && transform.position.y >= 5f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * vitesseZoom, Space.Self);
        }
        //dezoom
        else if(Input.GetKey(KeyCode.A) && transform.position.y <= 20f)
        {
            transform.Translate(Vector3.back * Time.deltaTime * vitesseZoom, Space.Self);
        }
    }
}
