using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Enemy {
	[SerializeField] Weapon weapon;
	[SerializeField] float minFireRate;
	[SerializeField] float maxFireRate;
	[SerializeField] VoidEvent gameStart;
	bool start = false;

	void Start() {
		weapon.Equip();
		StartCoroutine(FireTimerCR());
	}

	void onEnable() {
		gameStart.Subscribe(starting);
	}

	void starting() { 
		start = true;
	}

	IEnumerator FireTimerCR() {
		while (start) {
			float time = Random.Range(minFireRate, maxFireRate);
			yield return new WaitForSeconds(time);
			weapon.Use();
		}
	}
}