using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUIHandler : MonoBehaviour
{

    [SerializeField] GameObject gameOverUIObject;
    [SerializeField] TextMeshProUGUI endscoreText;
    

    private ScoreKeeper scoreKeeper;

    private void OnEnable() {
        PlayerDeathHandler.OnPlayerDeath += HandlePlayerDeathUI;
    }

    private void OnDisable() {
        PlayerDeathHandler.OnPlayerDeath -= HandlePlayerDeathUI;
    }

    private void Start() {
        scoreKeeper = ScoreKeeper.GetScoreKeeper();
    }

    private void HandlePlayerDeathUI(){
        //on game over, enable the UI and update the score to match with Scorekeeper
        gameOverUIObject.SetActive(true);
        endscoreText.text = "Final Score: " + scoreKeeper.GetScore();

    }   
    
}
