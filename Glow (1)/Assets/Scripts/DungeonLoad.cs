using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonLoad : MonoBehaviour
{

        void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player"))
        {
            Debug.Log("GOGOGOGO SCENE");
            SceneManager.LoadScene("Dungeon"); //load this scene... change SCENENAME to the name of the scene you want
        }
        }

}
