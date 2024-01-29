using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject playUI;
    [SerializeField] GameObject gameoverUI;
    [SerializeField] GameObject gamewonUI;
    //[SerializeField] TMP_Text timerUI;
    //[SerializeField] GameObject respawn;

    [Header("Events")]
    [SerializeField] VoidEvent gameStartEvent;
    [SerializeField] VoidEvent gameOverEvent;
    [SerializeField] VoidEvent gameWonEvent;
    //[SerializeField] GameObjectEvent respawnEvent;
    //[SerializeField] FloatEvent timeEvent;

    public enum State { 
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAMEOVER,
        GAME_WON
    }
    public State state = State.TITLE;

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
                playUI.SetActive(false);
                gameoverUI.SetActive(false);
                gamewonUI.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
				break;
			case State.START_GAME:
                titleUI.SetActive(false);
				playUI.SetActive(true);
				gameoverUI.SetActive(false);
				gamewonUI.SetActive(false);
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
                gameStartEvent.RaiseEvent();
                //respawnEvent.RaiseEvent(respawn);
				state = State.PLAY_GAME;
				break;
			case State.PLAY_GAME:
				break;
			case State.GAMEOVER:
				titleUI.SetActive(false);
				playUI.SetActive(false);
				gameoverUI.SetActive(true);
				gamewonUI.SetActive(false);
				break;
            case State.GAME_WON:
				titleUI.SetActive(false);
				playUI.SetActive(false);
				gameoverUI.SetActive(false);
				gamewonUI.SetActive(true);
				break;
		}
	}

    public void onStartGame() { 
        state = State.START_GAME;
    }

    public void onPlayerDead() {
        state = State.GAMEOVER;
    }

    public void onPlayerWon() {
        state = State.GAME_WON;
    }
}