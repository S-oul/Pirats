using System;
using UnityEngine;

public class PiratController : MonoBehaviour
{
    [SerializeField] PiratGhostController _piratGhost;
    [SerializeField] StateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = GetComponent<StateMachine>();
    }

    public PiratGhostController PiratGhost
    {
        get => _piratGhost;
    }

    public StateMachine MyStateMachine
    {
        get => _stateMachine;
    }
}
