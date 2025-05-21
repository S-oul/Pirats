using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class PiratBehaviour : MonoBehaviour
{
    NavMeshAgent _agent;

    [SerializeField] float _speed = 4f;
    
    Task _nextTaskToDo = null;
    bool _isWorkingOnTask = false;

    bool _isGoingToQueue;

    #region Accessors
    public bool IsWorkingOnTask
    {
        get => _isWorkingOnTask;
        set => _isWorkingOnTask = value;
    }

    public Task NextTaskToDo
    {
        get => _nextTaskToDo;
        set => _nextTaskToDo = value;
    }

    #endregion
    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _speed;
    }

    public void GoToTarget(Task task)
    {
        NextTaskToDo = task;
        _agent.destination = task.transform.localPosition;
    }

    //A State Machine would Be better ehre
    void Update()
    {
        //Pirat got a task
        if (NextTaskToDo && !IsWorkingOnTask)
        {
            //print(Vector3.Distance(NextTaskToDo.transform.localPosition, transform.localPosition)); //result here is .4f
            if (Vector3.Distance(NextTaskToDo.transform.localPosition, transform.localPosition) < .4f)
            {
                NextTaskToDo.BeginTask(this);
                IsWorkingOnTask = true;
            } 
        }
        else if (!_isGoingToQueue)// go Home
        {
            _isGoingToQueue = true;
            _agent.destination = GameManager.Instance.QueuePos[0].position;
        }
    }

    // private void OnDrawGizmos()
    // {
    //     if (_nextTaskToDo)
    //     {
    //         Gizmos.color = Color.red;
    //         Gizmos.DrawSphere(_nextTaskToDo.transform.position,.3f);
    //     }
    // }
}
