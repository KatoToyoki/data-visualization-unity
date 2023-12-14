using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Users
{
    public string FOLDER_PATH = "Assets/Resources/users";
    public List<string> _names { get; set; }
    public List<string> _time { get; set; } = new List<string>();
    public List<string> _tasks { get; set; } = new List<string>();
    public List<User> _users { get; set; } = new List<User>();

    /// <summary>
    /// get files name from directory then read the json for each file
    /// </summary>
    public Users()
    {
        GetFilesName();
        GetUsersData();
        SetTasks();
        SetTime();
        GetAllMaxTask();
        GetUserSphere();
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

        _names = Directory.GetFiles(FOLDER_PATH)
            .Where(file => !file.EndsWith(".meta"))
            .Select(file => Path.GetFileNameWithoutExtension(file))
            .ToList();

        _names.Insert(0, "");
        _names.Add("");
    }

    /// <summary>
    /// when we have all files' name, we can read each one
    /// </summary>
    public void GetUsersData()
    {
        foreach (string user in _names)
        {
            ReadJson(user);
        }
    }

    /// <summary>
    /// to put distinct task inside container
    /// </summary>
    public void SetTasks()
    {
        foreach (User user in _users)
        {
            foreach (TaskInfo info in user.themeModelDataItems)
            {
                if (!_tasks.Contains(info.MissionExhibitName))
                {
                    _tasks.Add(info.MissionExhibitName);
                }
            }
        }

        _tasks.Insert(0, "");
    }

    /// <summary>
    /// to put time inside container
    /// </summary>
    public void SetTime()
    {
        _time.Add("");
        for (int i = 1; i < 10; i++)
        {
            _time.Add(i.ToString());
        }
    }

    /// <summary>
    /// return a empty List
    /// </summary>
    /// <returns></returns>
    public List<string> CreateEmptyList()
    {
        return new List<string>();
    }

    /// <summary>
    /// set all max tasks instances with all users
    /// </summary>
    public void GetAllMaxTask()
    {
        foreach (User user in _users)
        {
            user.GetMaxTask();
        }
    }

    /// <summary>
    /// set all sphere with all users
    /// </summary>
    public void GetUserSphere()
    {
        foreach (User user in _users)
        {
            Vector3 position = new Vector3(0f, 0f, 0f);
            position.x = _names.IndexOf(user._name) * 0.5f;
            position.y = _tasks.IndexOf(user._maxTaskName) * 0.5f;
            position.z = _time.IndexOf(((int)(user._maxTaskTime.TotalMinutes)).ToString()) * 0.5f;

            user.CreateSphere(position, user._name);
        }
    }
}
