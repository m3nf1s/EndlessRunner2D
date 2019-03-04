using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; // Синглтон
    public Text textScore; // Текст очков во время игры
    public Text menuTextScore; // Текст очков в меню    
    public GameObject Panel; // Панель появляющаяся при проигрыше
    public bool gameOver = false; // Икончание игры

    private int Score; // Количество очков

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Добавление очков
    /// </summary>
    public void AddScore()
    {
        Score++;
        textScore.text = "Score: " + Score.ToString();
        menuTextScore.text = "Score: " + Score.ToString();
    }

    /// <summary>
    /// Окончание игры
    /// </summary>
    public void GameOver()
    {
        gameOver = true;
        textScore.enabled = false;
        Panel.SetActive(true);
    }

    /// <summary>
    /// Перезагрузка игры
    /// </summary>
    public void Restart()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Выход из игры
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
