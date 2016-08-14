﻿using UnityEngine;
using ProjectUtility;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(Noise))]
[ExecuteInEditMode]
public class CustomTerrain : MonoBehaviour
{
    public int gridSize = 4;
    public float cellSize = 1.0f;

    MeshRenderer meshRenderer;
    MeshFilter meshFilter;

    Noise noise;

    // Use this for initialization

    void Start()
    {
        noise = GetComponent<Noise>();
        Regenerate();
    }

    public void Regenerate()
    {
        noise.Init();
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.vertices = GenVertices();
        mesh.triangles = GenTriangles();
        mesh.uv = GenUVs();
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector2[] GenUVs()
    {
        int w = gridSize + 1;
        int l = gridSize + 1;
        Vector2[] uvs = new Vector2[w * l];

        for (int ux = 0; ux < w; ux++)
        {
            for (int uz = 0; uz < l; uz++)
            {
                uvs[ux * l + uz] = new Vector2((float)ux / gridSize, (float)uz / gridSize);
            }
        }

        return uvs;
    }

    int[] GenTriangles()
    {
        int verticesPerTriangles = 3;
        int trianglesPerCell = 2;
        int numberCells = gridSize * gridSize;

        int[] triangles = new int[numberCells * trianglesPerCell * verticesPerTriangles];

        int tindex = 0;
        for (int cx = 0; cx < gridSize; cx++)
        {
            for (int cz = 0; cz < gridSize; cz++)
            {
                int n = cx * (gridSize + 1) + cz;
                // first triangle of every cells
                triangles[tindex] = n;
                triangles[tindex + 1] = n + 1;
                triangles[tindex + 2] = n + gridSize + 2;
                tindex += 3;

                // second triangle of every cells
                triangles[tindex] = n;
                triangles[tindex + 1] = n + gridSize + 2;
                triangles[tindex + 2] = n + gridSize + 1;
                tindex += 3;
            }
        }

        return triangles;
    }

    Vector3[] GenVertices()
    {
        int w = gridSize + 1;
        int l = gridSize + 1;
        Vector3[] vertices = new Vector3[w * l];
        for (var gx = 0; gx < w; gx++)
        {
            for (var gz = 0; gz < l; gz++)
            {
                float x = gx * cellSize;
                float z = gz * cellSize;
                float height = 3.0f * noise.Get(x,z);
                vertices[gx * l + gz] = new Vector3(x, height, z);
            }
        }
        return vertices;
    }
}