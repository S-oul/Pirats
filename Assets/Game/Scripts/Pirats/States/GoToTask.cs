using UnityEngine;

public class GoToTask : State
{
    PiratController _controller;

    [SerializeField] Task _task;

    public Task Task { get => _task; set => _task = value; }

    public override void StateInit(StateMachine sm)
    {
        base.StateInit(sm);
        _controller = GetComponent<PiratController>();
    }
    public override void StateEnter()
    {
        base.StateEnter();
        _controller.PiratGhost.SetDestination(_task.GhostTransform.position);
    }

    public override void StateUpdate()
    {
        //print(Vector3.Distance(_task.transform.position,transform.position));
        if(_task && !_task.HasStarted && Vector3.Distance(_task.transform.position,transform.position) < .4f)
        {
            _task.BeginTask(MyStateMachine);
            //MyStateMachine.ChangeState(NextState);
        }
    }
}
