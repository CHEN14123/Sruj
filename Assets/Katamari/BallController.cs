using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]  //Adds automatic rigidbody when this script is added to the GameObject
public class BallController : MonoBehaviour
{
    public float Speed = 30;
    private Camera _camera;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _camera = Camera.main; //singleton pattern
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(x, 0, z);
        //Debug.Log(input);
        Vector3 move = (input.z * _camera.transform.forward) + (input.x * _camera.transform.right);
        _rigidbody.AddForce(move * Speed * Time.fixedDeltaTime * Size);
    }

    private float Size = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sticky") && collision.transform.localScale.magnitude <= Size)
        {
            collision.transform.parent = this.transform;
            Size += collision.transform.localScale.magnitude;

            if (collision.gameObject.GetComponent<Rigidbody>())
            {
                Destroy(collision.gameObject.GetComponent<Rigidbody>());
            }
        }
    }
}