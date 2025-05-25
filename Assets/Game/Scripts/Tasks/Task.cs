using System;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Task : MonoBehaviour
{
    [FormerlySerializedAs("_ghostPosition")]
    [Header("NavMesh")] 
    [SerializeField] private Transform ghostTransform;

    [Header("UI")]
    [SerializeField] UITask _uiTask;
    [SerializeField] string taskName;

    [Header("Others")]
    [SerializeField] float timeToFinishTask = 10f;

    public Action onEndTask;
    
    private StateMachine _piratOnTaskSM;
    [SerializeField] bool _hasStarted = false;

    #region Accessors
    public bool HasStarted { get => _hasStarted; set => _hasStarted = value; }

    public Transform GhostTransform
    {
        get => ghostTransform;
    }
    #endregion
    public virtual void Awake()
    {
        if (!_uiTask)
        {
            _uiTask = Instantiate(Resources.Load<GameObject>("UITask")).GetComponent<UITask>();
            _uiTask.name = this.name + "UITask";
            
            _uiTask.transform.parent = FindAnyObjectByType<Canvas>().transform.GetChild(0);
            //_uiTask.gameObject.SetActive(false);
        }
        
        _uiTask.Title = taskName;
        _uiTask.TimeTaskTakes = " Time : " + timeToFinishTask;
        _uiTask.MyTask = this;
        
    }

    public void EnableTask()
    {
        _uiTask.gameObject.SetActive(true);
        _uiTask.Slider.value = 0;
        _uiTask.Animator.SetTrigger("NewTask");
    }
    public virtual void BeginTask(StateMachine pirat)
    {
        _piratOnTaskSM = pirat;
        
        print($"{name} has Started");
        _hasStarted = true;

        StartCoroutine(TaskTime());

        //_uiTask.Animator.SetTrigger(0);
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
