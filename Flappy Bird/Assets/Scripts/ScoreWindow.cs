using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private Text scoreText;
    private Text highscoreText;

    private void Awake() {
        scoreText = transform.Find("scoreText").GetComponent<Text>();    
        highscoreText = transform.Find("highscoreText").GetComponent<Text>(); 
    }

    private void Start() {
        highscoreText.text = "HIGHSCORE: " + Score.GetHighscore().ToString();        
        Bird.GetInstance().OnStartedPlaying += ScoreWindow_OnStartedPlaying;
        Bird.GetInstance().OnDied += ScoreWindow_OnDied;
        Hide();
    }    

    private void ScoreWindow_OnStartedPlaying(object sender, System.EventArgs e) {
        Show();
    }

    private void ScoreWindow_OnDied(object sender, System.EventArgs e) {
        Hide();
    }

    private void Update() {
        scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void Show() {
        gameObject.SetActive(true);
    }
}
