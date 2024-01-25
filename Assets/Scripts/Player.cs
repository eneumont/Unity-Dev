using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Slider healthSlider;
    [SerializeField] TMP_Text livesText;
    [SerializeField] PhysicCharacterController characterController;
    [SerializeField] GameObject respawn;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent = default;
    [SerializeField] IntEvent livesEvent = default;
    [SerializeField] FloatEvent healthEvent = default;
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

	[SerializeField] float health = 100;
	public float Health {
		get { return health; }
		set { health = value;
			healthSlider.value = health; //might need to divide by 100.0f
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

	void OnEnable() {
        gameStartEvent.Subscribe(onStartGame);
    }

    void Start () { 

    }

	public void AddPoints(int points) {
        Score += points;
    }

    public void Healing(float heal) { 
        Health += heal;
    }

    public void Die() {
        if (Lives == 0) {
            playerDeadEvent.RaiseEvent();
        } else {
			Lives--;
			Health = health;
			onRespawn(respawn);
		}
    }

    void onStartGame() { 
        characterController.enabled = true;
		Lives = lives;
		Health = health;
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
}