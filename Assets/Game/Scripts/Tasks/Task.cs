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
    [SerializeField] bool _hasStarted = false;

    public bool HasStarted { get => _hasStarted; set => _hasStarted = value; }

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
        _hasStarted = true;

        StartCoroutine(TaskTime());

        _uiTask.Animator.SetTrigger(0);
    }
    public virtual void onEndTask()
    {
        print($"{name} has finished");
        _hasStarted = false;
        _piratOnTaskSM.GoNextState();
        _piratOnTaskSM = null;
        _uiTask.Animator.SetTrigger("Remove");

    }

    IEnumerator TaskTime()
    {
        float time = 0f;
        while(time < timeToFinishTask)
        {
            time += Time.deltaTime;
            _uiTask.Slider.value = time / timeToFinishTask;
            yield return null;

        }
        onEndTask();
    }
}
