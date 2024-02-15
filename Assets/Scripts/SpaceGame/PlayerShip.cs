using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour, IDamagable {
	[SerializeField] PathFollower pathfollower;
	[SerializeField] IntEvent scoreEvent;
    [SerializeField] Inventory inventory;
	[SerializeField] IntVariable score;
	[SerializeField] IntVariable lives;
	[SerializeField] FloatVariable health;
	[SerializeField] GameObject hitPrefab;
	[SerializeField] GameObject deathPrefab;
	bool weapon1 = true;

	void Start () {
		scoreEvent.Subscribe(AddPoints);
        health.value = 100;
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
		Debug.Log(score.value);
	}

	public void ApplyDamage(float damage) {
		health.value -= damage;
		if (health.value <= 0) {
			if (deathPrefab) {
				Instantiate(deathPrefab, gameObject.transform.position, Quaternion.identity);
			}
			Destroy(gameObject);
		} else {
			if (hitPrefab) {
				Instantiate(hitPrefab, gameObject.transform.position, Quaternion.identity);
			}
		}
	}

	public void ApplyHealth(float health) { 
		this.health.value += health;
		this.health.value = Mathf.Min(this.health.value, 100);
	}
}