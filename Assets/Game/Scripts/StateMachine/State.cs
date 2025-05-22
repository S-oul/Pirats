using UnityEngine;

public abstract class State : MonoBehaviour
{
    bool _hasStarted = false;
    bool _isInit = false;

    StateMachine _stateMachine;

    [SerializeField] State _nextState;

    #region Accessors
    public bool HasStarted { get => _hasStarted; set => _hasStarted = value; }
    public bool IsInit { get => _isInit; set => _isInit = value; }
    public StateMachine MyStateMachine { get => _stateMachine; set => _stateMachine = value; }
    public State NextState { get => _nextState; set => _nextState = value; }
    #endregion

    public virtual void StateEnter()
    {
        //Debug.Log(this.GetType() + " Enter");
        _hasStarted = true;
        this.enabled = true;
    }

    public virtual void StateExit()
    {
        //Debug.Log(this.GetType() + " Exit");
        this.enabled = false;

    }

    public abstract void StateUpdate();

    public virtual void StateInit(StateMachine sm)
    {
        MyStateMachine = sm;
        _isInit = true;
    }

}
