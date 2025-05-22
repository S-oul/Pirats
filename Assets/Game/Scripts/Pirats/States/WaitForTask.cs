using UnityEngine;

public class WaitForTask : State
{
    public override void StateEnter()
    {
        base.StateEnter();
        GameManager.Instance.Pirats.Add(MyStateMachine);
    }
    public override void StateUpdate()
    {
        return;
    }

    public override void StateExit()
    {
        base.StateExit();
        GameManager.Instance.Pirats.Remove(MyStateMachine);

    }
}
