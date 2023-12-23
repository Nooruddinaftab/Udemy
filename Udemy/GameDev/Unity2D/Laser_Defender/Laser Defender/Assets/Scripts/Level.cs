using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;
    public void LoadStartMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
        if(FindObjectOfType<GameSession>())
            FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOverScene()
    {
        //SceneManager.LoadScene("GameOver");
        StartCoroutine(WaitAndLoadScene());
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }
}
