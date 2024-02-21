using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {
	[SerializeField] GameObject pickupPrefab = null;
	[SerializeField] string pickupType = null;
	[SerializeField] int points = 0;

	void OnCollisionEnter(Collision collision) {
		//print(collision.gameObject.name);    
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.TryGetComponent(out PlayerShip player)) {
			switch (pickupType) {
				case "score":
					player.AddPoints(points);
					break;
				case "health":
					player.ApplyHealth(points);
					break;
			}
		}

		Instantiate(pickupPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}