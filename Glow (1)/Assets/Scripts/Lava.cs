using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public Rigidbody rb;
    public int dragComp;
    public float torque;

    public float lockPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.AddTorque(transform.up * torque);
    }

    private void OnTriggerEnter(Collider other)
    {
        rb.freezeRotation = true;
        rb.drag = (dragComp);
        Destroy(gameObject, 4);
        Debug.Log("Object Fell In Lava!");
    }
}
