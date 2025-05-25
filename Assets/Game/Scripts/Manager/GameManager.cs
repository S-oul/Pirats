using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : Manager<GameManager>
{
    [SerializeField] private ShipStats _ship;
    [SerializeField] private WaitingLine _waitingLine;
    
    [FormerlySerializedAs("_enemy")] [SerializeField] private Enemies _enemyLeft;
    [SerializeField] private Enemies _enemyRight;
    
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

    public Action onGameStart; 
    
    public override void Awake()
    {
        base.Awake();
        if(!Ship) Ship = GameObject.FindGameObjectWithTag("Boat").GetComponent<ShipStats>();
        onGameStart += EnemyLoop;

    }

    private void OnDisable()
    {
        onGameStart -= EnemyLoop;
    }

    private int numberOfLoop = 0;
    public void EnemyLoop()
    {
        StartCoroutine(WaitForOpportunity());
        numberOfLoop++;
    }

    IEnumerator WaitForOpportunity()
    {
        float timeToWait = Mathf.Max(5f,12 - numberOfLoop);
        
        float ran = UnityEngine.Random.Range(0, 100f);
        print("will wait for :" + timeToWait + " Ran is :" + ran);
        
        yield return new WaitForSeconds(timeToWait);
        
        if (ran < 50f)
        {
            if (ran < 25f) _enemyRight.goAttack = true;
            else _enemyLeft.goAttack = true;
        }
        
        EnemyLoop();
    }
}
