using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon : MonoBehaviour
{
    public int vertices => mesh.vertexCount;
    public string polygonType;
    public Vector3 position;

    private Mesh mesh;

    void Start()
    {

    }


}
