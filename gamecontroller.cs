using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gamecontroller : MonoBehaviour
{

    public int totalScore;
    public TMP_Text scoreText; 
    public GameObject gameOver;

    public static gamecontroller instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
    
    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
}