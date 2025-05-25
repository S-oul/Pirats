using UnityEngine;

public class GoToQueue : State
{
    PiratController _controller;

    private Transform goal;
    public override void StateInit(StateMachine sm)
    {
        base.StateInit(sm);
        _controller = GetComponent<PiratController>();

    }
    public override void StateEnter()
    {
        base.StateEnter();
        goal = GameManager.Instance.Line.GetNextLinePosition();
        _controller.PiratGhost.SetDestination(goal.position);
    }

    public override void StateUpdate()
    {
        //print(Vector3.Distance(_controller.PiratGhost.transform.position, goal.position));
        if (Vector3.Distance(_controller.PiratGhost.transform.position, goal.position) < .6f)
        {
            MyStateMachine.GoNextState();
            GameManager.Instance.Line._availablePirats.Add(_controller);
        }

    }
}
