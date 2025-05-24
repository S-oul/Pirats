
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class PiratGhostController : MonoBehaviour
{
    [SerializeField] Transform realPirat; 
    [SerializeField] Transform ship;      
    private NavMeshAgent ghostAgent;

    void Awake()
    {
        ghostAgent = GetComponent<NavMeshAgent>();
        ghostAgent.updatePosition = true;
        ghostAgent.updateRotation = false;
    }

    //This remote AI navigation system was not what I originally intended, but because this package does not support moving plateform like this one I had to remake all these from start. This is why the hierarchy is a little bit overcomplexed
    void LateUpdate()
    {
        Vector3 shipToGhostOffset = ship.position - this.transform.parent.position;
        Vector3 adjustedWorldPos = transform.position + shipToGhostOffset + new Vector3(-13f, 8.2f, 0); // weird Offset due to origin difference 
        realPirat.localPosition = ship.InverseTransformPoint(adjustedWorldPos);

        Vector3 localVelocity = ship.InverseTransformDirection(ghostAgent.desiredVelocity);
        if (localVelocity.sqrMagnitude > 0.01f)
        {
            Quaternion lookRot = Quaternion.LookRotation(localVelocity, Vector3.up);
            realPirat.localRotation = Quaternion.Slerp(realPirat.localRotation, lookRot, Time.deltaTime * 5f);
        }
    }

    public void SetDestination(Vector3 worldTargetPosition)
    {
        ghostAgent.SetDestination(worldTargetPosition);
    }

    public Vector3 GetOnShipDestination()
    {
        return ship.InverseTransformPoint(ghostAgent.destination);
    }

}
