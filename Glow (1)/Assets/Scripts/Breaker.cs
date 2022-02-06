using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    public ParticleSystem BoxBreak;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Player")
        { 
            StartCoroutine(TimedBoxDestroy());
        }

        
    }

    IEnumerator TimedBoxDestroy()
    {
        yield return new WaitForSeconds(0.02f);
        FMODUnity.RuntimeManager.PlayOneShot("event:/box_crack");
        Instantiate(BoxBreak, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Debug.Log("Breaker Works!");

    }
}
