using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    public static void Start() {
        // ResetHighscore();
        Bird.GetInstance().OnDied += Bird_OnDied;
    }

    private static void Bird_OnDied(object sender, System.EventArgs e) {
        TrySetNewHighscore(Level.GetInstance().GetPipesPassedCount());
    }

    public static int GetHighscore() {
        return PlayerPrefs.GetInt("highscoreFlappyBird");
    }

    public static bool TrySetNewHighscore(int score) {
        int currentHighscore = GetHighscore();
        if (score > currentHighscore) {
            PlayerPrefs.SetInt("highscoreFlappyBird", score);
            PlayerPrefs.Save();
            return true;
        } else {
            return false;
        }
    }

    public static void ResetHighscore() {
        PlayerPrefs.SetInt("highscoreFlappyBird", 0);
        PlayerPrefs.Save();
    }
}
