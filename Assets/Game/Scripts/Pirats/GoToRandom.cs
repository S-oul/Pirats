using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToRandom : MonoBehaviour
{

    NavMeshAgent agent;

    public List<Transform> transforms = new List<Transform>();

    public  float timer = 0;
    public float roamTimer = 3;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        timer = UnityEngine.Random.Range(0f,roamTimer);
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > roamTimer) //Roaming
        {
            timer = 0;
            agent.SetDestination(transforms[UnityEngine.Random.Range(0, transforms.Count - 1)].position);
        }

    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;
        randDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

}
