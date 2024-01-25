using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    [SerializeField] GameObject titleUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] GameObject respawn;

    [Header("Events")]
    [SerializeField] VoidEvent gameStartEvent;
    [SerializeField] GameObjectEvent respawnEvent;
    public enum State { 
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAMEOVER,
        GAME_WON
    }

    public State state = State.TITLE;
    public float timer = 0;

	public float Timer {
		get { return timer; }
		set { timer = value; timerUI.text = string.Format("{0:F1}", timer); }
	}

    void OnEnable() {
        
    }

    void OnDisable() {
        
    }

    void Start() {
        
    }

    void Update() {
		switch (state) {
			case State.TITLE:
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
				break;
			case State.START_GAME:
                titleUI.SetActive(false);
                Timer = 60;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
                gameStartEvent.RaiseEvent();
                respawnEvent.RaiseEvent(respawn);
				state = State.PLAY_GAME;
				break;
			case State.PLAY_GAME:
                Timer = Timer - Time.deltaTime;
                if (Timer <= 0 ) state = State.GAMEOVER;
				break;
			case State.GAMEOVER:
				break;
            case State.GAME_WON:
                break;
            default:
                break;
		}
	}

    public void onStartGame() { 
        state = State.START_GAME;
    }

    public void onPlayerDead() {
        state = State.TITLE;
    }

    public void OnAddPoints(int points) {
        print(points);
    }
}