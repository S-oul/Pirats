using UnityEngine;
using UnityEngine.AI;

public class GotToTask : State
{
    NavMeshAgent _agent;

    Task _task;

    public Task Task { get => _task; set => _task = value; }

    public override void StateInit(StateMachine sm)
    {
        base.StateInit(sm);
        _agent = GetComponent<NavMeshAgent>();
    }
    public override void StateEnter()
    {
        base.StateEnter();
        _agent.SetDestination(_task.transform.position);
    }

    public override void StateUpdate()
    {
        if(_task && !_task.HasStarted && Vector3.Distance(_agent.destination,transform.position) < .4f)
        {
            _task.BeginTask(MyStateMachine);
            //MyStateMachine.ChangeState(NextState);
        }
    }
}
