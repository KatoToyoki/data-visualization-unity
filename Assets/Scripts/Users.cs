using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Users
{
    public string FOLDER_PATH = "Assets/Resources/users";
    public string[] _fileNames { get; set; }
    public List<User> _users { get; set; } = new List<User>();

    /// <summary>
    /// get files name from directory then read the json for each file
    /// </summary>
    public Users()
    {
        GetFilesName();
        GetUsersData();
    }

    /// <summary>
    /// get the json text then create a instance depends on each one
    /// </summary>
    /// <param name="jsonString"></param>
    /// <returns></returns>
    public User CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<User>(jsonString);
    }

    /// <summary>
    /// depends on each file, read the json, create instance and add in container
    /// </summary>
    /// <param name="name"></param>
    public void ReadJson(string name)
    {
        string filePath = "users/" + name;
        TextAsset jsonFile = Resources.Load<TextAsset>(filePath);

        if (jsonFile == null)
        {
            return;
        }

        string jsonText = jsonFile.text;

        User user = CreateFromJSON(jsonText);
        user._name = name;
        _users.Add(user);
    }

    /// <summary>
    /// to get all files' name, store in the container
    /// </summary>
    public void GetFilesName()
    {
        if (!Directory.Exists(FOLDER_PATH))
        {
            return;
        }

        _fileNames = Directory.GetFiles(FOLDER_PATH)
            .Where(file => !file.EndsWith(".meta"))
            .Select(file => Path.GetFileNameWithoutExtension(file))
            .ToArray();
    }

    /// <summary>
    /// when we have all files' name, we can read each one
    /// </summary>
    public void GetUsersData()
    {
        foreach (string user in _fileNames)
        {
            ReadJson(user);
        }
    }
}
