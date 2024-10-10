using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_Text BestScoreText;
    public void Start()
    {
        BestScoreText.text = $"Best Score : {ScoreManager.instance.highScorePlayerName} : {ScoreManager.instance.highScore}";
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("main");
    }
}
