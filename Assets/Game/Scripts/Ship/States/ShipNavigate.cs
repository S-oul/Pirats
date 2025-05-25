using ShipHelpers;
using UnityEngine;
using UnityEngine.Splines;

public class ShipNavigate : State
{
    ShipStats _shipStats;

    public override void StateInit(StateMachine sm)
    {
        base.StateInit(sm);
        _shipStats = GetComponent<ShipStats>();
    }

    public override void StateEnter()
    {
        base.StateEnter();
        _shipStats.MyShipState = ShipState.OnGoing;
    }

    public override void StateUpdate()
    {
        _shipStats.ShipSpeed += _shipStats.ShipAccel * Time.deltaTime;
        transform.position += Quaternion.AngleAxis(90,Vector3.up) * transform.forward * _shipStats.ShipSpeed * Time.deltaTime;

        if (_shipStats.ShipBoost > 0) _shipStats.ShipBoost -= Time.deltaTime;


        //_shipStats.DistancePercentage += _shipStats.ShipSpeed * Time.deltaTime / _shipStats.MySpline.GetLength();
        // Vector3 currentPosition = _shipStats.MySpline.EvaluatePosition(_shipStats.DistancePercentage);
        // Vector3 movement = currentPosition - transform.position;
        //
        // transform.position = currentPosition;
        //
        // if (_shipStats.DistancePercentage > 1f)
        // {
        //     _shipStats.DistancePercentage = 0f;
        // }
        //
        // Vector3 nextPosition = _shipStats.MySpline.EvaluatePosition(_shipStats.DistancePercentage + 0.05f);
        // Vector3 direction = Quaternion.AngleAxis(-90, Vector3.up) * (nextPosition - currentPosition);
        // transform.rotation = Quaternion.LookRotation(direction, transform.up);
    }
}
