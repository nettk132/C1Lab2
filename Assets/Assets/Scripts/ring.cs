using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class RingGenerator : MonoBehaviour
{
    [Range(3, 256)]
    public int segments = 64;
    public float innerRadius = 0.5f;
    public float outerRadius = 1f;
    public float thickness = 0.1f;

    private Mesh mesh;

    void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateRing();
    }

    void CreateRing()
    {
        Vector3[] vertices = new Vector3[segments * 4];
        int[] triangles = new int[segments * 12];
        Vector2[] uv = new Vector2[vertices.Length];
        float angleStep = 360.0f / segments;
        float currentAngle = 0f;

        for (int i = 0; i < segments; i++)
        {
            int vertexIndex = i * 4;
            int triangleIndex = i * 12;

            float rad = Mathf.Deg2Rad * currentAngle;
            float nextRad = Mathf.Deg2Rad * (currentAngle + angleStep);

            // Inner vertices
            vertices[vertexIndex] = new Vector3(Mathf.Cos(rad) * innerRadius, 0, Mathf.Sin(rad) * innerRadius);
            vertices[vertexIndex + 1] = new Vector3(Mathf.Cos(nextRad) * innerRadius, 0, Mathf.Sin(nextRad) * innerRadius);

            // Outer vertices
            vertices[vertexIndex + 2] = new Vector3(Mathf.Cos(rad) * outerRadius, 0, Mathf.Sin(rad) * outerRadius);
            vertices[vertexIndex + 3] = new Vector3(Mathf.Cos(nextRad) * outerRadius, 0, Mathf.Sin(nextRad) * outerRadius);

            // Triangles
            triangles[triangleIndex] = vertexIndex;
            triangles[triangleIndex + 1] = vertexIndex + 2;
            triangles[triangleIndex + 2] = vertexIndex + 1;

            triangles[triangleIndex + 3] = vertexIndex + 1;
            triangles[triangleIndex + 4] = vertexIndex + 2;
            triangles[triangleIndex + 5] = vertexIndex + 3;

            triangles[triangleIndex + 6] = vertexIndex;
            triangles[triangleIndex + 7] = vertexIndex + 2;
            triangles[triangleIndex + 8] = vertexIndex + 1;

            triangles[triangleIndex + 9] = vertexIndex + 1;
            triangles[triangleIndex + 10] = vertexIndex + 2;
            triangles[triangleIndex + 11] = vertexIndex + 3;

            // UVs
            uv[vertexIndex] = new Vector2(0, 0);
            uv[vertexIndex + 1] = new Vector2(1, 0);
            uv[vertexIndex + 2] = new Vector2(0, 1);
            uv[vertexIndex + 3] = new Vector2(1, 1);

            currentAngle += angleStep;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.RecalculateNormals();
    }
}
