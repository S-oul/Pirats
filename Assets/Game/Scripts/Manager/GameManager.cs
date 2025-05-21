using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : Manager<GameManager>
{
    [SerializeField] private GameObject _ship;
    
    [SerializeField] private List<PiratBehaviour> _pirats = new List<PiratBehaviour>();
    [SerializeField] private List<Transform> _queuePos = new List<Transform>();
    
    #region Accessors
    public GameObject Ship
    {
        get => _ship;
        private set => _ship = value;
    }

    public List<Transform> QueuePos
    {
        get => _queuePos;
        set => _queuePos = value;
    }

    #endregion
    public override void Awake()
    {
        base.Awake();
        
        Ship = GameObject.FindGameObjectWithTag("Boat");

    }
    public void AssignTask(Task task)
    {
        _pirats[0].GoToTarget(task);
        _pirats.RemoveAt(0);
    }
}
