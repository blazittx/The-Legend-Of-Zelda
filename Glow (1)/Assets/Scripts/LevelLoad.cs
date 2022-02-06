using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    public int Level;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("GOGOGOGO SCENE");
            SceneManager.LoadScene(Level); //load this scene... change SCENENAME to the name of the scene you want
        }
    }

}
