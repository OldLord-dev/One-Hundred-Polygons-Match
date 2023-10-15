using UnityEngine;
using UnityEngine.Rendering;

public enum PolygonType
{
   A, B, C, Count
};
public class PolygonCreator : MonoBehaviour
{
    [SerializeField] private Material material;
    [HideInInspector] public MeshRenderer meshRenderer;
    private float radius = 0.3f;
    public int numVertices;
    Vector3[] vertices;
    Mesh mesh;
    MeshCollider meshCollider;
    public PolygonType polygonType;

    void Awake()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshCollider = gameObject.AddComponent<MeshCollider>();
        mesh = new Mesh();
        meshRenderer.material = material;
        meshFilter.mesh = mesh;

        CreateVertices(Random.Range(3, 7));
        polygonType = (PolygonType)Random.Range(0, 3);
        SetRandomShape(polygonType);
        CreateTriangles();

    }
    public void CreatePolygon(int numOfVertices, PolygonType polygonType)
    {
        mesh.Clear();
        CreateVertices(numOfVertices);
        SetRandomShape(polygonType);
        CreateTriangles();
    }
    private void CreateVertices(int numOfVertices)
    {
        numVertices = numOfVertices;
        float angle = 2 * Mathf.PI / numVertices;

        // Create the vertices around the polygon.
        vertices = new Vector3[numVertices];
        for (int i = 0; i < numVertices; i++)
        {
            vertices[i] = new Vector3(Mathf.Sin(i * angle), 0, Mathf.Cos(i * angle)) * radius;

        }
    }
    private void CreateTriangles()
    {
        mesh.vertices = vertices;
        // The triangle vertices must be done in clockwise order.
        int[] triangles = new int[3 * (numVertices - 2)];
        for (int i = 0; i < numVertices - 2; i++)
        {
            triangles[3 * i] = 0;
            triangles[(3 * i) + 1] = i + 1;
            triangles[(3 * i) + 2] = i + 2;
        }
        mesh.triangles = triangles;
        meshCollider.sharedMesh = mesh;
        meshCollider.convex = true;
    }
    private void SetRandomShape(PolygonType polygonType)
    {
        switch (polygonType)
        {
            case PolygonType.A:
            {
                PolygonShapeA();
                break;
            }
            case PolygonType.B:
            {
                PolygonShapeB();
                break;
            }
            case PolygonType.C:
            {
                PolygonShapeC();
                break;
            }
        }


    }
    private void PolygonShapeA()
    {
        polygonType = PolygonType.A;
    }
    private void PolygonShapeB() 
    { 
        vertices[0] += new Vector3(0.1f, 0, 0.1f);
        polygonType = PolygonType.B;
    }
    private void PolygonShapeC()
    {
        vertices[numVertices-1] += new Vector3(0.1f, 0, 0);
        polygonType = PolygonType.C;
    }
}