using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour, IDamagable {
	[SerializeField] IntEvent scoreEvent;
    [SerializeField] Inventory inventory;
	[SerializeField] IntVariable score;
	[SerializeField] FloatVariable health;
	[SerializeField] GameObject hitPrefab;
	[SerializeField] GameObject deathPrefab;

	void Start () {
		scoreEvent.Subscribe(AddPoints);
        health.value = 100;
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            inventory.use();
        }

        if (Input.GetButtonUp("Fire1")) { 
            inventory.stopUse();
        }
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
			if (deathPrefab) {
				Instantiate(hitPrefab, gameObject.transform.position, Quaternion.identity);
			}
		}
	}
}
