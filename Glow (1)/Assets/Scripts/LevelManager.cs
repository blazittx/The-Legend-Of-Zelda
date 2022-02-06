using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 1f;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame()
    {
        //scoreKeeper.ResetScore();
        SceneManager.LoadScene("LvlBox1.0");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("gameStart");
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitandLoad("gameOver", sceneLoadDelay));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator WaitandLoad(string sceneName, float sceneLoadDelay)
    {
        yield return new WaitForSeconds(sceneLoadDelay);
        SceneManager.LoadScene(sceneName);

    }
}
