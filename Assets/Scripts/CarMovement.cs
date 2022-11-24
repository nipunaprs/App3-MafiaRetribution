using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    
    Rigidbody rb;
    public Transform carSpawnPointLeft;
    public Transform destroyPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(10, 0, 0);

        if (transform.position.x >= destroyPoint.position.x)
        {
            transform.position = new Vector3(carSpawnPointLeft.position.x, transform.position.y, transform.position.z);
        }
    }

    

}
