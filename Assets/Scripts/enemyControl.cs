using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyControl : MonoBehaviour
{
    [SerializeField] GameObject tower;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //Enemy is the navmesh agent in order to dynamically find a way to the tower
        agent.acceleration = 40f; //Good acceleration for feel
        agent.speed = 30f;
        agent.angularSpeed = 2060f;
        //agent.autoBraking = false;
        agent.SetDestination(tower.transform.position); //Destination is tower
    }

    private void OnCollisionEnter(Collision collision) //destroy enemy when it hits the tower
    {
        if (collision.gameObject.tag == "Tower")
        {
            Destroy(gameObject);
        }
    }
}
