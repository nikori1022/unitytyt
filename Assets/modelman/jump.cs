using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    private Rigidbody rb;
    private int upForce;
    private bool isGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        upForce = 200;
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && isGround)
            rb.AddForce(new Vector3(0, upForce, 0));
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Plane")
            isGround = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Plane")
            isGround = false;
    }
}