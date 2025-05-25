using UnityEngine;

public class AdjustSails : Task
{
    [Header("Reward")]
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
