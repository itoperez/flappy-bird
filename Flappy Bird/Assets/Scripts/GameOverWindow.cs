using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    private Text scoreText;
    private Text highscoreText;

    private void Awake() {
        scoreText = transform.Find("scoreText").GetComponent<Text>();      
        highscoreText = transform.Find("highscoreText").GetComponent<Text>();     

        transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    private void Start() {
        Bird.GetInstance().OnDied += Bird_OnDied;
        Hide();
    }

    private void Bird_OnDied(object sender, System.EventArgs e) {
        scoreText.text = Level.GetInstance().GetPipesPassedCount().ToString();

        if (Level.GetInstance().GetPipesPassedCount() > Score.GetHighscore()){
            highscoreText.text = "NEW HIGHSCORE!";
        } else {
            highscoreText.text = "HIGHSCORE: " + Score.GetHighscore();
        }          
        Show();           
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void Show() {
        gameObject.SetActive(true);
    }


    public void LoadGameScene() {
        SoundManager.PlaySound(SoundManager.Sound.ButtonClick);
        StartCoroutine(DelayLoadGameScene());
    }
    
    IEnumerator DelayLoadGameScene() {
        yield return new WaitForSeconds(0.3f);
        Loader.Load(Loader.Scene.GameScene);
    }    

    public void LoadMainMenuScene() {
        SoundManager.PlaySound(SoundManager.Sound.ButtonClick);
        StartCoroutine(DelayLoadMainMenuScene());
    }

    IEnumerator DelayLoadMainMenuScene() {
        yield return new WaitForSeconds(0.3f);
        Loader.Load(Loader.Scene.MainMenu);
    }   

    public void PlayButtonOverSound() {
        SoundManager.PlaySound(SoundManager.Sound.ButtonOver);
    }    

}
