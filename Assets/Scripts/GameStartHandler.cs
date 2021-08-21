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

    public void StartGame(){
        //disable the game start UI
        //enable the score UI
        OnGameStarted();
        gameStartUIObject.SetActive(false);
        scoreText.gameObject.SetActive(true);

    }
}
