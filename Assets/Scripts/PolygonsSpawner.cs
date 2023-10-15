using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonsSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject go;

    void Start()
    {
        
        for (int i= 0; i < 10; i++)
        {
            for(int j=0; j < 10; j++)
            {
                Instantiate(go, transform.position + new Vector3(j, 0, i), Quaternion.identity);
            }
        }
    }
}
