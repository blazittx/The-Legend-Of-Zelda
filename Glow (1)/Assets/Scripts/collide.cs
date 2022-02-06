using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player Hit");
            Destroy(gameObject);
        }
    }
}
