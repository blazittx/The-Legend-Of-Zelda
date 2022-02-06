using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLvlBoxR1 : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("GOGOGOGO SCENE");
            SceneManager.LoadScene("LvlBoxR1.1"); //load this scene... change SCENENAME to the name of the scene you want
        }
    }

}
