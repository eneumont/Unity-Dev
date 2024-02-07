using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Enemy {
	[SerializeField] Weapon weapon;
	[SerializeField] float minFireRate;
	[SerializeField] float maxFireRate;

	void Start () { 
		weapon.Equip();
		StartCoroutine(FireTimerCR());
	}

	IEnumerator FireTimerCR() {
		while (true) {
			float time = Random.Range(minFireRate, maxFireRate);
			yield return new WaitForSeconds(time);
			weapon.Use();
		}
	}
}