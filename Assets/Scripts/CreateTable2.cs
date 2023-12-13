using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateTable2 : MonoBehaviour
{
    public int _teamMemberCount { get; set; }
    public int _timeInterval { get; set; }

    private void Start()
    {
        _teamMemberCount = GetJsonFilesCount();
        CreateQuadRow(_teamMemberCount, 0);
        CreateRow2(5, _teamMemberCount);
    }

    private int GetJsonFilesCount()
    {
        string folderPath = "Assets/json";
        int fileCount = Directory.GetFiles(folderPath, "*.json").Length;
        return fileCount;
    }

    private void CreateQuadRow(int numberOfQuads, float startingX)
    {
        GameObject rowObject = new GameObject("QuadRow");
        rowObject.transform.parent = transform;

        double space = 0.5;
        for (int i = 0; i < numberOfQuads; i++)
        {
            float xPosition = (float)(startingX + (i * (space)));
            Debug.Log(xPosition + " " + i + " " + (space));
            CreateQuad(xPosition, 0, 5, rowObject.transform);
        }

    }

    private void CreateRow2(int quantity, float startPosition)
    {
        GameObject rowObject = new GameObject("QuadRow");
        rowObject.transform.parent = transform;

        // rowObject.transform.rotation = Quaternion.Euler(90f, 0f, -90f);
        double space = 0.5;
        // rowObject.transform.position = new Vector3(0, 30, -30);

        rowObject.transform.position = new Vector3(0, 0, 0);

        for (int i = 0; i < quantity; i++)
        {
            float xPosition = (float)(startPosition + (i * (space)));
            CreateQuadY(xPosition, 0, 0, rowObject.transform);
        }
    }

    private void CreateQuad(float xPosition, float yPosition, float zPosition, Transform parentTransform)
    {
        GameObject quadObject = new GameObject("Quad");
        quadObject.transform.parent = parentTransform;

        quadObject.transform.localPosition = new Vector3(0, 0, 0);
        quadObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

        float width = 0.1f;
        float height = 5f;

        MeshRenderer meshRenderer = quadObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = quadObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(xPosition, yPosition, zPosition),
            new Vector3(xPosition + width, yPosition, zPosition),
            new Vector3(xPosition, height, zPosition),
            new Vector3(xPosition + width, height, zPosition)
        };
        mesh.vertices = vertices;

        int[] tris = new int[6]
        {
            0, 2, 1,
            2, 3, 1
        };
        mesh.triangles = tris;

        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        mesh.normals = normals;

        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        mesh.uv = uv;

        meshFilter.mesh = mesh;
    }

    private void CreateQuadY(float xPosition, float yPosition, float zPosition, Transform parentTransform)
    {
        // Create a new GameObject for each quad
        GameObject quadObject = new GameObject("Quad");
        quadObject.transform.parent = parentTransform;


        quadObject.transform.localPosition = new Vector3(0, 0, 10);
        quadObject.transform.localRotation = Quaternion.Euler(90f, 0f, -90f);

        float width = 0.1f;
        float height = 5f;

        MeshRenderer meshRenderer = quadObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = quadObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(xPosition, yPosition, zPosition),
            new Vector3(xPosition + width, yPosition, zPosition),
            new Vector3(xPosition, height, zPosition),
            new Vector3(xPosition + width, height, zPosition)
        };
        mesh.vertices = vertices;

        int[] tris = new int[6]
        {
            0, 2, 1,
            2, 3, 1
        };
        mesh.triangles = tris;

        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        mesh.normals = normals;

        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        mesh.uv = uv;

        meshFilter.mesh = mesh;
    }
}
