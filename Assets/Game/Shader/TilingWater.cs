using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UIElements;

[ExecuteInEditMode]
public class TilingWater : MonoBehaviour
{
    #region OTHERS

    Transform _boat;
    bool _hasBoat = false;

#endregion


    [Header("GENERATE")]
    public int widthSegments = 10; // Number of segments along the width of the plane
    public int lengthSegments = 10; // Number of segments along the length of the plane
    public float width = 10f; // Width of the plane
    public float length = 10f; // Length of the plane


    [Button]
    Mesh GenerateMesh()
    {
        //transform.localScale = new Vector3(width, height, length);

        MeshFilter meshFilter = new MeshFilter();
        TryGetComponent(out meshFilter);
        if (meshFilter == null)
        {
            meshFilter = gameObject.AddComponent<MeshFilter>();
        }

        MeshRenderer meshRenderer = new MeshRenderer();
        TryGetComponent(out meshRenderer);
        if (meshRenderer == null)
        {
            gameObject.AddComponent<MeshRenderer>();
        }

        Mesh mesh = new Mesh();

        // Calculate the total number of vertices and triangles
        int numVertices = (widthSegments + 1) * (lengthSegments + 1);
        int numTriangles = widthSegments * lengthSegments * 6;

        // Create arrays to store vertices, UV coordinates, and triangles
        Vector3[] vertices = new Vector3[numVertices];
        Vector2[] uv = new Vector2[numVertices];
        int[] triangles = new int[numTriangles];

        // Calculate the step size between each vertex along the width and length
        float widthStep = width / widthSegments;
        float lengthStep = length / lengthSegments;

        int index = 0;

        // Generate vertices and UV coordinates
        for (int i = 0; i <= lengthSegments; i++)
        {
            for (int j = 0; j <= widthSegments; j++)
            {
                float x = (j * widthStep) - (width / 2f);
                float z = (i * lengthStep) - (length / 2f);
                vertices[index] = new Vector3(x, 0f, z);
                uv[index] = new Vector2((float)j / widthSegments, (float)i / lengthSegments);
                index++;
            }
        }

        index = 0;
        // Generate triangles with inverted order
        for (int i = 0; i < lengthSegments; i++)
        {
            for (int j = 0; j < widthSegments; j++)
            {
                int a = i * (widthSegments + 1) + j;
                int b = a + 1;
                int c = a + widthSegments + 1;
                int d = c + 1;

                triangles[index] = a;
                triangles[index + 1] = c;
                triangles[index + 2] = b;

                triangles[index + 3] = b;
                triangles[index + 4] = c;
                triangles[index + 5] = d;

                index += 6;
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        mesh.RecalculateBounds();
        mesh.name = "WaterMeshPlane";
        meshFilter.mesh = mesh;        
        return mesh;
    }
    private void Start()
    {
        _boat = GameObject.FindGameObjectWithTag("Boat").transform;
        if (_boat != null) { _hasBoat = true; }
    }
    private void FixedUpdate()
    {
        if (_hasBoat) 
        {
            transform.position = new Vector3(_boat.position.x,transform.position.y,_boat.position.z);
        }
    }
}
