using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State _currentState;

    List<State> _allStates = new();

    public State CurrentState { get => _currentState; private set => _currentState = value; }

    private void Awake()
    {
        _allStates = GetComponents<State>().ToList();
        foreach (var state in _allStates)
        {
            state.StateInit(this);
            state.enabled = false;
        }
        if (_currentState is null) _currentState = _allStates[0];

        _currentState.StateEnter();
    }
    void Update()
    {
        if (_currentState is not null && _currentState.HasStarted && _currentState.IsInit) _currentState.StateUpdate();
    }

    public void ChangeState(State newState = null)
    {
        if (newState is null) { newState = _allStates[0]; } // If null qo to default
        _currentState.StateExit();
        _currentState = newState;
        _currentState.StateEnter();
    }

    [Button]
    public void GoNextState()
    {
        ChangeState(CurrentState.NextState);
    }
}
