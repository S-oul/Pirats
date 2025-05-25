using ShipHelpers;
using UnityEngine;
using UnityEngine.Splines;

public class ShipNavigate : State
{
    ShipStats _shipStats;
    [SerializeField] Task _sailTask;

    public override void StateInit(StateMachine sm)
    {
        base.StateInit(sm);
        _shipStats = GetComponent<ShipStats>();
    }

    private Quaternion _shipDirection;
    public override void StateEnter()
    {
        base.StateEnter();
        _shipStats.MyShipState = ShipState.OnGoing;
        _shipDirection = Quaternion.AngleAxis(90, Vector3.up);
    }

    public override void StateUpdate()
    {
        _shipStats.ShipSpeed += _shipStats.ShipAccel * Time.deltaTime + _shipStats.ShipBoost;
        if (_shipStats.MyShipState == ShipState.OnGoing)
        {
            transform.position +=  _shipDirection *  (_shipStats.ShipSpeed * Time.deltaTime * transform.forward);
        }else if (_shipStats.MyShipState == ShipState.Attached)
        {
            transform.position +=  _shipDirection *  (_shipStats.ShipSpeed/2f * Time.deltaTime * transform.forward) ;
        }

        if (_shipStats.ShipBoost > 0)
        {
            _shipStats.ShipBoost -= Time.deltaTime/10f;
            if (_shipStats.ShipBoost <= 0)
            {
                print(_sailTask);
                _sailTask.EnableTask();
            }
        }
        
        
    }
}
