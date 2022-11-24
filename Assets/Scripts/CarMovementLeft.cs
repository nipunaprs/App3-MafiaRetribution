using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementLeft : MonoBehaviour
{

    Rigidbody rb;
    public Transform carSpawnPointRight;
    public Transform destroyPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(10, 0, 0);

        if (transform.position.x >= destroyPoint.position.x)
        {
            transform.position = new Vector3(carSpawnPointRight.position.x, transform.position.y, transform.position.z);
        }
    }
}
