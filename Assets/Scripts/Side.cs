using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Side
{
    private const double INTERVAL = 0.5;
    private const float WIDTH = 0.1f;
    private const float HEIGHT = 5f;

    public string _name { get; set; }
    public Quaternion _sideRotation { get; set; }
    public Vector3 _lineStartPosition { get; set; }
    public Vector3 _lineLocalPosition { get; set; }
    public Vector3? _textStartPosition { get; set; }
    public Quaternion? _textRotation { get; set; }
    public char _textDirection { get; set; }

    /// <summary>
    /// for debuging, we can check the variable inside
    /// </summary>
    public void PrintAll()
    {
        string result = $"name = {_name}\ntextDirection = {_textDirection}";
        Debug.Log(result);
    }

    public void SetSideProperty(string name, Quaternion rotation)
    {
        _name = name;
        _sideRotation = rotation;
    }

    public void SetLineProperty(Vector3 lineStartPosition, Vector3 lineLocalPosition)
    {
        _lineStartPosition = lineStartPosition;
        _lineLocalPosition = lineLocalPosition;
    }

    public void SetTextProperty(Vector3? textStartPosition, Quaternion? textRotation, char textDirection)
    {
        _textStartPosition = textStartPosition;
        _textRotation = textRotation;
        _textDirection = textDirection;
    }

    public void CreateSide(int quantity, Transform parentTransform, List<string> texts)
    {
        GameObject rowObject = new GameObject(_name);
        rowObject.transform.parent = parentTransform;

        Vector3 lineTemp = _lineStartPosition;


        for (int i = 0; i < quantity; i++)
        {
            lineTemp.x = (float)(i * (INTERVAL));
            CreateQuad(lineTemp, _lineLocalPosition, _sideRotation, rowObject.transform);
            if (_textDirection == '\0')
            {
                continue;
            }

            Vector3 textTemp = (Vector3)_textStartPosition;

            switch (_textDirection)
            {
                case ('x'):
                    textTemp.x += (float)(i * (INTERVAL));
                    break;
                case ('y'):
                    textTemp.y -= (float)(i * (INTERVAL));
                    break;
                case ('z'):
                    textTemp.z += (float)(i * (INTERVAL));
                    break;
            }

            CreateTextMeshProObject(texts[i], textTemp, (Quaternion)_textRotation, rowObject.transform);
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