using UnityEngine;
using UnityEngine.UI;

public class CreateTable : MonoBehaviour
{
    void Start()
    {
        // Create a World Space Canvas for UI elements
        GameObject canvasObject = new GameObject("Canvas");
        Canvas canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
        canvasScaler.dynamicPixelsPerUnit = 10;  // Increase the pixels per unit to make UI elements larger
        canvasObject.AddComponent<GraphicRaycaster>();

        // Set the canvas position in front of the camera
        // Considering the camera is at (0, 0, -10) looking towards the origin
        canvasObject.transform.position = new Vector3(0, 0, 0); // Positioned at the origin
        canvasObject.transform.rotation = Quaternion.identity;

        // Example data
        string[] columnNames = { "Name", "Age", "Score" };
        string[] rowData = { "John", "25", "80" };

        // Create the table header
        CreateRow(canvas.transform, new Vector3(0, 0.5f, 0), columnNames, true);  // Position slightly above the origin

        // Create the table rows
        CreateRow(canvas.transform, new Vector3(0, 0, 0), rowData);  // Position at the origin
    }


    void CreateRow(Transform parent, Vector3 position, string[] rowData, bool isHeader = false)
    {
        // Create a new row (horizontal layout group)
        GameObject rowObject = new GameObject("Row", typeof(RectTransform));
        rowObject.transform.SetParent(parent);

        RectTransform rectTransform = rowObject.GetComponent<RectTransform>();
        rectTransform.localPosition = position;

        HorizontalLayoutGroup layoutGroup = rowObject.AddComponent<HorizontalLayoutGroup>();
        layoutGroup.childForceExpandWidth = false;
        layoutGroup.childForceExpandHeight = false;

        // Create cells in the row
        foreach (var data in rowData)
        {
            CreateCell(rowObject.transform, data, isHeader);
        }
    }
    void CreateCell(Transform parent, string cellData, bool isHeader)
    {
        // Create a Text component for the cell
        GameObject cellObject = new GameObject("Cell", typeof(RectTransform));
        cellObject.transform.SetParent(parent);

        Text cellText = cellObject.AddComponent<Text>();
        cellText.text = cellData;
        cellText.alignment = TextAnchor.MiddleCenter;
        cellText.color = Color.black; // Set a color that stands out

        // Ensure a default font is set, Unity usually has a default Arial font
        cellText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");

        // Customize cell appearance based on whether it's a header
        if (isHeader)
        {
            cellText.fontStyle = FontStyle.Bold;
            cellText.fontSize = 14; // Example size
        }
        else
        {
            cellText.fontSize = 12; // Example size
        }

        // Set the size of the RectTransform
        RectTransform rect = cellText.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(100, 50); // Example width and height
    }

}
