using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {
    [SerializeField] TMP_Text scoreText;
    [SerializeField] FloatVariable health;
    [SerializeField] PhysicCharacterController characterController;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] VoidEvent gameStartEvent = default;
    private int score = 0;
    public int Score { 
        get { return score; } 
        set { score = value; 
            scoreText.text = score.ToString();
            scoreEvent.RaiseEvent(score);
        } 
    }

    void OnEnable() {
        gameStartEvent.Subscribe(onStartGame);    
    }

    void Start () { 
        health.value = 5.5f; 
    }

    public void AddPoints(int points) {
        Score += points;
    }

    void onStartGame() { 
        characterController.enabled = true;
    }
}
