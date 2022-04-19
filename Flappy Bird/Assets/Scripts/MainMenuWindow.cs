using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWindow : MonoBehaviour
{
    private void Awake() {

    }

    public void LoadGameScene() {
        SoundManager.PlaySound(SoundManager.Sound.ButtonClick);
        StartCoroutine(DelayLoadGameScene());
    }
    
    IEnumerator DelayLoadGameScene() {
        yield return new WaitForSeconds(0.3f);
        Loader.Load(Loader.Scene.GameScene);
    }

    public void QuitGame() {
        SoundManager.PlaySound(SoundManager.Sound.ButtonClick);
        StartCoroutine(DelayQuitGame());
    }

    IEnumerator DelayQuitGame() {
        yield return new WaitForSeconds(0.3f);
        Application.Quit();
    } 

    public void PlayButtonOverSound() {
        SoundManager.PlaySound(SoundManager.Sound.ButtonOver);
    }

}
