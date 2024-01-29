using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Slider healthSlider;
    [SerializeField] TMP_Text livesText;
    [SerializeField] TMP_Text timerText;
    [SerializeField] PhysicCharacterController characterController;
    [SerializeField] GameObject respawn;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] IntEvent livesEvent = default;
    [SerializeField] FloatEvent healthEvent = default;
    [SerializeField] FloatEvent timeEvent = default;
    [SerializeField] VoidEvent gameStartEvent = default;
    [SerializeField] VoidEvent gameWonEvent = default;
    [SerializeField] VoidEvent gameOverEvent = default;
    [SerializeField] VoidEvent playerDeadEvent = default;
    
    private int score = 0;
    public int Score { 
        get { return score; } 
        set { score = value; 
            scoreText.text = score.ToString();
            scoreEvent.RaiseEvent(score);
        } 
    }

	[SerializeField] float health = 100;
	public float Health {
		get { return health; }
		set { health = value;
			healthSlider.value = health / 100.0f;
			healthEvent.RaiseEvent(health);
		}
	}

	private int lives = 3;
	public int Lives {
		get { return lives; }
		set { lives = value;
			livesText.text = "Lives: " + lives.ToString();
			livesEvent.RaiseEvent(lives);
		}
	}

	float timer = 0;
	public float Timer {
		get { return timer; }
		set { timer = value; timerText.text = string.Format("{0:F1}", timer); }
	}

	void OnEnable() {
        gameStartEvent.Subscribe(onStartGame);
        gameStartEvent.Subscribe(onStartGame);
        gameStartEvent.Subscribe(onStartGame);
        print("Subcribed");
    }

    void Start () { 

    }

	void Update() {
        if (characterController.enabled) Timer -= Time.deltaTime;
        if (Timer <= 0) Die();
	}

	public void AddPoints(int points) {
        Score += points;
    }

    public void Healing(float heal) { 
        Health += heal;
    }

    public void Die() {
        if (Lives == 0 || Timer <= 0) {
            playerDeadEvent.RaiseEvent();
        } else {
			Lives--;
			Health = 100;
			onRespawn(respawn);
		}
    }

    void onStartGame() {
        print("start player");
        characterController.enabled = true;
        onRespawn(respawn);
		Lives = 3;
		Health = 100;
        Score = 0;
        Timer = 60;
	}

    public void onRespawn(GameObject respawn) { 
        transform.position = respawn.transform.position;
        transform.rotation = respawn.transform.rotation;
        characterController.Reset();
    }

    public void Damage(float damage) { 
        Health -= damage;
        if (Health <= 0) Die();
    }

    public void moreTime(float time) {
        Timer += time;
    }
}