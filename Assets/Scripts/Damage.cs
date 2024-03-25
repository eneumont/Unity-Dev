using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
	[SerializeField] float damage = 0;
	[SerializeField] bool damageOverTime = false;

	void OnTriggerEnter(Collider other) {
		if (!damageOverTime && other.gameObject.TryGetComponent(out Player player)) { 
			player.Damage(damage);
		}
	}

	void OnTriggerStay(Collider other) {
		if (damageOverTime && other.gameObject.TryGetComponent(out Player player)) {
			player.Damage(damage);
		}
	}
}