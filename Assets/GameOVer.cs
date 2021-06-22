using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class GameOVer : MonoBehaviour
{
    public GameObject gameoverUI;
    public static GameObject copyUI;
    private void Awake()
    {
        copyUI = gameoverUI;
    }
    public static void GameOver()
    {
        Time.timeScale = 0;
        copyUI.SetActive(true);
    }
    public  void restartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        copyUI.SetActive(false);
        move_ship.health = 5;
    }
}
