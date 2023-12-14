using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
public class TaskInfo
{
    public string MissionExhibitName;
    public bool IsMissionExhibitComplete;
    public string MissionExhibitInitTime;
    public string MissionExhibitEndTime;

    /// <summary>
    /// for debuging, we can check the variable inside
    /// </summary>
    public void PrintAll()
    {
        string result = $"name = {MissionExhibitName}\nisComplete = {IsMissionExhibitComplete}\ninitTime = {MissionExhibitInitTime}\nendTime = {MissionExhibitEndTime}";
        Debug.Log(result);
    }
}

public class User
{
    public string _name { get; set; }
    public TaskInfo[] themeModelDataItems;
    public double _maxTaskTime { get; set; }
    public string _maxTaskName { get; set; }

}
