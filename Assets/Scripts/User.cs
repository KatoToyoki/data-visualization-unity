using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Globalization;

[Serializable]
public class TaskInfo
{
    public string MissionExhibitName;
    public bool IsMissionExhibitComplete;
    public string MissionExhibitInitTime;
    public string MissionExhibitEndTime;

    public DateTimeOffset _startTime { get; set; }
    public DateTimeOffset _endTime { get; set; }
    public TimeSpan _timeDifference { get; set; }

    /// <summary>
    /// for debuging, we can check the variable inside
    /// </summary>
    public void PrintAll()
    {
        string result = $"name = {MissionExhibitName}\nisComplete = {IsMissionExhibitComplete}\ninitTime = {MissionExhibitInitTime}\nendTime = {MissionExhibitEndTime}";
        Debug.Log(result);
    }

    /// <summary>
    /// set time, time span based on json string
    /// </summary>
    public void SetTime()
    {
        try
        {
            _startTime = DateTimeOffset.Parse(MissionExhibitInitTime);
            _endTime = DateTimeOffset.Parse(MissionExhibitEndTime);
            _timeDifference = _endTime - _startTime;
        }
        catch (FormatException ex)
        {
            _timeDifference = new TimeSpan(0, 0, 0);
        }
    }
}

public class User
{
    public string _name { get; set; }
    public TaskInfo[] themeModelDataItems;
    public TimeSpan _maxTaskTime { get; set; } = new TimeSpan(0, 0, 0);
    public string _maxTaskName { get; set; }

    /// <summary>
    /// to get the name and time of the task that cause a user the most time
    /// </summary>
    public void GetMaxTask()
    {
        foreach (TaskInfo info in themeModelDataItems)
        {
            info.SetTime();
            if (info._timeDifference > _maxTaskTime)
            {
                _maxTaskTime = info._timeDifference;
                _maxTaskName = info.MissionExhibitName;
            }
        }
    }

    /// <summary>
    /// create a sphere depends on position
    /// </summary>
    /// <param name="position"></param>
    /// <param name="name"></param>
    public void CreateSphere(Vector3 position, string name)
    {
        GameObject userSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        userSphere.name = name;

        Transform sphereTransform = userSphere.transform;

        sphereTransform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        sphereTransform.position = position;

        MeshRenderer renderer = userSphere.GetComponent<MeshRenderer>();
        renderer.material = new Material(Shader.Find("Standard"));
    }
}
