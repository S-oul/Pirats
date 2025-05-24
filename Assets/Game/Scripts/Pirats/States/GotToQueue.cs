using UnityEngine;
using UnityEngine.AI;

public class GotTo : State
{
    PiratController _controller;

    public override void StateInit(StateMachine sm)
    {
        base.StateInit(sm);
        _controller = GetComponent<PiratController>();

    }
    public override void StateEnter()
    {
        base.StateEnter();
        _controller.PiratGhost.SetDestination(GameManager.Instance.QueuePos[0].position);
    }

    public override void StateUpdate()
    {
        if (Vector3.Distance(_controller.PiratGhost.GetOnShipDestination(), transform.position) < .4f)
        {
            MyStateMachine.GoNextState();
        }

    }
}
