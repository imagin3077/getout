using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    enum AIStates
    {
        Idle,
        Wandering
    }

    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private LayerMask floorMask = 0;
    private AIStates curStates = AIStates.Idle;
    private float waltTimer = 0.0f;
    public GameObject self;
    public float Distance;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = true;



    }

    private void Update()
    {
        Distance = Vector3.Distance(self.transform.position, target.transform.position);
        if (Distance <= 10)
        {
            agent.destination = target.position;
            Debug.Log("keliatan");
        }
        else
        {
            switch (curStates)
            {
                case AIStates.Idle:
                    Doidle();
                    break;
                case AIStates.Wandering:
                    DoWanter();
                    break;
                default:
                    Debug.LogError("Keep walking");
                    break;

            }
            //transform.LookAt(target);
        }
    }

    private void Doidle()
    {
        if (waltTimer > 0)
        {
            waltTimer -= Time.deltaTime;
            return;
        }

        agent.SetDestination(RandomNavSphere(transform.position, 10.0f, floorMask));
        curStates = AIStates.Wandering;
    }

    private void DoWanter()
    {
        if (agent.pathStatus != NavMeshPathStatus.PathComplete)
            return;
        waltTimer = Random.Range(1.0f, 4.0f);
        curStates = AIStates.Idle;
    }

    Vector3 RandomNavSphere(Vector3 origin, float distance, LayerMask layerMask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
        randomDirection += origin;
        NavMeshHit navhit;
        NavMesh.SamplePosition(randomDirection, out navhit, distance, layerMask);
        return navhit.position;

    }

    /*void OnDrawGizmozSelected(){
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 50f);
    }*/
}
  

