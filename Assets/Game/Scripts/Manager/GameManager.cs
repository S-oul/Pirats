using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : Manager<GameManager>
{
    [SerializeField] private ShipStats _ship;
    [SerializeField] private WaitingLine _waitingLine;
    
    #region Accessors
    public ShipStats Ship
    {
        get => _ship;
        private set => _ship = value;
    }
    public WaitingLine Line
    {
        get => _waitingLine;
    }

    #endregion
    

    public override void Awake()
    {
        base.Awake();
        if(!Ship) Ship = GameObject.FindGameObjectWithTag("Boat").GetComponent<ShipStats>();

    }
}
