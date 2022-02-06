using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dungeonScript : MonoBehaviour
{
    public float sceneLoadDelay=20f;
    private void Start()
    {
        Exit();
    }
    private void Exit()
    {
        StartCoroutine(WaitDoor("LvlBox1.0", sceneLoadDelay));
    }
    IEnumerator WaitDoor(string sceneName, float sceneLoadDelay)
    {
        yield return new WaitForSeconds(sceneLoadDelay);
        SceneManager.LoadScene(sceneName);
    }
}
