
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class PiratGhostController : MonoBehaviour
{
    [SerializeField] Transform _realPirat; 
    [SerializeField] Transform _ship;      
    private NavMeshAgent _ghostAgent;

    void Awake()
    {
        _ghostAgent = GetComponent<NavMeshAgent>();
        _ghostAgent.updatePosition = true;
        _ghostAgent.updateRotation = false;
    }

    //This remote AI navigation system was not what I originally intended, but because this package does not support moving plateform like this one I had to remake all these from start. This is why the hierarchy is a little bit overcomplexed
    void LateUpdate()
    {
        Vector3 shipToGhostOffset = _ship.position - this.transform.parent.position;
        Vector3 adjustedWorldPos = transform.position + shipToGhostOffset + new Vector3(-13f, 8.2f, 0); // weird Offset due to origin difference 
        _realPirat.localPosition = _ship.InverseTransformPoint(adjustedWorldPos);

        Vector3 localVelocity = _ship.InverseTransformDirection(_ghostAgent.desiredVelocity);
        if (localVelocity.sqrMagnitude > 0.01f)
        {
            Quaternion lookRot = Quaternion.LookRotation(localVelocity, Vector3.up);
            _realPirat.localRotation = Quaternion.Slerp(_realPirat.localRotation, lookRot, Time.deltaTime * 5f);
        }
    }

    public void SetDestination(Vector3 worldTargetPosition)
    {
        _ghostAgent.SetDestination(worldTargetPosition);
    }

    public Vector3 GetOnShipDestination()
    {
        return _ship.InverseTransformPoint(_ghostAgent.destination);
    }

}
