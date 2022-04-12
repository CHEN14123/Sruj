using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentFleeController : MonoBehaviour
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
        ResetAgent();
    }

    //step 3 changing agent priority

    // Update is called once per frame
    void Update()
    {
        //step 2
        if (agent.remainingDistance < 1)
        {
            ResetAgent();
            int rand = Random.Range(0, goalLocations.Length);
            agent.SetDestination(goalLocations[rand].transform.position);
        }
    }

    //step 1
    private void ResetAgent()
    {
        float sm = Random.Range(0.1f, 1.5f); //step 4
        agent.angularSpeed = 120;
        agent.ResetPath();
    }


    //step 2
    private float detectionRadius = 5;
    private float fleeRadius = 10;
    public void DetectNewObstacle(Vector3 position)
    {
        //if farther than radius, exit this function(run no more code)
        if(Vector3.Distance(position, this.transform.position)> detectionRadius) { return; }//exit

        Vector3 fleeDir = (this.transform.position - position).normalized;//vector length of one
        Vector3 goal = this.transform.position + fleeDir * fleeRadius;
        agent.SetDestination(goal);
        agent.speed = 10;
        agent.angularSpeed = 500;
    }
}
