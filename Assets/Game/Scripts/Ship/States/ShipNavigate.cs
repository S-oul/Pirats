using ShipHelpers;
using UnityEngine;
using UnityEngine.Splines;

public class ShipNavigate : State
{
    ShipStats _shipStats;
    [SerializeField] float _piratHelpper;

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
        _shipStats.DistancePercentage += _shipStats.ShipSpeed * Time.deltaTime / _shipStats.MySpline.GetLength();

        Vector3 currentPosition = _shipStats.MySpline.EvaluatePosition(_shipStats.DistancePercentage);
        Vector3 movement = currentPosition - transform.position;
        movement *= _piratHelpper;
        
        transform.position = currentPosition;
        
        // foreach (StateMachine pirat in GameManager.Instance.Pirats)
        // {
        //     pirat.transform.position += movement ;
        //     
        //     print("Moved pirat by : " + movement);
        // }
        

        if (_shipStats.DistancePercentage > 1f)
        {
            _shipStats.DistancePercentage = 0f;
        }

        Vector3 nextPosition = _shipStats.MySpline.EvaluatePosition(_shipStats.DistancePercentage + 0.05f);
        Vector3 direction = Quaternion.AngleAxis(-90, Vector3.up) * (nextPosition - currentPosition);
        transform.rotation = Quaternion.LookRotation(direction, transform.up);    }
}
