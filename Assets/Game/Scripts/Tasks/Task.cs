using System;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Task : MonoBehaviour
{
    [SerializeField] UITask _uiTask;
    [SerializeField] string taskName;
    
    [SerializeField] float timeToFinishTask = 10f;


    bool taskNeedsToBeDone = false;
    
    private PiratBehaviour _piratOnTask;

    private void Awake()
    {
        if(!_uiTask) Debug.LogError($"{name} has not been assigned to UI task");
        else
        {
            _uiTask.Title = taskName;
            _uiTask.TimeTaskTakes = " Time : " + timeToFinishTask;
            _uiTask.MyTask = this;
        }
    }

    public virtual void BeginTask(PiratBehaviour pirate)
    {
        taskNeedsToBeDone = false;
        _piratOnTask = pirate;

        print($"{name} has Started");

        StartCoroutine(TaskTime());
    }
    public virtual void onEndTask()
    {
        print($"{name} has finished");
        _piratOnTask.NextTaskToDo = null;
        _piratOnTask = null;
    }

    IEnumerator TaskTime()
    {
        yield return new WaitForSeconds(timeToFinishTask);
        onEndTask();
    }
    }
