using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class PlayerShip : MonoBehaviour, IDamagable {
	[SerializeField] PathFollower pathfollower;
    [SerializeField] Inventory inventory;
	[SerializeField] IntVariable score;
	[SerializeField] IntVariable lives;
	[SerializeField] FloatVariable health;
	[SerializeField] GameObject hitPrefab;
	[SerializeField] GameObject deathPrefab;
	[SerializeField] GameObject respawnObj;
	[SerializeField] Slider healthSlider;
	[SerializeField] TMP_Text livesText;
	[SerializeField] TMP_Text scoreText;
	[SerializeField] TMP_Text endScoreText;
	[Header("Events")]
	[SerializeField] VoidEvent gameStartEvent = default;
	[SerializeField] VoidEvent gameWonEvent = default;
	[SerializeField] VoidEvent gameOverEvent = default;
	[SerializeField] VoidEvent playerDeadEvent = default;
	[SerializeField] IntEvent scoreEvent = default;
	[SerializeField] GameObjectEvent respawnEvent;
	bool weapon1 = true;

	void Start () {
		respawnEvent.Subscribe(respawn);
		gameStartEvent.Subscribe(startGame);
		scoreEvent.Subscribe(AddPoints);

	}

    void Update() {
		if (Input.GetKeyUp(KeyCode.T)) {
			weapon1 = !weapon1;
			inventory.currentItem = weapon1 ? inventory.items[0] : inventory.items[1];
		}

        if (Input.GetButtonDown("Fire1")) inventory.use();
        if (Input.GetButtonUp("Fire1")) inventory.stopUse();

		pathfollower.speed = (Input.GetKey(KeyCode.Space)) ? 2 : 1;
    }

	public void AddPoints(int points) {
		score.value += points;
		scoreText.text = "Score: " + score.value;
		//Debug.Log(score.value);
	}

	public void ApplyDamage(float damage) {
		health.value -= damage;
		if (health.value <= 0) {
			if (deathPrefab) {
				Instantiate(deathPrefab, gameObject.transform.position, Quaternion.identity);
			}
			Destroy(gameObject);
			Die();
		} else {
			if (hitPrefab) {
				Instantiate(hitPrefab, gameObject.transform.position, Quaternion.identity);
			}
		}
		healthSlider.value = this.health.value;
	}

	public void ApplyHealth(float health) { 
		this.health.value += health;
		this.health.value = Mathf.Min(this.health.value, 100);
		healthSlider.value = this.health.value;
	}

	public void respawn(GameObject respawn) {
		pathfollower.tdistance = respawn.GetComponent<PathFollower>().tdistance;
	}

	public void winGame() {
		pathfollower.enabled = false;
		endScoreText.text = "Score: " + score;
		gameWonEvent.RaiseEvent();
	}

	public void Die() {
		if (lives.value == 0) {
			gameOverEvent.RaiseEvent();
		} else {
			lives.value--;
			health.value = 100;
			respawn(respawnObj);
		}
	}

	public void startGame() {
		health.value = 100;
		score.value = 0;
		lives.value = 3;
		healthSlider.value = health.value;
		scoreText.text = "Score: " + score.value;
		livesText.text = "Lives: " + lives.value;
	}
}