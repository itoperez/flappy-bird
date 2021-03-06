using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private const float JUMP_AMOUNT = 90f;

    private static Bird instance;

    public static Bird GetInstance() {
        return instance;
    }

    public event EventHandler OnDied;
    public event EventHandler OnStartedPlaying;
    
    private Rigidbody2D birdRigidBody2D;
    private State state;

    private enum State {
        WaitingToStart,
        Playing,
        BirdDead,
    }
    
    private void Awake() {
        instance = this;
        birdRigidBody2D = GetComponent<Rigidbody2D>();
        birdRigidBody2D.bodyType = RigidbodyType2D.Static;
        state = State.WaitingToStart;
    }

    private void Update() { 
        switch (state) {
            default:
                case State.WaitingToStart:
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
                        state = State.Playing;
                        birdRigidBody2D.bodyType = RigidbodyType2D.Dynamic;
                        Jump();
                        if (OnStartedPlaying != null) {
                            OnStartedPlaying(this, EventArgs.Empty);
                        } 
                    }
                    break;
                case State.Playing:
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
                        Jump();
                    }
                    transform.eulerAngles = new Vector3(0, 0, birdRigidBody2D.velocity.y * 0.15f);
                    break;
                case State.BirdDead:
                    break; 
        }

    }

    private void Jump() {
        birdRigidBody2D.velocity = Vector2.up * JUMP_AMOUNT;
        SoundManager.PlaySound(SoundManager.Sound.birdJump);
    }
    
    private void OnTriggerEnter2D(Collider2D collider) {
        birdRigidBody2D.bodyType = RigidbodyType2D.Static;
        SoundManager.PlaySound(SoundManager.Sound.Lose);
        state = State.BirdDead;
        if (OnDied != null) {
            OnDied(this, EventArgs.Empty);
        } 
    }
}
