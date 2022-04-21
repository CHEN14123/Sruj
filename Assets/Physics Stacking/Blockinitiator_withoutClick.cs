using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockinitiator_withoutClick : MonoBehaviour
{

    public GameObject prefab;
    private Collision collision;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Instantiate(prefab, this.transform.position, Quaternion.identity);
        /*if ((collision.gameObject.CompareTag("Sticky")) || (collision.gameObject.CompareTag("Ground")))
        {//Destroy(prefab.GetComponent<Rigidbody>());
            Debug.Log("Collision");
            Destroy(gameObject.GetComponent<Rigidbody>());
            //Destroy(GetComponent<Rigidbody>());
            Debug.Log("Destroy");
            //Destroy(gameObject);


        }*/



    }

    /* public void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Sticky")) || (collision.gameObject.CompareTag("Ground")))
        {//Destroy(prefab.GetComponent<Rigidbody>());
            Debug.Log("Collision");
            Destroy(gameObject.GetComponent<Rigidbody>());
            //Destroy(GetComponent<Rigidbody>());
            Debug.Log("Destroy");
            //Destroy(gameObject);


        }
    }*/
}   
