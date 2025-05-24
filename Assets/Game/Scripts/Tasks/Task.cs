using System;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Task : MonoBehaviour
{
    [Header("NavMesh")] 
    [SerializeField] private Transform _ghostPosition;

    [Header("UI")]
    [SerializeField] UITask _uiTask;
    [SerializeField] string taskName;

    [Header("Others")]
    [SerializeField] float timeToFinishTask = 10f;

    public Action onEndTask;

    bool taskNeedsToBeDone = false;

    private StateMachine _piratOnTaskSM;
    [SerializeField] bool _hasStarted = false;

    #region Accessors
    public bool HasStarted { get => _hasStarted; set => _hasStarted = value; }

    public Transform GhostPosition
    {
        get => _ghostPosition;
    }
    #endregion
    public virtual void Awake()
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
    public virtual void EndTask()
    {
        print($"{name} has finished");
        _hasStarted = false;
        _piratOnTaskSM.GoNextState();
        _piratOnTaskSM = null;
        _uiTask.Animator.SetTrigger("Remove");
        onEndTask?.Invoke();
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
        EndTask();
    }
}
