using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score = 0;

    private void Start() {
        HandleScoreText();
    }

    private void Awake() {
        //prevent duplicates that the static function GetScoreKeeper works properly
        ScoreKeeper[] scoreKeepers = FindObjectsOfType<ScoreKeeper>();
        if(scoreKeepers.Length > 1){
            Destroy(gameObject);
        }
    }

    public static ScoreKeeper GetScoreKeeper(){
        //remember to make sure the ScoreKeeper object in the scene is tagged!
        return GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>();
    }


    public void AddToScore(int i){
        score += i;
        HandleScoreText();
    }

    private void HandleScoreText(){
        scoreText.text = "Score: " + score.ToString();
    }

    public int GetScore(){
        return score;
    }

}
