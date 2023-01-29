using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlesCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //mouvements
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical"));
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal"));

        //orientation
        //transform.Rotate (-3 * Input.GetAxis ("Mouse Y"), 3 * Input.GetAxis ("Mouse X"), 0, Space.Self);
    }
}
