using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private float knockbackStrength;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direction = other.transform.position - transform.position;
            direction.y = 0;

            rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
        }
    }
}
