using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStartHandler : MonoBehaviour
{

    //event for informing that game has started
    public delegate void GameStarted();
    public static event GameStarted OnGameStarted;


    [SerializeField] GameObject gameStartUIObject;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake() {
        //on starting the game, set timescale to 0
        Time.timeScale = 0f;
    }

    public void StartGame(){
        //disable the game start UI
        //enable the score UI
        OnGameStarted();
        gameStartUIObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        //set timescale back to 1 
        Time.timeScale = 1f;
    }
}
