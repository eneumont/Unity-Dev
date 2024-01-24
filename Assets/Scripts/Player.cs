using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {
    [SerializeField] TMP_Text scoreText;
    [SerializeField] FloatVariable health;
    [SerializeField] IntVariable lives;
    [SerializeField] PhysicCharacterController characterController;
    [SerializeField] GameObject respawn;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] VoidEvent gameStartEvent = default;
    [SerializeField] VoidEvent playerDeadEvent = default;
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

    }

    public void AddPoints(int points) {
        Score += points;
    }

    void onStartGame() { 
        characterController.enabled = true;
    }

    public void onRespawn(GameObject respawn) { 
        transform.position = respawn.transform.position;
        transform.rotation = respawn.transform.rotation;
        characterController.Reset();
    }

    public void Damage(float damage) { 
        health.value -= damage;
        if (health.value <= 0) {
            lives.value--;
            health.value = 100;
            onRespawn(respawn);
		}
        if (lives.value == 0) playerDeadEvent.RaiseEvent();
    }
}