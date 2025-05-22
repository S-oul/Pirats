using UnityEngine;
using UnityEngine.AI;

public class GotTo : State
{
    NavMeshAgent _agent;

    public override void StateInit(StateMachine sm)
    {
        base.StateInit(sm);
        _agent = GetComponent<NavMeshAgent>();

    }
    public override void StateEnter()
    {
        base.StateEnter();
        _agent.SetDestination(GameManager.Instance.QueuePos[0].position);
    }

    public override void StateUpdate()
    {
        
    }
}
