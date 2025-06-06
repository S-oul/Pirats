using System;
using System.Collections.Generic;
using UnityEngine;

public class RiseAnchor : Task
{
    public override void Awake()
    {
        base.Awake();
        onEndTask += GameManager.Instance.Ship.ShipStateMachine.GoNextState;
        onEndTask += GameManager.Instance.onGameStart.Invoke;
    }

    private void OnDisable()
    {
        onEndTask -= GameManager.Instance.Ship.ShipStateMachine.GoNextState;

    }
}
