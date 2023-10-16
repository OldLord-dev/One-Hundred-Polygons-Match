using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonsSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject go;

    private void OnEnable()
    {
        
        for (int i= 0; i < 10; i++)
        {
            for(int j=0; j < 10; j++)
            {
                GameObject polygon = Pool.singleton.Get("Polygon");
                polygon.transform.position += transform.position + new Vector3(j, 0, i);
                polygon.SetActive(true);
            }
        }
    }

    private void OnDisable()
    {
       // List<GameObject> pooledPolygons = Pool.singleton.pooledItems;
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag ("Polygon");
        foreach (GameObject polygon in gameObjectArray)
        {
            polygon.transform.position = new Vector3(0, 0.01f, 0);
            polygon.SetActive(false);
        }
    }
}
