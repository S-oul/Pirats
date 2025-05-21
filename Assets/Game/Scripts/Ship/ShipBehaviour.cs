using NaughtyAttributes;
using UnityEngine;
public class ShipBehaviour : MonoBehaviour
{
    [Header("Stats")] 
    [SerializeField] private float _shipSpeed = 0f;
    [SerializeField] private float _shipMaxSpeed = 10f;
    
    [ShowNonSerializedField] ShipHelpers.ShipState _shipState;
    
    
    
    

}

public static class ShipHelpers
{
    
    public enum ShipState
    {
        OnWater,
        Sinked,
        Attached,
        Anchored
    }
}
