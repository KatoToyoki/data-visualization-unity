using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class CreateTable : MonoBehaviour
{
    private const double INTERVAL = 0.5;
    private const float WIDTH = 0.1f;
    private const float HEIGHT = 5f;
    public int _teamMemberCount { get; set; }
    public int _timeInterval { get; set; }

    private void Start()
    {
        _teamMemberCount = GetJsonFilesCount();
        CreateQuadRow(5);
        CreateRow2(5);
        CreateRow3(5);
        CreateRow4(5);
        CreateRow5(5);
        CreateRow6(5);

        // ReadJson();
        Users _users = new Users();
        _users.ReadJson();
    }



    private int GetJsonFilesCount()
    {
        string folderPath = "Assets/Resources/users";
        int fileCount = Directory.GetFiles(folderPath, "*.json").Length;
        return fileCount;
    }

    // [student] - task
    private void CreateQuadRow(int numberOfQuads)
    {
        Vector3 position = new Vector3(5, 0, 5);
        Vector3 localPosition = new Vector3(0, 0, 0);
        Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);

        GameObject rowObject = new GameObject("QuadRow");
        rowObject.transform.parent = transform;

        for (int i = 0; i < numberOfQuads; i++)
        {
            position.x = (float)((i * (INTERVAL)));
            CreateQuad(position, localPosition, rotation, rowObject.transform);
        }
    }

    // [time] - student
    private void CreateRow2(int numberOfQuads)
    {
        Vector3 position = new Vector3(0, 0, 0);
        Vector3 localPosition = new Vector3(5, 0, 0);
        Quaternion rotation = Quaternion.Euler(90f, -90f, 0f);

        GameObject rowObject = new GameObject("QuadRow");
        rowObject.transform.parent = transform;

        for (int i = 0; i < numberOfQuads; i++)
        {
            position.x = (float)((i * (INTERVAL)));
            CreateQuad(position, localPosition, rotation, rowObject.transform);
        }
    }

    // student - [task] 
    private void CreateRow3(int numberOfQuads)
    {
        Vector3 position = new Vector3(5, 0, 0);
        Vector3 localPosition = new Vector3(0, 5, 5);
        Quaternion rotation = Quaternion.Euler(0f, 0f, -90f);

        GameObject rowObject = new GameObject("QuadRow");
        rowObject.transform.parent = transform;

        for (int i = 0; i < numberOfQuads; i++)
        {
            position.x = (float)((i * (INTERVAL)));
            CreateQuad(position, localPosition, rotation, rowObject.transform);
        }
    }

    // [task] - time
    private void CreateRow4(int numberOfQuads)
    {
        Vector3 position = new Vector3(0, 0, 0);
        Vector3 localPosition = new Vector3(0, 5, 0);
        Quaternion rotation = Quaternion.Euler(0f, -90f, -90f);

        GameObject rowObject = new GameObject("QuadRow");
        rowObject.transform.parent = transform;

        for (int i = 0; i < numberOfQuads; i++)
        {
            position.x = (float)((i * (INTERVAL)));
            CreateQuad(position, localPosition, rotation, rowObject.transform);
            CreateTextMeshProObject("task47", new Vector3(0.08f, (float)(4.95f - (i * (INTERVAL))), -1.97f), Quaternion.Euler(0f, -90f, 0f), rowObject.transform);
        }
    }

    // [student] - time
    private void CreateRow5(int numberOfQuads)
    {
        Vector3 position = new Vector3(0, 0, 0);
        Vector3 localPosition = new Vector3(0, 0, 0);
        Quaternion rotation = Quaternion.Euler(90f, -90f, -90f);

        GameObject rowObject = new GameObject("QuadRow");
        rowObject.transform.parent = transform;

        for (int i = 0; i < numberOfQuads; i++)
        {
            position.x = (float)((i * (INTERVAL)));
            CreateQuad(position, localPosition, rotation, rowObject.transform);
            CreateTextMeshProObject("110590015", new Vector3((float)(0.05 + (i * (INTERVAL))), 0, -1.87f), Quaternion.Euler(90f, 0f, 90f), rowObject.transform);
        }
    }

    // [time] - task
    private void CreateRow6(int numberOfQuads)
    {
        Vector3 position = new Vector3(0, 0, 0);
        Vector3 localPosition = new Vector3(0, 0, 0);
        Quaternion rotation = Quaternion.Euler(0f, -90f, 0f);

        GameObject rowObject = new GameObject("QuadRow");
        rowObject.transform.parent = transform;

        for (int i = 0; i < numberOfQuads; i++)
        {
            position.x = (float)((i * (INTERVAL)));
            CreateQuad(position, localPosition, rotation, rowObject.transform);
            CreateTextMeshProObject("1", new Vector3(-0.03f, 5.44f, (float)(-1.36f + (i * (INTERVAL)))), Quaternion.Euler(0f, -90f, 0f), rowObject.transform);
        }
    }
    private void CreateQuad(Vector3 position, Vector3 localPosition, Quaternion rotation, Transform parentTransform)
    {
        GameObject quadObject = new GameObject("Quad");
        quadObject.transform.parent = parentTransform;

        quadObject.transform.localPosition = localPosition;
        quadObject.transform.localRotation = rotation;

        MeshRenderer meshRenderer = quadObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = quadObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(position.x, position.y, position.z),
            new Vector3(position.x + WIDTH, position.y, position.z),
            new Vector3(position.x, HEIGHT, position.z),
            new Vector3(position.x + WIDTH, HEIGHT, position.z)
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

    void CreateTextMeshProObject(string text, Vector3 position, Quaternion rotation, Transform parentTransform)
    {
        if (text == null)
        {
            return;
        }

        GameObject textMeshProObject = new GameObject("TextMeshProObject");
        textMeshProObject.transform.parent = parentTransform;
        textMeshProObject.transform.position = position;
        Color color = Color.white;
        float fontSize = 3f;

        TextMeshPro textMeshProComponent = textMeshProObject.AddComponent<TextMeshPro>();

        textMeshProComponent.text = text;
        textMeshProComponent.fontSize = fontSize;
        textMeshProComponent.color = color;

        textMeshProComponent.alignment = TextAlignmentOptions.Right;

        textMeshProObject.transform.rotation = rotation;

        textMeshProComponent.rectTransform.sizeDelta = new Vector2(3f, 1f);

        textMeshProObject.AddComponent<GraphicRaycaster>();
    }

}
