using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject fallMarkerPrefab = null;
    [SerializeField] private Vector3 fallDirection = Vector3.down;
    private GameObject fallMarkerInstance = null;



    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    private void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);

        if (fallMarkerPrefab != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(new Ray(transform.position, fallDirection), out hit))
            {
                Vector3 fallPosition = hit.point;
                fallMarkerInstance = Instantiate(fallMarkerPrefab, fallPosition - 0.05f * fallDirection, Quaternion.identity);
            }
        }
    }

    public void SpawnObject()
    {

        Instantiate(spawnee, transform.position, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }

    private void OnDestroy()
    {
        
        if (fallMarkerInstance != null) { Destroy(fallMarkerInstance); }
    }

}