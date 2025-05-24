using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : Manager<GameManager>
{
    [SerializeField] private ShipStats _ship;
    
    [SerializeField] private List<StateMachine> _pirats = new List<StateMachine>();
    [SerializeField] private List<Transform> _queuePos = new List<Transform>();
    
    #region Accessors
    public ShipStats Ship
    {
        get => _ship;
        private set => _ship = value;
    }

    public List<Transform> QueuePos
    {
        get => _queuePos;
        set => _queuePos = value;
    }
    public List<StateMachine> Pirats { get => _pirats; set => _pirats = value; }

    #endregion

    public override void Awake()
    {
        base.Awake();
        if(!Ship) Ship = GameObject.FindGameObjectWithTag("Boat").GetComponent<ShipStats>();

    }
    public void AssignTask(Task task)
    {
        _pirats[0].GetComponent<GotToTask>().Task = task;
        _pirats[0].GoNextState();
        // _pirats.RemoveAt(0);
        
    }
}
