using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInstantiator : MonoBehaviour
{
    public GameObject prefab;

    private float next_spawn_time;

    public float EntranceRate = 5.0f;
    //public Transform generationPoint;

    //public float distanceBetween;
    //public GameObject[] theplatforms;

    //private float platformWidth;
    //private int platformSelector;

    // Start is called before the first frame update
    private void Start()
    {
        next_spawn_time = Time.time + EntranceRate;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > next_spawn_time)
        {
            //do stuff here (like instantiate)
            Instantiate(prefab, this.transform.position, Quaternion.identity);

            //increment next_spawn_time
            next_spawn_time += EntranceRate;
        }

        // Instantiate(prefab, this.transform.position, Quaternion.identity);

        /* if (Input.GetMouseButtonDown(0))
         {
             Instantiate(prefab, this.transform.position, Quaternion.identity);
         }*/

        /*if (transform.position.y < generationPoint.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + platformWidth + distanceBetween);
            platformSelector = Random.Range(0, theplatforms.Length);
            Instantiate(theplatforms[platformSelector], transform.position, transform.rotation);
        }*/
    }
}