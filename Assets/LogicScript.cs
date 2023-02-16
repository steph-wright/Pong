using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public TMP_Text whoWon;
    public int Rally;
    public bool GameIsOver = false;
    public TMP_Text HighScore;

    private void Update()
    {
       
    }
    public void IncrementRally()
    {
        Rally++;
    }
    public void GameOver(string message)
    {
        whoWon.text = message;
        gameOverScreen.SetActive(true);
        GameIsOver = true;
        CheckAndSetHighScore();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CheckAndSetHighScore()
    { 
        if (Rally > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Rally);
            PlayerPrefs.Save();
        }
    }
}    
