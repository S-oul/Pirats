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

    private StateMachine _piratOnTaskSM;

    private void Awake()
    {
        if (!_uiTask) Debug.LogError($"{name} has not been assigned to UI task");
        else
        {
            _uiTask.Title = taskName;
            _uiTask.TimeTaskTakes = " Time : " + timeToFinishTask;
            _uiTask.MyTask = this;
        }
    }

    public virtual void BeginTask(StateMachine pirat)
    {
        taskNeedsToBeDone = false;
        _piratOnTaskSM = pirat;
        
        print($"{name} has Started");


        StartCoroutine(TaskTime());
    }
    public virtual void onEndTask()
    {
        print($"{name} has finished");
        _piratOnTaskSM.GoNextState();
        _piratOnTaskSM = null;
    }

    IEnumerator TaskTime()
    {
        yield return new WaitForSeconds(timeToFinishTask);
        onEndTask();
    }
}
