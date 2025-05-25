using System;
using ShipHelpers;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Splines;

public class ShipStats : MonoBehaviour
{
    [Header("Stats")] 
    [SerializeField] private float _shipSpeed = 0f;
    [SerializeField] private float _shipAccel = 0.1f; 
    [SerializeField] private float _shipMaxSpeed = 10f;
    [SerializeField] private float _shipBoost = 0f;
    [SerializeField] private float _shipMaxBoost = 2f;

    [Range(0, 1)] 
    [SerializeField] private float _distancePercentage = 0f;
    //[SerializeField] private SplineContainer _trajectory;
    
    private Spline _spline;
    private StateMachine _shipStateMachine;
    
    [ShowNonSerializedField] ShipState _shipState = ShipState.Anchored;
    
    
    #region Accessors
    
    public ShipState MyShipState
    {
        get => _shipState;
        set => _shipState = value;
    }
    public Spline MySpline
    {
        get => _spline;
        set => _spline = value;
    }

    public float ShipSpeed
    {
        get => _shipSpeed;
        set {
        _shipSpeed = value;
        _shipSpeed = Mathf.Clamp(value, 0f, _shipMaxSpeed + _shipBoost);
        }
    }
    
    public float ShipBoost
    {
        get => _shipBoost;
        set {
            _shipBoost = value;
            _shipBoost = Mathf.Clamp(value, 0f, _shipMaxBoost);
        }    
    }
    public float DistancePercentage
    {
        get => _distancePercentage;
        set => _distancePercentage = value;
    }

    public StateMachine ShipStateMachine
    {
        get => _shipStateMachine;
        set => _shipStateMachine = value;
    }

    public float ShipAccel
    {
        get => _shipAccel;
        set => _shipAccel = value;
    }


    #endregion
    private void Awake()
    {
        // if(_trajectory == null) Debug.LogWarning("No trajectory defined");
        // MySpline = _trajectory.Spline;

        _shipStateMachine = GetComponent<StateMachine>();
    }
    
}

namespace ShipHelpers
{
        public enum ShipState
        {
            OnGoing,
            Sinked,
            Attached,
            Anchored
        }
    
}
