using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject[] goalLocations;
    // Start is called before the first frame update
    void Start()
    {
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        agent = this.GetComponent<NavMeshAgent>();
        int rand = Random.Range(0, goalLocations.Length);
        agent.SetDestination(goalLocations[rand].transform.position);
        float sm = Random.Range(0.1f, 1.5f); //step 4
        agent.speed = 2 * sm; //step 4
    }

    //step 3 changing agent priority
    
    // Update is called once per frame
    void Update()
    {
        //step 2
        if(agent.remainingDistance<1)
        {
            int rand = Random.Range(0, goalLocations.Length);
            agent.SetDestination(goalLocations[rand].transform.position);
        }
    }
}
