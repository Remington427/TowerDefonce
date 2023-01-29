using UnityEngine;

public class pointsDePassage : MonoBehaviour
{
    
    public static Vector3[] points;

    void Awake()
    {
        int taille = transform.childCount-1;

        points = new Vector3[taille];

        for(int i = 0; i < taille; i++)
        {
            points[i] = transform.GetChild(taille-(i+1)).position;
        }
    }
}
