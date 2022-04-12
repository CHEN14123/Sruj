using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public FlockManager Manager;
    private float Speed;
    private bool turning;
    // Start is called before the first frame update
    private void Start()
    {
        Speed = Random.Range(Manager.MinSpeed, Manager.MaxSpeed);
    }

    // Update is called once per frame
    public void BoidUpdate()
    {
        //step 9
        Bounds b = new Bounds(Manager.transform.position, Manager.Limits * 1);
        RaycastHit hit;
        Vector3 direction = Manager.transform.position - transform.position;// This value doesnt matter
        Debug.DrawRay(this.transform.position, this.transform.forward , Color.red);
        if (!b.Contains(this.transform.position))
        {
            turning = true;
        }
        else if(Physics.Raycast(this.transform.position, this.transform.forward, out hit ))
        {
            turning = true;
            direction = Vector3.Reflect(this.transform.forward, hit.normal);
        }

        else
        {
            turning = false;
        }
        
        //if turning is true
        if(turning)
        {
            Quaternion quat = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(this.transform.rotation, quat, Manager.RotationSpeed * Time.deltaTime);
            transform.Translate(0, 0, Time.deltaTime * Speed);
            return; //exit and end unction

        }

        //random speed/behavior
        if (Random.Range(0,100)<10) //10% chance that speed will change
            Speed = Random.Range(Manager.MinSpeed, Manager.MaxSpeed);
        if (Random.Range(0, 100) > 20)
        {
            transform.Translate(0, 0, Time.deltaTime * Speed);

            return; //exit and end unction
        }

        GameObject[] boids = Manager.boids;

        Vector3 groupCenter = Vector3.zero;//1
        float groupSpeed = 0.01f;
        int groupSize = 0; // group within distance
        Vector3 avoid = Vector3.zero; //3.
        
        // Update Flock calculations
        //1. Move toward savergaare position of the group
        //2. Align with the avergae general direction
        //3. Avoid crowdign other flock members

        foreach(GameObject go in boids)
        {
            if(go==this.gameObject) { continue; } //skip next "guard statement"
            float distance = Vector3.Distance(go.transform.position, this.transform.position);
            if(distance> Manager.NeighborDistance) { continue; }

            groupCenter += go.transform.position;//1.
            groupSize++;//1.

            if(distance<1.0f)
            {
                avoid += (this.transform.position - go.transform.position);// move in the opposite direection

            }

            Boid boidscript = go.transform.GetComponent<Boid>();
            groupSpeed += boidscript.Speed;
        }

        if(groupSize>0)
        {
            groupCenter = groupCenter / groupSize  + (Manager.GoalPos - this.transform.position);  //average +goal
            groupSpeed = groupSpeed / groupSize; //average of all boid speeds


            direction = (groupCenter + avoid) - this.transform.position;
            if(direction !=Vector3.zero)
            {
                Quaternion quat = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(this.transform.rotation, quat, Manager.RotationSpeed * Time.deltaTime);

            }
        }


        transform.Translate(0, 0, Time.deltaTime * Speed);
    }
}
