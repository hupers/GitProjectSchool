using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints;
    NavMeshAgent agent;
    int waypointIndex;
    Vector3 target;

    [Header("сюди гравця")]
    public Transform playerTarget; // позиция гравця

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        playerTarget = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, target) < 1)
        {
           IterateWaypointIndex();
            UpdateDestination();
        
            }
        float DistanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);
        if(DistanceToPlayer > 30f){

        }
        else if(DistanceToPlayer < 30f){
        Stalker();
        }
    }
    
    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if(waypointIndex== waypoints.Length)
        {
            waypointIndex = 2;
        }
    }

     private void Stalker()
    {
      agent.destination = playerTarget.position;
     }
}

