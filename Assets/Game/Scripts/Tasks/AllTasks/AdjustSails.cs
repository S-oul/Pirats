using UnityEngine;

public class AdjustSails : Task
{
    [SerializeField] private float _boostReward;
    
    public override void Awake()
    {
        base.Awake();
        onEndTask += AddShipBoost ;
    }
    
    private void OnDisable()
    {
        onEndTask -= AddShipBoost;
    }

    void AddShipBoost()
    {
        GameManager.Instance.Ship.ShipBoost += _boostReward;
    }
}
