using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class CreateTable : MonoBehaviour
{
    public Users _users { get; set; }

    public Side _student_task { get; set; } = new Side();
    public Side _student_time { get; set; } = new Side();
    public Side _time_task { get; set; } = new Side();
    public Side _time_student { get; set; } = new Side();
    public Side _task_student { get; set; } = new Side();
    public Side _task_time { get; set; } = new Side();

    private void Start()
    {
        _users = new Users();

        SetUpSixSizes();
        GameObject container = new GameObject("Container");
        container.transform.parent = transform;

        _student_task.CreateSide(_users._names.Count, container.transform, _users.CreateEmptyList());
        _student_time.CreateSide(_users._names.Count, container.transform, _users._names);
        _time_task.CreateSide(_users._time.Count, container.transform, _users._time);
        _time_student.CreateSide(_users._time.Count, container.transform, _users.CreateEmptyList());
        _task_student.CreateSide(_users._tasks.Count, container.transform, _users.CreateEmptyList());
        _task_time.CreateSide(_users._tasks.Count, container.transform, _users._tasks);
    }

    /// <summary>
    /// initialize 6 sides
    /// </summary>
    public void SetUpSixSizes()
    {
        // [student] - task
        _student_task.SetSideProperty("[student] - task", Quaternion.Euler(0f, 0f, -90f));
        _student_task.SetLineProperty(new Vector3(5, 0, 0), new Vector3(0, 5, 5));
        _student_task.SetTextProperty(null, null, '\0');

        // [student] - time
        _student_time.SetSideProperty("[student] - time", Quaternion.Euler(90f, -90f, -90f));
        _student_time.SetLineProperty(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        _student_time.SetTextProperty(new Vector3(0.05f, 0, -1.87f), Quaternion.Euler(90f, 0f, 90f), 'x');

        // [time] - task
        _time_task.SetSideProperty("[time] - task", Quaternion.Euler(0f, -90f, 0f));
        _time_task.SetLineProperty(new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        _time_task.SetTextProperty(new Vector3(-0.03f, 5.44f, -1.36f), Quaternion.Euler(0f, -90f, 0f), 'z');

        // [time] - student
        _time_student.SetSideProperty("[time] - student", Quaternion.Euler(90f, -90f, 0f));
        _time_student.SetLineProperty(new Vector3(0, 0, 0), new Vector3(5, 0, 0));
        _time_student.SetTextProperty(null, null, '\0');

        // [task]- student
        _task_student.SetSideProperty("[task]- student", Quaternion.Euler(0f, 0f, 0f));
        _task_student.SetLineProperty(new Vector3(5, 0, 5), new Vector3(0, 0, 0));
        _task_student.SetTextProperty(null, null, '\0');

        // [task] - time
        _task_time.SetSideProperty("[task] - time", Quaternion.Euler(0f, -90f, -90f));
        _task_time.SetLineProperty(new Vector3(0, 0, 0), new Vector3(0, 5, 0));
        _task_time.SetTextProperty(new Vector3(0.08f, 4.95f, -1.97f), Quaternion.Euler(0f, -90f, 0f), 'y');
    }
}
