using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserInfo
{
    public string MissionExhibitName;
    public bool IsMissionExhibitComplete;
    public string MissionExhibitInitTime;
    public string MissionExhibitEndTime;

    public void PrintAll()
    {
        string result = $"name = {MissionExhibitName}\ninitTime = {MissionExhibitInitTime}\nendTime = {MissionExhibitEndTime}";
        Debug.Log(result);
    }
}

public class Users
{
    public UserInfo[] themeModelDataItems;

    public static Users CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Users>(jsonString);
    }

    public void ReadJson()
    {
        string fileName = "110590015";
        string filePath = "users/" + fileName;

        TextAsset jsonFile = Resources.Load<TextAsset>(filePath);

        if (jsonFile != null)
        {
            string jsonText = jsonFile.text;
            Debug.Log(jsonText);

            Users userData = Users.CreateFromJSON(jsonText);

            Debug.Log(userData.themeModelDataItems.Length);
            for (int i = 0; i < userData.themeModelDataItems.Length; i++)
            {
                userData.themeModelDataItems[i].PrintAll();
            }
        }
        else
        {
            Debug.LogError("Failed to load JSON file: " + filePath);
        }
    }
}
