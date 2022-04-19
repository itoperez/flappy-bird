using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets instance;

    // static makes it so we can access this anywhere
    public static GameAssets GetInstance() {
        return instance;
    }

    // Edit -> Project Settings -> Script Execution Order [Move GameAssets.cs to top to execute first]
    private void Awake() {
        instance = this;
    }

    public Sprite pipeHeadSprite;
    public Transform pfPipeHead;
    public Transform pfPipeBody;
    public Transform pfGound;
    public Transform pfCloud_1;
    public Transform pfCloud_2;
    public Transform pfCloud_3;

    public SoundAudioClip[] soundAudioClipArray;

    [Serializable] 
    public class SoundAudioClip {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
